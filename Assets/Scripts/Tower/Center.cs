using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : Tower
{
    private int Blood;
    public Collider2D Col;
    protected override void Start()
    {
        base.Start();
        isBuild = true;
        Col.enabled = true;
    }
}
