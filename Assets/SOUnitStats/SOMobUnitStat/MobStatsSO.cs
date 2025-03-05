using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/Mob", fileName = "MobProperties")]
public class MobStatsSO : UnitSO
{
    [SerializeField] public Item lootItem;
    public int XP;
}
