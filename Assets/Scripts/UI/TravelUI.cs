using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class TravelUI : DisplayAreasUI
{
   
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnEnable()
    {
        DisplayAreaButtons();

    }

    public void DisplayAreaButtons()
    {

        int areasCount = _areas.transform.childCount;
        //foreach Gameobject area in areas create button with method
        for (int i = 0; i < areasCount; i++)
        {
            Button spawnedButton = Instantiate(_areaButtonPrefab);
            spawnedButton.transform.parent = this.transform;
            GameObject area = _areas.gameObject.transform.GetChild(i).gameObject;
            spawnedButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = area.name;
            spawnedButton.gameObject.GetComponent<AreaButton>().destination = area;
            InitializeButton(spawnedButton);
        }
    }
    void InitializeButton(Button button)
    {
        button.onClick.AddListener(delegate
        {
            TravelButtonMethod(button);
        });
    }
    void TravelButtonMethod(Button button)
    {

        //picked hero set destination, run method from travel class

        /*
        Debug.Log(button.GetComponent<AreaButton>().destination.name);
        if (mainUI.activeUnit == null)
        { Debug.Log("hero Null"); }
        else { Debug.Log("hero not null"); }
        //some problem in herotravel script not printing method
        mainUI.activeUnit.GetComponent<HeroTravel>().TestPrint();
        */
        mainUI.activeUnit.GetComponent<HeroTravel>().PrintTravel(button.GetComponent<AreaButton>().destination.name);
        //mainUI.activeUnit.GetComponent<HeroTravel>().destinationArea = (button.GetComponent<AreaButton>().destination);
        //mainUI.activeUnit.GetComponent<UnitAiHeros>().travel=true;

        mainUI.activeUnit.GetComponent<HeroTravel>().InitiateTravel(button.GetComponent<AreaButton>().destination);
        //var activeHeroTravel = mainUI.activeUnit.GetComponent<HeroTravel>();
        //activeHeroTravel.destinationArea = (button.GetComponent<AreaButton>().destination);

        mainUI.CloseUI(this.gameObject, mainUI.travelButton);
        //different class
        //mainUI.activeUnit.GetComponent<UnitAiHeros>().task = Task.KILLMOBS;
    }
}
