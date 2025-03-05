using Assets.PixelFantasy.PixelHeroes.Common.Scripts.ExampleScripts;
using UnityEngine;


public class UnitAiBase : MonoBehaviour
{
    //universal class for all units in game
    //public CombatActivity combatActivity;

    public UnitMovement unitMovement;
    public UnitCombat unitCombat;
    //UnitStatsAndInfo unitStatsAndInfo;
    //ObjectInfo objectInfo;

    public UnitHealth unitHealth;
    public UnitTargetPicker unitTargetPicker;
    public CharacterAnimation characterAnimation;

    public UnitStatsAndInfoBase unitStatsAndInfo;

    //bool _targetInRange;
    //[SerializeField] public bool inCombat;


    
    //when killing mobs we choose to do traveling it kinda fucks up mabye in ai script shouldb e fix
    //when in combat change travel it cancel travel request
    public void Awake()
    {
        unitMovement = GetComponent<UnitMovement>();
        unitCombat = GetComponent<UnitCombat>();
        
        unitHealth = GetComponent<UnitHealth>();
        unitTargetPicker = GetComponent<UnitTargetPicker>();
        characterAnimation = GetComponent<CharacterAnimation>();
        unitStatsAndInfo = GetComponent<UnitStatsAndInfoBase>();
        //objectInfo = GetComponent<ObjectInfo>();
        
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public virtual string GetActivity() { return "Unknown";  }

    public void OnEnable()
    {
        //unitCombat.Attacked += IfImIdleMakeMeCombat;

    }

    public void OnDisable()
    {
        //unitCombat.Attacked -= IfImIdleMakeMeCombat;
    }


    public void IfImIdleMakeMeCombat()
    {//only enemies
        if (unitCombat.combatStatus == CombatStatus.NOTCOMBAT)
        {
            unitCombat.combatStatus = CombatStatus.COMBAT;
        }
        if (unitCombat.combatStatus == CombatStatus.RESTING)
        {
            unitCombat.combatStatus = CombatStatus.COMBAT;
        }
        unitCombat.inCombat = true;
    }

}
