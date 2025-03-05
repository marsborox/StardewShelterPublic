using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class UnitStatsAndInfoBase : MonoBehaviour
{
    public string taskString;//both
    public string combatActivityString;//both


    public int range;//hero from item
    public int damage;//hero from item
    public float attackSpeed;//hero from item
    public int health;//hero from items

    
    //public UnitSO unitSettings;
    
    void Start()
    {
        
    }


    public virtual void UnitSetStats()
    {/*
        range = unitSettings.range;
        damage = unitSettings.damage;
        attackSpeed = unitSettings.attackSpeed;
        health = unitSettings.health;*/
    }

}
