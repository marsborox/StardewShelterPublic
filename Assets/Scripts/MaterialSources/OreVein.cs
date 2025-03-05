using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class OreVein : MaterialSource
{
    private IObjectPool<GameObject> oreVeinPoolLocal;
    public IObjectPool<GameObject> oreVeinPool { set => oreVeinPoolLocal = value; }
    private void Start()
    {
        base.Start();
        base.SetName(" + Vein");
    }
    public override void Deactivate()
    {
        oreVeinPoolLocal.Release(this.gameObject);
    }
}
