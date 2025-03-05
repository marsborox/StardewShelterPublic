using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "SO_GatheringMaterial")]
public class SO_GatheringMaterial : ScriptableObject
{
    [SerializeField] public Item resource;
    [SerializeField] public int ammount;
    [SerializeField] public Sprite sprite;


}
