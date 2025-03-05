using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStatsAndInfo : UnitStatsAndInfoBase
{

    public MobStatsSO unitSettings;

    public Item lootItem;
    public override void UnitSetStats()
    {
        range = unitSettings.range;
        damage = unitSettings.damage;
        attackSpeed = unitSettings.attackSpeed;
        health = unitSettings.health;
        lootItem = unitSettings.lootItem;
    }
}
