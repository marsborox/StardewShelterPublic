using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaButton : MonoBehaviour
{
    enum Task { MOBKILLING,MATERIALFARMING, INFO}
    public GameObject destination;

    MainUI mainUI;

    private void Awake()
    {
        mainUI = GetComponent<MainUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MobKilling()
    { 
        
    }
}
