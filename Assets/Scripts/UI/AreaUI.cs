using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using Object = UnityEngine.Object;

public class AreaUI : DisplayAreasUI/*MonoBehaviour*/
{
    /*
    [SerializeField] GameObject areas;
    [SerializeField] Button areaButton;
    
    // Start is called before the first frame update
    MainUI mainUI;
    private void Awake()
    {
        mainUI = GetComponent<MainUI>();
    }
    void Start()
    {
        
        //DisplayAreaButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        DisplayAreaButtons();
        
    }
    private void OnDisable()
    {//*should use separate class kill all buttons
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(transform.GetChild(i).gameObject);
        }
    }
    void DisplayAreaButtons()
    {

        int childCount= areas.transform.childCount;
        //foreach Gameobject area in areas create button with method
        for (int i=0; i<childCount; i++) 
        {
            Button spawnedButton = Instantiate(areaButton);
            spawnedButton.transform.parent = this.transform;
            GameObject area = areas.gameObject.transform.GetChild(i).gameObject;
            spawnedButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text=area.name;
            spawnedButton.gameObject.GetComponent<AreaButton>().destination=area;
        }
    }
    void AreaButtonMethod()
    {//this will be completely different
        GameObject passedDestination=areas;//this will be set by button i suppose
        mainUI.activeUnit.GetComponent<UnitAiHeros>().status=Status.TRAVELING;
        mainUI.activeUnit.GetComponent<HeroTravel>().destination = passedDestination;
        //pass destination area this
        //pass enum what to do nextTask
    }

    public void AreasDisplayed()
    {
        Debug.Log("Areas just Displayed");
    }*/
}
