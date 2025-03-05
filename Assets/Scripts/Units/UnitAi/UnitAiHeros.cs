using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

//only heros will need this
public enum Task { IDLE, LOCATIONACTIVITY, COMBAT, ARENARESOURCE, MOVEMENT, RANDOMAUTOMOVE, KILLMOBS, OTHER,FARMMATS }
public enum Goal { REACHLEVEL, FULLINVENTORY, EMPTYINVENTORY}

public class UnitAiHeros : UnitAiBase
{
    public Task task;
    
    public string nextTask;

    public GameObject campInArea;
    public GameObject portalInHome;

    public bool travel;
    public bool repeatTask; // will do enum to string and string to enum
    public bool performUnload;

    HeroTravel heroTravel;
    BackPack backPack;
    TasksInBase tasksInBase;
    FarmMats farmMats;
    public void Awake()
    {
        base.Awake();
        heroTravel = GetComponent<HeroTravel>();
        backPack = GetComponent<BackPack>();
        tasksInBase = GetComponent<TasksInBase>();
        farmMats = GetComponent<FarmMats>();
    }
    void Start()
    {
        performUnload = false;
    }

    // Update is called once per frame
    void Update()
    {
        // quite fucked up and broken must spend more time unfucking it
        //main issue is if its killing mobs it should just "fuck it, kill mobs then travel"
        //not moonwalk on one space so task switch should be higher priority 
        //until we are in combat
        //mabye
        //Debug.Log(task.ToString());
        //TaskSwitch();

        
        unitStatsAndInfo.taskString = task.ToString();
        if (unitCombat.inCombat)
        {
            unitCombat.KillingEnemies();
        }
        else if (travel || unitCombat.combatStatus == CombatStatus.TRAVELING)
        {
            heroTravel.TravellingSwitch();

            return;
        }
        else if (backPack.backPackFull)
        {
            if (!performUnload)
            {
                tasksInBase.unloadBackPackAtHome = UnloadBackPackAtHome.INITIATED;
                performUnload = true;
            }
            tasksInBase.ReturnHomeAndUnloadBackPack();

            return;
        }
        else
        {
            //if we want travel do travel else do task
            TaskSwitch();

        }
    }
    
    private void OnEnable()
    {
        base.OnEnable();
        heroTravel.arrivedToDestination += ArrivedToDestination;
    }
    private void OnDisable()
    {
        base.OnDisable();
        heroTravel.arrivedToDestination -= ArrivedToDestination;//some null reference smalltalk
        //but only when stopped game wtf???
    }
    public override string GetActivity()
    {
        return Enum.GetName(typeof(Task), task);
    }
    void TaskSwitch()
    {
        
        switch (task)
        {
            case Task.KILLMOBS:
                {
                    if (unitCombat.combatStatus == CombatStatus.RESTING)
                    {
                        unitHealth.Resting2();
                    }
                    else if ((unitHealth.healthState == HealthState.LOW) && !unitCombat.inCombat)
                    {
                        unitHealth.Resting2();
                        //unitCombat.combatActivity = CombatActivity.RESTING;
                    }
                    else
                    {
                       /* if (unitTargetPicker.enemyListEmpty = false)//if there are no enemies nearby
                        { break; }*/
                            unitCombat.KillingEnemies();
                        }
                    break;
                    //if backpack full return home --> Traveling
                }

            case Task.OTHER:
                {
                    break;
                }
            case Task.FARMMATS:
                {
                    //Debug.Log("FarmingMats");
                    break;
                }
            case Task.IDLE:
                {
                    characterAnimation.Idle();
                    break;
                }
        }
    }

    public void OnTaskChange()
    { 
        unitHealth.StopResting();
        characterAnimation.Idle();
    }
    public void ArrivedToDestination()
    {
        unitCombat.combatStatus = CombatStatus.NOTCOMBAT;
        travel = false;
        characterAnimation.Idle();
        //Debug.Log("uniAiHeroes.arrived to destination");
    }



}
