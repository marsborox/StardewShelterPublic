using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInfo : MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField] public AreaSettingSO arenaSetting;

    UnitRaceSO spawnedEnemyUnitRaceSO;
    MobStatsSO spawnedEnemyUnitSO;

    [SerializeField] HeroSO spawnedHeroSO;

    /*//we will take it from AreaSO
    public SO_OreVein oreVeinSO;
    public SO_HerbBush herbBushSO;
    */


}
