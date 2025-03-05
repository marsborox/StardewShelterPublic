using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviorUI : MonoBehaviour
{

    [SerializeField] Button repeatTask;
    [SerializeField] Button returnFullBackPack;

    bool buttonStatusOn;

    MainUI mainUI;
    List<Item> someList;
    private void Awake()
    {
        mainUI = GetComponent<MainUI>();
    }

    private void Start()
    {
        mainUI.InitiateButton(repeatTask,BehaviorOnClick);
    }

    private void OnEnable()
    {
        
    }

    void SetButtonsOnEnable()
    { 
        
    }


    void SetBehaviorActive()
    { 
        foreach (/*"settings in mainUI.activeHero.GetComponent<ActiveHero>.behaviorSettings status availible" */ Item item in someList)
        { 
            // bool of that set true/false
            //this will be for availible / ubnlocked behaviors
            //
        };
    }
    void BehaviorOnClick()
    {
        if (buttonStatusOn) { buttonStatusOn = false; }
        else { buttonStatusOn = true; }
    }
    void ButtonBehaviorOnClick()
    { 
        
    }
}
