using System.Collections;
using System.Collections.Generic;

using Assets.PixelFantasy.PixelHeroes.Common.Scripts.CharacterScripts;
using Assets.PixelFantasy.PixelHeroes.Common.Scripts.ExampleScripts;

using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FarmMats : MonoBehaviour
{
    UnitTargetPicker unitTargetPicker;
    UnitMovement unitMovement;
    UnitStatsAndInfoBase unitStatsAndInfo;
    GameObject target;
    CharacterBuilder characterBuilder;
    CharacterAnimation characterAnimation;

    bool _targetInRange;
    private void Awake()
    {
        unitTargetPicker = GetComponent<UnitTargetPicker>();
        unitMovement = GetComponent<UnitMovement>();
        //unitStatsAndInfo = GetComponent<UnitStatsAndInfo>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    void FarmMatsTask()
    {
        if (target == null)
        { 
            unitTargetPicker.FindClosestMaterialSource();
            target = unitTargetPicker.materialTarget;
        }
        GatherOrMoveToMatResource();
    }

    public void GatherOrMoveToMatResource() //move to combat
    {
        unitMovement.TurnCorrectDirection(target.transform);
        CheckIfTargetInRange();
        
            if (_targetInRange)
            {
            GatherResource(target,gameObject);
            

            target = null;
            }
            else
            {
                unitMovement.Move(target);
            }
        
    }
    void CheckIfTargetInRange()//must rework same thing in Unitcombat
    {
        _targetInRange = Vector2.Distance(this.transform.position, target.transform.position) < unitStatsAndInfo.range;
    }
    void GatherResource(GameObject target, GameObject thisGameObject)
    {

        target.GetComponent<MaterialSource>().GatherResource(thisGameObject);

    }


    void MiningAction()
    {

        string weapon = characterBuilder.Weapon;
        characterBuilder.Weapon= "Pickaxe";
        characterBuilder.Rebuild();



        characterAnimation.Slash();
        //end of animation trigger slash again
        //after coroutine deltatime cooldown do get resource



        characterBuilder.Weapon=weapon;
    }
    public void MiningAnimationEvent()
    {
        target.GetComponent<MaterialSource>().GatherResource(this.gameObject);
        Destroy(target);
    }
    void SkinningAction()
    {
        
    }
    void ForagingAction()
    {
        characterAnimation.Crouch();
        //some coroutine or deltaTime
        characterAnimation.Idle();
    }
    void GtatheringAction()
    { 
        
    }
}
