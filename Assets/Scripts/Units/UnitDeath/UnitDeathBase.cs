using System.Collections;
using System.Collections.Generic;

using Assets.PixelFantasy.PixelHeroes.Common.Scripts.ExampleScripts;

using UnityEngine;

public class UnitDeathBase : MonoBehaviour
{
    public UnitHealth unitHealth;
    public UnitCombat unitCombat;
    public CharacterAnimation characterAnimation;
    // Start is called before the first frame update
    public void Awake()
    {
        unitHealth=GetComponent<UnitHealth>();
        unitCombat=GetComponent<UnitCombat>();
        characterAnimation=GetComponent<CharacterAnimation>();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        unitHealth.Died += OnDeath;
    }
    private void OnDisable()
    {
        unitHealth.Died -= OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnDeath() { }
}
