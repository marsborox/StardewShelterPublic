using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using static ObjectSpawner;


public class HeroSpawner : MonoBehaviour
{//this class is for spawning hero and cheating stuff on him for testing purposes

    [SerializeField] GameObject _heroUnit;
    [SerializeField] GameObject _heroUnitV2;
    [SerializeField] GameObject _heroCamp;
    [SerializeField] GameObject _baseAreaSpawn;
    [SerializeField] HeroSO _spawnedHeroSO;//must adjust


    [SerializeField] GameObject _basePortal;
    [SerializeField] GameObject _baseArea;
    [SerializeField] GameObject _travelLimbo;
    

    GameObject spawnedHero;
    // Start is called before the first frame update

    public delegate void SpawnEvent(GameObject gameObject);

    public event SpawnEvent OnHeroSpawn;

    public GameObject arenas;
    //delegate in objectSpawner
    

    private void Awake()
    {
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        //OnMobSpawn += AddClassAiMobs;
        //OnHeroSpawn += AddClassHeros;
    }
    private void OnDisable()
    {
        //OnMobSpawn -= AddClassAiMobs;
        //OnHeroSpawn -= AddClassHeros;
    }


    public void SpawnHeroOnCamp()
    {
        SpawnHeroV2(_baseAreaSpawn.transform, _heroCamp.transform);
    }
    public void SpawnHeroV2(Transform parentOfSpawn, Transform positionOfSpawn)
    {
        spawnedHero = Instantiate(_heroUnitV2);

        spawnedHero.GetComponent<HeroStatsAndInfo>().unitSettings = _spawnedHeroSO;
        spawnedHero.GetComponent<HeroStatsAndInfo>().UnitSetStats();

        spawnedHero.GetComponent<HeroTravel>().basePortal = _basePortal;
        spawnedHero.GetComponent<HeroTravel>().travelLimbo = _travelLimbo;
        spawnedHero.GetComponent<HeroTravel>().baseArea = _baseArea;

        spawnedHero.GetComponent<ObjectInfo>().SetType("HeroUnit");
        spawnedHero.gameObject.tag = "HeroUnit";
        spawnedHero.GetComponent<UnitTargetPicker>().tagOfEnemy = "EnemyUnit";
        spawnedHero.transform.parent = parentOfSpawn;
        spawnedHero.transform.position = positionOfSpawn.position;
        //SetHeroStats();
        spawnedHero.GetComponent<UnitAiHeros>().task = Task.IDLE;
    }

