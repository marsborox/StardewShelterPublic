using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [Header("BasicInfo")]
    public TextMeshProUGUI health;
    public TextMeshProUGUI mana;
    public TextMeshProUGUI energy;
    [Header("Stats")]
    public TextMeshProUGUI name;
    public TextMeshProUGUI xp;
    public TextMeshProUGUI task;
    public TextMeshProUGUI combatState;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI range;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI attackSpeed;

    [Header("HeroButtons")]
    [SerializeField] public Button equipmentButton;
    //public bool equipmentOn;
    [SerializeField] public GameObject equipmentGUI;

    [SerializeField] public Button backpackButton;
    //public bool backpackOn;
    [SerializeField] public GameObject backpackGUI;

    [SerializeField] public Button tasksButton;
    //public bool tasksOn;
    [SerializeField] public GameObject tasksGUI;

    [SerializeField] public Button testButton;
    //public bool testOn;
    [SerializeField] public GameObject testGUI;

    //enables areasUI with SendToADventureButtons
    [SerializeField] public Button travelButton;

    [SerializeField] public GameObject travelGUI;

    //public bool travelOn;
    [SerializeField] public GameObject behaviorGUI;

    [SerializeField] public Button behaviorButton;

    [SerializeField] public Button returnHome;

    [SerializeField] Button returnHomeAndUnload;

    [Header("ManagementButtons")]

    [SerializeField] public GameObject wareHouseGUI;
    [SerializeField] public Button wareHouseButton;

    [SerializeField] public Button areasButton;
    //public bool areasOn;
    [SerializeField] public GameObject areasGUI;



    Color32 unpressedColor = new Color32(255, 255, 255, 255);
    Color32 pressedColor = new Color32(200, 200, 200, 255);

    public GameObject activeUnit;

    public bool tempBoolean;

    UnitHealth unitHealth;
    UnitStatsAndInfoBase unitStatsAndInfo;

    GameObject uiComponent;
    AreaUI areaUI;

    bool _matKillAreaBool;
    Button _matKillAreaButton;


    private void Awake()
    {
        areaUI=GetComponent<AreaUI>();
        //gearButton = transform.GetComponent<Button>();
    }
    private void Start()
    {

        #region HeroButtons
        //eq
        InitiateButton(/*equipmentOn,*/ equipmentButton, equipmentGUI);
        InitiateButton(behaviorButton,behaviorGUI);
        InitiateButton(/*backpackOn,*/ backpackButton, backpackGUI);
        InitiateButton(/*testOn, */testButton, testGUI);
        InitiateButton(/*tasksOn, */tasksButton, tasksGUI);
        InitiateButton(travelButton, travelGUI);
        InitiateButton(returnHome, ReturnHome);
        InitiateButton(returnHomeAndUnload, ReturnHomeAndUnloadBackPack);
        #endregion

        #region Management Buttons
        //areas
        InitiateButton(/*areasOn,*/ areasButton, areasGUI);
        InitiateButton(wareHouseButton,wareHouseGUI);

        #endregion
    }
    void Update()
    {
        #region activeUnit set info on screen
        if (activeUnit != null)
        {
            health.SetText(activeUnit.GetComponent<UnitHealth>().healthCurrent + " / " + activeUnit.GetComponent<UnitHealth>().healthMax.ToString());


            //task.SetText(activeUnit.GetComponent<UnitStatsAndInfo>().taskString);

            combatState.SetText(activeUnit.GetComponent<UnitStatsAndInfoBase>().combatActivityString);

            range.SetText(activeUnit.GetComponent<UnitStatsAndInfoBase>().range.ToString());
            damage.SetText(activeUnit.GetComponent <UnitStatsAndInfoBase>().damage.ToString());
            attackSpeed.SetText(activeUnit.GetComponent<UnitStatsAndInfoBase>().attackSpeed.ToString());
            //attackSpeed.SetText(activeUnit.GetComponent<UnitAiBase>().attackSpeed.ToString());

            string activityText = activeUnit.GetComponent<UnitAiBase>().GetActivity();
            
            task.SetText(activityText);// like newest kind of stuff
        }
        #endregion
    }

    public void RefreshUI()
    {
        backpackGUI.GetComponent<BackPackUI>().ReloadSlots();

        //TaskUIClose();
        CloseUI(tasksGUI,tasksButton);
        ChangeTextOnTasksButton();

        CloseUI(travelGUI,travelButton);

        //mana
        //energy
        //name
        //xp
        //activity.SetText(activeUnit.);
    }
    void InitiateButton(/*bool boolUI,*/Button button ,GameObject gUIPanel)
    {
        button.onClick.AddListener(delegate
        {
            
            ButtonMethod(/*boolUI,*/ button, gUIPanel);
            //boolUI = tempBoolean;
            gUIPanel.SetActive(tempBoolean);
        });
        //boolUI = false;
        gUIPanel.SetActive(false);
    }
    public void InitiateButton(Button button, Action method)
    {
        button.onClick.AddListener(delegate
        {
            method();
        });
        //boolUI = false;
        
    }
    public void ButtonMethod(/*bool boolUI,*/ Button button, GameObject gUIPanel)
    {
        if (!gUIPanel.activeSelf)
        {
            tempBoolean = true;
            button.GetComponent<Image>().color = pressedColor;
            //uiComponent.SetActive(boolUI);
        }
        else
        {
            tempBoolean = false;
            button.GetComponent<Image>().color = unpressedColor;
            //uiComponent.SetActive(boolUI);
        }
    }

    public void CloseUI(GameObject gUIPanel, Button button)
    {
        button.GetComponent<Image>().color=unpressedColor;
        gUIPanel.SetActive(false);
    }

    /*public void TaskUIClose()
    {//if working new remove

        tasksGUI.SetActive(false);
        
        tasksButton.GetComponent<Image>().color = unpressedColor;
        ChangeTextOnTasksButton();
  
    }*/
    void ChangeTextOnTasksButton()
    {
        var uniAiBase = activeUnit.GetComponent<UnitAiBase>();
        var taskButtonText = tasksButton.GetComponentInChildren<TextMeshProUGUI>().text;
        if (uniAiBase is UnitAiHeros)
        { 
            tasksButton.GetComponentInChildren<TextMeshProUGUI>().text= activeUnit.GetComponent<UnitAiBase>().GetActivity(); 
        }
        else if (uniAiBase is UnitAiMobs)
        { 
            tasksButton.GetComponentInChildren<TextMeshProUGUI>().text = "NPC";
            taskButtonText = "NPCC";
        }
    }
    void ReturnHome()
    { 
        activeUnit.GetComponent<HeroTravel>().ReturnHome();
    }
    void ReturnHomeAndUnloadBackPack()
    {
        activeUnit.GetComponent<BackPack>().backPackFull = true;
        
    }
    
}
    #region Old Technique buttons
    /*
    void EquipmentButton()
    {
        Debug.Log("equipmentButton pressed");
        //Color32 color;
        if (!equipmentOn)
        {
            equipmentOn = true;
            //set color pressed
            //set gear window active
            equipmentButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            equipmentGUI.SetActive(equipmentOn);
        }
        else 
        {
            equipmentOn = false;
            //set color depressed
            //deactivate gear window
            equipmentButton.GetComponent<Image>().color=new Color32(255,255,255,255);
            equipmentGUI.SetActive(equipmentOn);
        }
    }
    void BackPackButton()
    {
        Debug.Log("equipmentButton pressed");
        //Color32 color;
        if (!backpackOn)
        {
            backpackOn = true;
            //set color pressed
            //set gear window active
            backpackButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            backpackGUI.SetActive(backpackOn);
        }
        else
        {
            backpackOn = false;
            //set color depressed
            //deactivate gear window
            backpackButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            backpackGUI.SetActive(backpackOn);
        }
    }
    
    void AreasButton()
    {
        Debug.Log("Areas button pressed");

        if (!areasOn)
        {
            areasOn = true;
            areasButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            areasGUI.SetActive(areasOn);
            
        }
        else
        { 
            areasOn = false;
            areasButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            areasGUI.SetActive(areasOn);
        }
    }
    */
    #endregion
        #region old way
        /*
        //eq
        equipmentButton.onClick.AddListener(EquipmentButton);
        equipmentOn = false;
        equipmentUI.SetActive(equipmentOn);
        //backpack
        backpackButton.onClick.AddListener(BackPackButton);
        backpackOn = false;
        backpackUI.SetActive(backpackOn);
        */
        #endregion

        /*
        equipmentButton.onClick.AddListener(delegate
        {
            ButtonMethod(equipmentOn, equipmentButton, equipmentGUI);
            equipmentOn = tempBoolean;
            equipmentGUI.SetActive(tempBoolean);
        });
        equipmentOn = false;
        equipmentGUI.SetActive(equipmentOn);
        */

        //backpack
        /*
        backpackButton.onClick.AddListener(delegate
        {
            ButtonMethod(backpackOn, backpackButton, backpackGUI);
            backpackOn = tempBoolean;
            backpackGUI.SetActive(tempBoolean);
        });
        backpackOn = false;
        backpackGUI.SetActive(backpackOn);
        */

        //test
        /*
        testButton.onClick.AddListener(delegate
        {
            ButtonMethod(testOn, testButton, testGUI);
            testOn = tempBoolean;
            testGUI.SetActive(tempBoolean);
        });
        testOn = false;
        testGUI.SetActive(testOn);
        */

        //tasks
        /*
        tasksButton.onClick.AddListener(delegate
        {
            ButtonMethod(tasksOn, tasksButton, tasksGUI);
            tasksOn = tempBoolean;
            tasksGUI.SetActive(tempBoolean);
        });
        tasksOn = false;
        tasksGUI.SetActive(tasksOn);
        */

        /*
        areasButton.onClick.AddListener(delegate
        {
            ButtonMethod(areasOn, areasButton, areasGUI);
            areasOn = tempBoolean;
            areasGUI.SetActive(tempBoolean);
            //set which "area" button is active
            //_matKillAreaBool = areasOn;
            //_matKillAreaButton = areasButton;
            //set button mode to display info
            
            //areaUI.displayMethod = areaUI.AreasDisplayed(); we will probl do fck it abstract override

        });
        areasOn = false;
        areasGUI.SetActive(areasOn);
        */