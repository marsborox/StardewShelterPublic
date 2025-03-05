using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HerbBush : MaterialSource
{
    private IObjectPool<GameObject> herbBushPoolLocal;
    public IObjectPool<GameObject> herbBushPool { set => herbBushPoolLocal = value; }
    private void Start()
    {
        base.Start();
        base.SetName(" + Bush");
    }
    public override void Deactivate()
    {
        herbBushPoolLocal.Release(this.gameObject);
    }
}
