using System.Collections;
using System.Collections.Generic;

using Assets.PixelFantasy.PixelHeroes.Common.Scripts.CharacterScripts;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Max y and x axis of area")]
    [SerializeField] float maxXaxisOfArea;
    [SerializeField] float maxYaxisOfArea;
    // x-11,11; y-8,8 
    [Header("arena settings and prefabs for spawning")]
    [SerializeField] GameObject mobUnit;
    [SerializeField] GameObject mobUnitV2;
    [SerializeField] GameObject lootChest;
    [SerializeField] GameObject heroUnit;
    [SerializeField] GameObject heroUnitV2;
    [SerializeField] GameObject heroCamp;

    [Header("ScriptableObjects")]
    [SerializeField]  AreaSettingSO areaSetting;

    UnitRaceSO spawnedEnemyUnitRaceSO;
    MobStatsSO spawnedEnemyUnitSO;

    [SerializeField] HeroSO spawnedHeroSO;


    //[SerializeField] int maxObjectsInArea = 10;
    //[SerializeField] int maxLootChestsInArea = 6;
    //[SerializeField] int maxEnemyUnitsInArea = 8;


    [Header("counters just to control")]
    [SerializeField] public int spawnedEnemyUnits;
    [SerializeField] public int spawnedLootChests;
    [SerializeField] public int totalSpawnedObjects;



    GameObject spawnedUnit;
    GameObject spawnedGameObject;
    GameObject spawnedHero;


    //this is name of parent object of arena
    [SerializeField] public GameObject combatAreaSpawn;//objects spawn here

    static List<GameObject> spawnedGameObjectList = new List<GameObject>();
    static List<OreVein> oreVeinsList = new List<OreVein>();
    static List<HerbBush> herbBushList = new List<HerbBush>();

    int nameCounter = 0;
    //pool for mobs
    private IObjectPool<GameObject> spawnedMobPool;
    //default mob pool size (to start with dont need tho
    private int mobPoolDefaultCapacity;
    //max mob pool size - max enemy units
    private int mobPoolMaxSize;
    // throw an exception if we try to return an existing item, already in the pool
    [SerializeField] private bool collectionCheck = true;

    HeroSpawner heroSpawner;

    private void Awake()
    {
        heroSpawner=FindObjectOfType<HeroSpawner>();
        mobPoolMaxSize = areaSetting.maxEnemyUnitsInArea;
        //objectInfo = FindObjectOfType<ObjectInfo>();
        spawnedMobPool = new ObjectPool<GameObject>(CreateMob, OnGetFromMobPool, OnReleaseToMobPool, OnDestroyPooledMob, collectionCheck,mobPoolMaxSize);
    }
    private void Start()
    {
        SetSOsSettings();
        SpawnHeroOnCamp();
    }
    private void Update()
    {
        SpawnObjectsOnMap();
    }

    void SpawnObjectsOnMap()//this will stay as control
    {
        //GameObject spawningObject;
        if (totalSpawnedObjects < areaSetting.maxObjectsInArea)
        {
            int random = UnityEngine.Random.Range(0, 2);
            //Debug.Log(random);
            if (random == 0 && spawnedEnemyUnits < areaSetting.maxEnemyUnitsInArea)
            {
                //MobSpawned();
                spawnedMobPool.Get();
                //CreateMobInstantiate(); //old way isntantiating deleting
            }
            else if (random == 1 && spawnedLootChests < areaSetting.maxLootChestsInArea)
            {
                SpawnLootChest();//will be get from pool of chests
                
            }
            
        }
        else return;
    }
    void SpawnOreVeins() { }


    #region MobPooling
    
    private GameObject CreateMob()
    {
        GameObject spawnedMob = Instantiate(mobUnitV2);
        RandomPositionForObject(spawnedMob);

        spawnedMob.GetComponent<CharacterBuilder>().Head = spawnedEnemyUnitRaceSO.race;
        spawnedMob.GetComponent<CharacterBuilder>().Ears = spawnedEnemyUnitRaceSO.race;
        spawnedMob.GetComponent<CharacterBuilder>().Eyes = spawnedEnemyUnitRaceSO.race;
        spawnedMob.GetComponent<CharacterBuilder>().Body = spawnedEnemyUnitRaceSO.race;

        spawnedMob.GetComponent<CharacterBuilder>().Hair = "";

        spawnedMob.GetComponent<CharacterBuilder>().Rebuild();//this will reload visual

        spawnedMob.GetComponent<MobStatsAndInfo>().unitSettings = spawnedEnemyUnitSO;
        spawnedMob.GetComponent<UnitStatsAndInfoBase>().UnitSetStats();
        //SetMobTypeTag();
        //set mob type and tag
        spawnedMob.GetComponent<ObjectInfo>().SetType("EnemyUnit");
        spawnedMob.gameObject.tag = "EnemyUnit";
        spawnedMob.GetComponent<UnitTargetPicker>().tagOfEnemy = "HeroUnit";

        spawnedMob.GetComponent<UnitHealth>().objectPool = spawnedMobPool;

        return spawnedMob;
    }
    void OnReleaseToMobPool(GameObject spawnedMob)
    {//return to pool
        spawnedEnemyUnits--;
        totalSpawnedObjects--;
        spawnedMob.gameObject.SetActive(false);

    }
    void OnGetFromMobPool(GameObject spawnedMob)
    {//get from pool
        MobSpawned();
        RandomPositionForObject(spawnedMob);
        spawnedMob.gameObject.SetActive(true);
        //spawnedMob.GetComponent<UnitHealth>().Respawn();

    }
    void OnDestroyPooledMob(GameObject spawnedMob)
    {//destroy if over capcity of pool
        Destroy(spawnedMob.gameObject);
    }
    #endregion

    void SpawnObject(GameObject gameObject)
    {
        spawnedGameObject = Instantiate(gameObject);
    }

    void RandomPositionForObject(GameObject gameObject)
    {
        //this will set parent object
        gameObject.transform.parent = combatAreaSpawn.transform;

        //random place in Map relative to parent object (centre)
        float vectorX = (UnityEngine.Random.Range(-maxXaxisOfArea, maxXaxisOfArea) + combatAreaSpawn.transform.position.x);
        float vectorY = (UnityEngine.Random.Range(-maxYaxisOfArea, maxYaxisOfArea) + combatAreaSpawn.transform.position.y);
        float vectorZ = 0f;

        Vector3 spawnPointVector = new Vector3(vectorX, vectorY, vectorZ);
        //selfQuaternion  needed for vector3
        //Quaternion rotation = Quaternion.identity;

        //place where we want him
        gameObject.transform.position = spawnPointVector;
        //Debug.Log("shouldHaveSpawn " + vectorX + " " + vectorY);

        //float realX = spawnedGameObject.transform.position.x;
        //float realY = spawnedGameObject.transform.position.y;
        //Debug.Log("spawnedin "+realX +" " +realY );

        // set name and type
    }

    void SpawnLootChest()
    {
        SpawnObject(lootChest);
        RandomPositionForObject(spawnedGameObject);
        AddLootChestCounters();
    }
    public void MobSpawned()
    {
        spawnedEnemyUnits++;
        totalSpawnedObjects++;
    }
    public void MobDied()
    {
        StartCoroutine(WaitForRespawn());
        //spawnedEnemyUnits--;
        //totalSpawnedObjects--;
    }
    IEnumerator WaitForRespawn()
    { 
        yield return new WaitForSeconds(5f);
        spawnedEnemyUnits--;
        totalSpawnedObjects--;
    }
    void AddLootChestCounters()
    {
        spawnedLootChests++;
        totalSpawnedObjects++;
    }
    void AddSpawnedObjectToList()
    {
        spawnedGameObjectList.Add(spawnedUnit);
    }
    void SpawnLootCrate()
    {
        Instantiate(lootChest);
        spawnedLootChests++;
        totalSpawnedObjects++;
    }
    void SetSOsSettings()
    {
        spawnedEnemyUnitRaceSO= areaSetting.unitRaceSO;
        spawnedEnemyUnitSO= areaSetting.unitSettingSO;
    }



    void GiveMeRandomTransforms(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float x;
            float y;
            x = UnityEngine.Random.Range(-maxXaxisOfArea, maxXaxisOfArea);
            y = UnityEngine.Random.Range(-maxYaxisOfArea, maxYaxisOfArea);
            Debug.Log(x + "  " + y);
        }
    }

    #region SpawnHero
    //whole region will be removed eventually
    public void SpawnHeroOnCamp()
    {
        spawnedHero = heroSpawner.ReturnHeroV2(combatAreaSpawn.transform, heroCamp.transform);
        //heroSpawner.SpawnHero(combatAreaSpawn.transform, heroCamp.transform);
        spawnedHero.GetComponent<UnitAiHeros>().task = Task.KILLMOBS;
    }
    #endregion


    void CreateMobInstantiate()//this is our "instantiate" with all settings mob need
    {//will be discontinued when pooling is working
        SpawnObject(mobUnit);
        RandomPositionForObject(spawnedGameObject);

        //add MOB specific classes
        //OnMobSpawn?.Invoke(spawnedGameObject);
        spawnedGameObject.AddComponent<UnitAiMobs>();
        spawnedGameObject.AddComponent<DropLoot>();
        //set unit race
        //SetUnitRace();
        spawnedGameObject.GetComponent<CharacterBuilder>().Head = spawnedEnemyUnitRaceSO.race;
        spawnedGameObject.GetComponent<CharacterBuilder>().Ears = spawnedEnemyUnitRaceSO.race;
        spawnedGameObject.GetComponent<CharacterBuilder>().Eyes = spawnedEnemyUnitRaceSO.race;
        spawnedGameObject.GetComponent<CharacterBuilder>().Body = spawnedEnemyUnitRaceSO.race;
        //set unit visuals (hair, ears
        //SetUnitVisuals();
        spawnedGameObject.GetComponent<CharacterBuilder>().Hair = "";
        //set unit class, gear, weapon
        //SetUnitClass();
        spawnedGameObject.GetComponent<CharacterBuilder>().Rebuild();//this will reload visual
        //set unit stats
        //SetUnitStats();
        spawnedGameObject.GetComponent<MobStatsAndInfo>().unitSettings = spawnedEnemyUnitSO;
        spawnedGameObject.GetComponent<UnitStatsAndInfoBase>().UnitSetStats();
        //SetMobTypeTag();
        //set mob type and tag
        spawnedGameObject.GetComponent<ObjectInfo>().SetType("EnemyUnit");
        spawnedGameObject.gameObject.tag = "EnemyUnit";
        spawnedGameObject.GetComponent<UnitTargetPicker>().tagOfEnemy = "HeroUnit";
        //for counting right ammount in arena
        //MobSpawned();
    }
}
//ol old way when we used to add scripts on runtime
    /* // when we used to attach scripts on spawn on mob
    private GameObject CreateMob()//this is our "instantiate" with all settings mob need
    {
        GameObject spawnedMob = Instantiate(mobUnit);
        RandomPositionForObject(spawnedMob);

        //add MOB specific classes
        //OnMobSpawn?.Invoke(spawnedGameObject);
        spawnedMob.AddComponent<UnitAiMobs>();// ok
        spawnedMob.AddComponent<DropLoot>(); // not need for now
        spawnedMob.AddComponent<UnitDeathMobs>();
        //set unit race
        //SetUnitRace();
        spawnedMob.GetComponent<CharacterBuilder>().Head = _spawnedEnemyUnitRaceSO.race;
        spawnedMob.GetComponent<CharacterBuilder>().Ears = _spawnedEnemyUnitRaceSO.race;
        spawnedMob.GetComponent<CharacterBuilder>().Eyes = _spawnedEnemyUnitRaceSO.race;
        spawnedMob.GetComponent<CharacterBuilder>().Body = _spawnedEnemyUnitRaceSO.race;
        //set unit visuals (hair, ears
        //SetUnitVisuals();
        spawnedMob.GetComponent<CharacterBuilder>().Hair = "";
        //set unit class, gear, weapon
        //SetUnitClass();
        spawnedMob.GetComponent<CharacterBuilder>().Rebuild();//this will reload visual
        //set unit stats
        //SetUnitStats();
        spawnedMob.GetComponent<MobStatsAndInfo>().unitSettings = spawnedEnemyUnitSO;
        spawnedMob.GetComponent<UnitStatsAndInfoBase>().UnitSetStats();
        //SetMobTypeTag();
        //set mob type and tag
        spawnedMob.GetComponent<ObjectInfo>().SetType("EnemyUnit");
        spawnedMob.gameObject.tag = "EnemyUnit";
        spawnedMob.GetComponent<UnitTargetPicker>().tagOfEnemy = "HeroUnit";

        //for counting right ammount in arena
        //MobSpawned();

        spawnedMob.GetComponent<UnitHealth>().objectPool = _spawnedMobPool;
        return spawnedMob;
    }*/
   