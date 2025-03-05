using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AreaSetting", fileName = "New Area")]

public class AreaSettingSO : ScriptableObject
{
    [SerializeField] public int maxObjectsInArea;
    [SerializeField] public int maxLootChestsInArea;
    [SerializeField] public int maxEnemyUnitsInArea;
    [SerializeField] public int maxOreVeinsInArea;
    [SerializeField] public int maxHerbBushesInArea;


    /* //is done in oreVein
    [SerializeField] public Item oreMaterial;
    [SerializeField] public Item herbMaterial;*/

    [SerializeField] public SO_GatheringMaterial oreVeinSO;
    [SerializeField] public SO_GatheringMaterial herbBushSO;


    [Header("SOs of unit settings")]
    public UnitRaceSO unitRaceSO;
    public MobStatsSO unitSettingSO;
}
