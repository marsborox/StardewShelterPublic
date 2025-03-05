using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLootAndXp : MonoBehaviour
{
    MobStatsAndInfo mobStatsAndInfo;
    UnitCombat unitCombat;
    Item _lootItem;
    private void Awake()
    {
        mobStatsAndInfo = GetComponent<MobStatsAndInfo>();
        unitCombat = GetComponent<UnitCombat>();
    }
    void Start()
    {
        _lootItem = mobStatsAndInfo.unitSettings.lootItem;
        /*if (_lootItem == null)
        { Debug.Log("lootItem is null"); }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropLoot()
    {
        unitCombat.attacker.GetComponent<BackPack>().AddItemToBackPack(_lootItem);
    }
}
