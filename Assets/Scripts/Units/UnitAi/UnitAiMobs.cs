using System;

public enum MobsActivity { IDLE, COMBAT,}
public class UnitAiMobs : UnitAiBase
{
    public MobsActivity mobsActivity;
    
    
    void Start()
    {
        
    }
    public override string GetActivity()
    {
        return Enum.GetName(typeof(MobsActivity), mobsActivity);
    }
    // Update is called once per frame
    void Update()
    {
        unitStatsAndInfo.taskString = mobsActivity.ToString();
        EnemyActivitySwitch();
    }

    public void EnemyActivitySwitch()
    {//only enemy
        switch (mobsActivity)

        {
            case MobsActivity.IDLE:
                {
                    characterAnimation.Idle();
                    break;
                }
            case MobsActivity.COMBAT:
                {
                    unitCombat.Combat();
                    break;
                }
        }

        switch (unitCombat.combatStatus) 
        {
            case CombatStatus.NOTCOMBAT:
                {
                    characterAnimation.Idle();
                    break;
                }
            case CombatStatus.COMBAT:
                {
                    unitCombat.Combat();
                    break;
                }
            case CombatStatus.DEAD:
                {
                    characterAnimation.Die();
                    break;
                }
        }
    }


}
