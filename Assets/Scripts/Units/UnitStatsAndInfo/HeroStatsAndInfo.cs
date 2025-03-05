using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatsAndInfo : UnitStatsAndInfoBase
{
    public int backPackSize;


    public HeroSO unitSettings;
    
    //must do some rework on stats and info
    //ccheck which stats get used where
    //hero does not need loot unit does not neet backpack cap....

    void Start()
    {

    }


    public override void UnitSetStats()
    {
        
        range = unitSettings.range;
        damage = unitSettings.damage;
        attackSpeed = unitSettings.attackSpeed;
        health = unitSettings.health;
        backPackSize=unitSettings.backPackSize;

    }
}
