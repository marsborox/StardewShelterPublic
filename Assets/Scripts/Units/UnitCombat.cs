using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Assets.PixelFantasy.PixelHeroes.Common.Scripts.ExampleScripts;

using UnityEngine;

using static UnityEngine.GraphicsBuffer;

public enum CombatStatus { NOTCOMBAT, COMBAT, RESTING, MOVING, DEAD, OTHER,TRAVELING }
public class UnitCombat : MonoBehaviour
{
    public CombatStatus combatStatus;
    CharacterAnimation characterAnimation;
    
    UnitStatsAndInfoBase unitStatsAndInfo;
    UnitMovement unitMovement;
    ObjectInfo objectInfo;
    UnitHealth unitHealth;
    UnitTargetPicker unitTargetPicker;
    UnitAiBase unitAiBase;


    [SerializeField] public GameObject target;

    public bool attackOnCD;

    public bool inCombat;
    public bool targetInRange;

    //public GameObject target;
    public GameObject attacker;//who attacked us

    public delegate void UnderAttack();
    public UnderAttack Attacked;
    
    private void Awake()
    {
        unitHealth = GetComponent<UnitHealth>();
        characterAnimation = GetComponent<CharacterAnimation>();
        objectInfo = GetComponent<ObjectInfo>();
        unitStatsAndInfo = GetComponent<UnitStatsAndInfoBase>();
        unitMovement = GetComponent<UnitMovement>();
        unitTargetPicker = GetComponent<UnitTargetPicker>();
        unitAiBase = GetComponent<UnitAiBase>();
    }
    void Start()
    {
        inCombat = false;
        attackOnCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(combatActivity.ToString());
        unitStatsAndInfo.combatActivityString=combatStatus.ToString();
    }
    /*public void Attack2(GameObject target)
    {//discontinued
        //target.gameObject.GetComponent<UnitCombat>().TakeDamage(unitStatsAndInfo.damage, this.gameObject);
        characterAnimation.Slash();
    }*/

    public void TargetDied()
    {
        //Debug.Log("target died");
        target = null;
        attacker = null;
        inCombat = false;
        combatStatus = CombatStatus.NOTCOMBAT;
        if (objectInfo.type == "EnemyUnit")
        {
            combatStatus = CombatStatus.NOTCOMBAT;
            unitHealth.healthCurrent = unitHealth.healthMax;
        }
    }
    void CheckIfTargetInRange()
    {
        targetInRange = Vector2.Distance(this.transform.position, target.transform.position) < unitStatsAndInfo.range;
    }

    public void KillingEnemies()
    {
        //Debug.Log("Killing ENemies Method started");
        if (target == null)
        {
           //Debug.Log("target is NULL");
            unitTargetPicker.FindClosestEnemy();
            //Debug.Log("arenacombat state p.1 ok");
            target = unitTargetPicker.combatTarget;
            //Debug.Log($"targetpicker target"+ unitTargetPicker.target.name);
            //Debug.Log($"Target is: "+ target.name);
            //target.gameObject.GetComponent<ObjectInfo>().TellInfo();
        }
        if (!(target == null))
        {
            //this is AttackTargetInRangeOrMoveTOTarget(); but done better
            AttackOrMoveToTarget();
        }
    }
    public void TakeDamage(int damage, GameObject source)
    {
        attacker = source;
        unitHealth.healthCurrent -= damage;
        if (target == null)
        {
            //Debug.Log("Target was null so we assign");
            target = attacker;
        }
        if (!inCombat)
        { 
            inCombat = true;
            unitAiBase.IfImIdleMakeMeCombat();
            //Attacked?.Invoke();
        }
    }
    public void Combat()
    {
        //Debug.Log("combat initiated");
        if (target == null)
        {
            target = attacker;
        }
        //Debug.Log("will move to target");
        AttackOrMoveToTarget();
    }
    public void AttackOrMoveToTarget() //move to combat
    {
        unitMovement.TurnCorrectDirection(target.transform);
        CheckIfTargetInRange();
        if (target != null && !attackOnCD)
        {
            if (targetInRange)
            {
                combatStatus = CombatStatus.COMBAT;
                AttackHit(target);
            }
            else
            {
                combatStatus = CombatStatus.MOVING;
                unitMovement.Move(target);
            }
        }
    }
    public void AddUnitAiBase()
    {
        unitAiBase = GetComponent<UnitAiBase>();
    }
    public void AttackHit(GameObject target)
    {//attack pre animation
        //do damage
        //StartCoroutine(Wait());
        //unitAiBase.activity = Activity.COMBAT;// *********************************
        //Debug.Log("DOING ATTACK HIT");
        attackOnCD = true;// **********************************
        target = target;//problem here
        //Debug.Log("local target set");
        //Debug.Log(target);
        target.gameObject.GetComponent<UnitCombat>().attacker = this.gameObject; //mabye problem here too
        
        
        target.gameObject.GetComponent<UnitAiBase>().IfImIdleMakeMeCombat(); //********************

        inCombat = true;
        characterAnimation.Idle();
        characterAnimation.Slash();

        //target.gameObject.GetComponent<UnitCombat>().TakeDamage(unitStatsAndInfo.damage); //***********done post animation
        //unitAi.target.gameObject.GetComponent<UnitHealth>().TakeDamage();
        //unitAi.activity= Activity.IDLE;
    }
    public void AttackAnimationEvent()
    {
        target.gameObject.GetComponent<UnitCombat>().TakeDamage(unitStatsAndInfo.damage,this.gameObject);
        target = null;
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackCooldown()
    {
        //after slash is performed
        
        yield return new WaitForSeconds(unitStatsAndInfo.attackSpeed);
        attackOnCD = false; // *********************************
        //unitAi.activity = Activity.IDLE;
    }
}