    public GameObject ReturnHeroV2(Transform parentOfSpawn, Transform positionOfSpawn)
    {

        spawnedHero = Instantiate(_heroUnitV2);

        spawnedHero.GetComponent<HeroStatsAndInfo>().unitSettings = _spawnedHeroSO;
        spawnedHero.GetComponent<HeroStatsAndInfo>().UnitSetStats();

        spawnedHero.GetComponent<HeroTravel>().basePortal = _basePortal;
        spawnedHero.GetComponent<HeroTravel>().travelLimbo = _travelLimbo;
        spawnedHero.GetComponent<HeroTravel>().baseArea = _baseArea;

        spawnedHero.GetComponent<ObjectInfo>().SetType("HeroUnit");
        spawnedHero.gameObject.tag = "HeroUnit";
        spawnedHero.GetComponent<UnitTargetPicker>().tagOfEnemy = "EnemyUnit";
        spawnedHero.transform.parent = parentOfSpawn;
        spawnedHero.transform.position = positionOfSpawn.position;
        //SetHeroStats();
        spawnedHero.GetComponent<UnitAiHeros>().task = Task.IDLE;

        return spawnedHero;
    }
    void AddClassHeros(GameObject gameObject)
    {
        gameObject.AddComponent<UnitAiHeros>();
        gameObject.AddComponent<BackPack>();
        gameObject.AddComponent<UnitEquipment>();
    }
    void SetHeroStats()
    {
        //temp method for testing will be removed
        spawnedHero.GetComponent<HeroStatsAndInfo>().unitSettings = _spawnedHeroSO;
        spawnedHero.GetComponent<UnitStatsAndInfoBase>().UnitSetStats();
    }
}
    /*
    void SpawnHeroOnCampWInput()
    {
        SpawnHero(_baseArea.transform, _heroCamp.transform);
    }
    public void SpawnHero(Transform parentOfSpawn, Transform positionOfSpawn)
    {
        spawnedHero = Instantiate(_heroUnit);

        //OnHeroSpawn?.Invoke(spawnedHero);
        //add hero classes
        //settings stats must be on top or he will have 0 hp wtf??????
        spawnedHero.GetComponent<HeroStatsAndInfo>().unitSettings = _spawnedHeroSO;// *************will replace
        spawnedHero.GetComponent<HeroStatsAndInfo>().UnitSetStats();//**************fix w inherited class


        spawnedHero.AddComponent<BackPack>();
        spawnedHero.AddComponent<UnitEquipment>();
        spawnedHero.AddComponent<HeroTravel>();

        spawnedHero.AddComponent<UnitDeathMobs>();

        spawnedHero.GetComponent<HeroTravel>().basePortal = _basePortal;
        spawnedHero.GetComponent<HeroTravel>().travelLimbo = _travelLimbo;
        spawnedHero.GetComponent<HeroTravel>().baseArea = _baseArea;

        spawnedHero.AddComponent<HeroTaskSequencer>();
        spawnedHero.AddComponent<UnitAiHeros>();//perhaps after all other classes are added so we can acess them directly

        spawnedHero.GetComponent<ObjectInfo>().SetType("HeroUnit");
        spawnedHero.gameObject.tag = "HeroUnit";
        spawnedHero.GetComponent<UnitTargetPicker>().tagOfEnemy = "EnemyUnit";
        spawnedHero.transform.parent = parentOfSpawn;
        spawnedHero.transform.position = positionOfSpawn.position;
        SetHeroStats();
        spawnedHero.GetComponent<UnitAiHeros>().task = Task.IDLE;
    }*/

/*
    public GameObject ReturnHero(Transform parentOfSpawn, Transform positionOfSpawn)
    {
        spawnedHero = Instantiate(_heroUnit);

        //OnHeroSpawn?.Invoke(spawnedHero);
        //add hero classes
        spawnedHero.AddComponent<UnitAiHeros>();//perhaps after all other classes are added so we can acess them directly
        //settings stats must be on top or he will have 0 hp wtf??????
        //unitaiheros ok
        spawnedHero.GetComponent<HeroStatsAndInfo>().unitSettings = _spawnedHeroSO;
        spawnedHero.GetComponent<HeroStatsAndInfo>().UnitSetStats();

        spawnedHero.AddComponent<BackPack>();
        spawnedHero.AddComponent<UnitEquipment>();
        spawnedHero.AddComponent<HeroTravel>();


        spawnedHero.GetComponent<HeroTravel>().basePortal = _basePortal;
        spawnedHero.GetComponent<HeroTravel>().travelLimbo = _travelLimbo;
        spawnedHero.GetComponent<HeroTravel>().baseArea = _baseArea;

        spawnedHero.AddComponent<HeroTaskSequencer>();


        spawnedHero.GetComponent<ObjectInfo>().SetType("HeroUnit");
        spawnedHero.gameObject.tag = "HeroUnit";
        spawnedHero.GetComponent<UnitTargetPicker>().tagOfEnemy = "EnemyUnit";
        spawnedHero.transform.parent = parentOfSpawn;
        spawnedHero.transform.position = positionOfSpawn.position;
        SetHeroStats();
        spawnedHero.GetComponent<UnitAiHeros>().task = Task.IDLE;
        return spawnedHero;
    }*/