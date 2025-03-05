using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GatheringResourcesSpawner : MonoBehaviour
{
    InputInfo inputInfo;
    SpawningHelperScripts spawningHelperScripts;

    private IObjectPool<GameObject> oreVeinPool;
    int oreVeinPoolMaxSize;
    bool oreVeinCollectionCheck;
    [SerializeField] GameObject oreVein;


    private IObjectPool<GameObject> herbBushPool;
    int herbBushPoolMaxSize;
    bool herbBushPoolCollectionCheck;
    [SerializeField] GameObject herbBush;

    private void Awake()
    {
        inputInfo = GetComponent<InputInfo>();
        spawningHelperScripts = GetComponent<SpawningHelperScripts>();

        oreVeinPool = new ObjectPool<GameObject>(CreateVein, OnGetFromMaterialSourcePool, OnReleaseToMaterialSourcePool,OnDestroyPooledMaterialSource,oreVeinCollectionCheck,oreVeinPoolMaxSize);
        herbBushPool = new ObjectPool<GameObject>(CreateBush, OnGetFromMaterialSourcePool, OnReleaseToMaterialSourcePool, OnDestroyPooledMaterialSource, herbBushPoolCollectionCheck, herbBushPoolMaxSize);
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        oreVeinPool.Get();
    }



    private GameObject CreateVein()
    {
        GameObject spawnedVein = Instantiate(oreVein);
        var veinMainClass = spawnedVein.GetComponent<MaterialSource>();
        veinMainClass.resourceSO = inputInfo.arenaSetting.oreVeinSO;
        veinMainClass.SetMiniPictures();

        return spawnedVein;
    }
    private GameObject CreateBush() 
    {
        GameObject spawnedBush = Instantiate(herbBush);
        var bushMainClass = spawnedBush.GetComponent<MaterialSource>();
        bushMainClass.resourceSO = inputInfo.arenaSetting.herbBushSO;
        bushMainClass.SetMiniPictures();

        return spawnedBush;
    }

    void OnGetFromMaterialSourcePool(GameObject oreVein)
    {
        oreVein.SetActive(true);
    }

    void OnReleaseToMaterialSourcePool(GameObject oreVein)
    {
        oreVein.SetActive(false);
    }
    void OnDestroyPooledMaterialSource(GameObject oreVein)
    { 
        Destroy(oreVein);
    }
}
