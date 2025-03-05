using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeathMobs : UnitDeathBase
{
    //UnitStatsAndInfoBase unitStatsAndInfo;
    DropLootAndXp dropLootAndXp;
    Item _loot;
    private void Awake()
    {
        base.Awake();
        //unitStatsAndInfo = GetComponent<UnitStatsAndInfoBase>();
        dropLootAndXp = GetComponent<DropLootAndXp>();
        //unitCombat = GetComponent<UnitCombat>();
        //unitHealth = GetComponent<UnitHealth>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public override void OnDeath()
    {
        unitHealth.healthState = HealthState.DEAD;
        unitCombat.combatStatus = CombatStatus.DEAD;
        gameObject.tag = ("DeadEnemyUnit");
        //Debug.Log("I am dying");
        
        dropLootAndXp.DropLoot();
        unitCombat.attacker.GetComponent<UnitCombat>().TargetDied();
        //DropLoot**********************************
        unitCombat.target = null;
        unitCombat.attacker = null;
        unitCombat.inCombat = false;
        this.characterAnimation.Die();
        StopAllCoroutines();
        StartCoroutine(Despawn());
    }
    public IEnumerator Despawn()
    {
        yield return new WaitForSeconds(unitHealth.despawnTime);

        //Destroy(this.gameObject);

        //gameObject.transform.parent.transform.parent.GetComponent<ObjectSpawner>().MobDied();

        /*
        if (unitHealth == null)
        { Debug.Log("unitHealth null"); }
        if (!(unitHealth == null))
        { Debug.Log("unitHealth not null"); }

        if (unitHealth.spawnedMobPool == null)
        {
            Debug.Log("spawn pool null WTF???");
        }*/
        unitHealth.spawnedMobPool.Release(gameObject);

    }
    void DropLoot()
    {
        
    }
    void GiveXP()
    { 
        
    }
}
