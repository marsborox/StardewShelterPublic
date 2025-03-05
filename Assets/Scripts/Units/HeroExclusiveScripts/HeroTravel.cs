using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TravelSwitch {NOTTRAVELING, GOINGTOPORTAL,TRAVELLIMBO }
public class HeroTravel : MonoBehaviour
{
    CombatStatus combatStatus;
    
    public TravelSwitch travelSwitch;
    public GameObject destinationArea;
    GameObject _nextHop;
    public GameObject basePortal;
    public GameObject travelLimbo;
    public GameObject baseArea;
    public GameObject localCamp;
    GameObject parentArea;
    GameObject _localPortal;

    UnitMovement unitMovement;
    UnitAiBase unitAiBase;
    UnitAiHeros unitAiHeros;
    UnitCombat unitCombat;
    TasksInBase tasksInBase;
   
    public float travellingTime;
    float touchDistance;
    public bool traveling=false;

    public delegate void ArrivedToDestination();
    public ArrivedToDestination arrivedToDestination;
    // Start is called before the first frame update

    //make rangefinder class for method in range in combat***
    // must solve problem when travel initiated to clear target -- seems this is fixed
    private void Awake()
    {
        unitMovement = GetComponent<UnitMovement>();
        //unitAiBase = GetComponent<UnitAiBase>();
        unitAiHeros = GetComponent<UnitAiHeros>();
        unitCombat =GetComponent<UnitCombat>();
        tasksInBase = GetComponent<TasksInBase>();
    }
    void Start()
    {
        travellingTime = 5f;
        touchDistance = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TravellingSwitch()
    { 
        switch (travelSwitch) 
        {
            case TravelSwitch.NOTTRAVELING:
                {
                    ClearCombatVariables();//wont help
                    FindLocalPortal();
                    travelSwitch = TravelSwitch.GOINGTOPORTAL;
                    break;
                }
                case TravelSwitch.GOINGTOPORTAL: 
                {
                    unitMovement.Move(_localPortal);
                    if (Vector2.Distance(this.transform.position, _localPortal.transform.position) < touchDistance)//we have reached portal
                    {
                        gameObject.transform.parent = travelLimbo.transform;
                        gameObject.transform.position = travelLimbo.transform.position;
                        StartCoroutine(TravelRoutine());//msut fix eventually//seems working
                        travelSwitch = TravelSwitch.TRAVELLIMBO;
                    }
                    break;
                }

                case TravelSwitch.TRAVELLIMBO: 
                {
                    break;
                }
        }
    }
    //when travel done trigger event to AI with next activity
    
    void FindLocalPortal()
    {

        _localPortal = gameObject.transform.parent.transform.parent.GetComponentInChildren<Portal>().gameObject;
    }

    void ClearCombatVariables()
    {
        unitCombat.target = null;
        unitCombat.attacker = null;
        unitCombat.inCombat = false;
    }
    public void InitiateTravel(GameObject destination)
    { 
        destinationArea = destination;
        unitAiHeros.travel = true;
    }
    public void ReturnHome()
    {
        InitiateTravel(baseArea);
        /*
        destinationArea = baseArea;
        unitCombat.combatStatus = CombatStatus.TRAVELING;
        */
        //arrivedToDestination+= tasksInBase.UnloadBackPackInWarehouse;
        unitAiHeros.task = Task.IDLE;
        
    }
    IEnumerator TravelRoutine()
    {
        yield return new WaitForSeconds(travellingTime);


        // combatStatus = CombatStatus.NOTCOMBAT; *** fix over event
        gameObject.transform.parent = destinationArea.GetComponentInChildren<AreaSpawn>().transform;
        gameObject.transform.position = destinationArea.GetComponentInChildren<Portal>().transform.position;

        travelSwitch = TravelSwitch.NOTTRAVELING;
        arrivedToDestination?.Invoke();
        
    }

    /*
    void FromLimboToArea()
    {
        gameObject.transform.parent = destinationArea.GetComponent<AreaSpawn>().gameObject.transform;
        localCamp = destinationArea.GetComponent<Camp>().gameObject;
        parentArea = destinationArea;
        gameObject.transform.position = localCamp.transform.position;
        unitCombat.combatStatus = CombatStatus.NOTCOMBAT;
        travelSwitch = TravelSwitch.NOTTRAVELING;
    }
    void FromLimboToBase()
    {
        gameObject.transform.position = basePortal.transform.position;
        gameObject.transform.parent = baseArea.transform;
        unitCombat.combatStatus = CombatStatus.NOTCOMBAT;
        travelSwitch = TravelSwitch.NOTTRAVELING;
    }*/
    public void PrintTravel(string stringToPrint)
    {
        Debug.Log("Traveling to " + stringToPrint);
    }
    public void TestPrint()
    {
        Debug.Log("shit works");
    }
}
