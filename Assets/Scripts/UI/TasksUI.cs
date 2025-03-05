using System.Collections;
using System.Collections.Generic;

using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class TasksUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button _tasksButton;
    [SerializeField] Toggle _IdleToggle;
    [SerializeField] Toggle _killMobsToggle;
    [SerializeField] Toggle _farmMatsToggle;

    Color32 unpressedColor = new Color32(255, 255, 255, 255);
    Color32 pressedColor = new Color32(200, 200, 200, 255);

    MainUI mainUI;

    void Awake()
    {
        mainUI= GetComponent<MainUI>();
        //unpressedColor=buttonColorUI.unpressedColor;
        //pressedColor=buttonColorUI.pressedColor;

        /*
        _IdleToggle.onValueChanged.AddListener(delegate { TestPrint("idle"); });
        _killMobsToggle.onValueChanged.AddListener(delegate { TestPrint("_killMobsToggle"); });
        _farmMatsToggle.onValueChanged.AddListener(delegate { TestPrint("_farmMatsToggle"); });
        */
        InitializeToggle(_IdleToggle,"Idle", Task.IDLE);
        InitializeToggle(_killMobsToggle, "killMobs", Task.KILLMOBS);
        InitializeToggle(_farmMatsToggle, "Idle", Task.FARMMATS);

        /*
        _IdleToggle.onValueChanged.AddListener(delegate
        {
            TestPrint("idle");
            ToggleMethod(_IdleToggle);
            //SetActivity(Task.IDLE);
        });
        _killMobsToggle.onValueChanged.AddListener(delegate
        {
            TestPrint("killMobs");
            ToggleMethod(_killMobsToggle);
            //SetActivity(Task.KILLMOBS);
        });
        _farmMatsToggle.onValueChanged.AddListener(delegate
        {
            TestPrint("farmMats");
            ToggleMethod(_farmMatsToggle);
            //SetActivity(Task.FARMMATS);
        });
        */
        
    }

    void InitializeToggle(Toggle toggle,string stringToPrint, Task task)
    {
        toggle.onValueChanged.AddListener(delegate
        {
            TestPrint(stringToPrint);
            ToggleMethod(toggle, task);
            
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    

    void ToggleMethod(Toggle toggle, Task task)
    {
        //picked hero set task enum
        //gameObject.transform.parent.transform.parent.GetComponent<MainUI>().TaskUIReset();//should be done over event
        var mainUI = this.gameObject.transform.parent.transform.parent.GetComponent<MainUI>();
        //mainUI.TaskUIClose();
        mainUI.CloseUI(this.gameObject,mainUI.tasksButton);
        mainUI.activeUnit.GetComponent<UnitAiHeros>().task = task;
        mainUI.activeUnit.GetComponent<UnitAiHeros>().OnTaskChange();
    }
    void SetActivity(Task task)
    {
        var mainUI = this.gameObject.transform.parent.transform.parent.GetComponent<MainUI>();
        mainUI.activeUnit.GetComponent<UnitAiHeros>().task = task;

        //mainUI.TaskUIReset();
    }
    void TestPrint(string text)
    { 
        Debug.Log(text);
    }

    public void MobKilling()
    {
        Debug.Log("Areas for MobKilling");
    }
    public void MaterialFarming()
    {
        Debug.Log("Areas for MaterialFarming");
    }
    public void AreasDisplayed()
    {
        Debug.Log("Areas just Displayed");
    }
}
