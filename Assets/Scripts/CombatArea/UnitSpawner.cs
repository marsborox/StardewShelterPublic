using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    InputInfo inputInfo;
    SpawningHelperScripts spawningHelperScripts;

    private void Awake()
    {
        inputInfo = GetComponent<InputInfo>();
        spawningHelperScripts = GetComponent<SpawningHelperScripts>();
    }
}
