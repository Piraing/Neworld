using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int Health,Nowhealth;
    //处理拖动时禁用碰撞器
    protected bool isBuild;
    protected BoxCollider2D box;
    protected virtual void  Start()
    {
        isBuild = false;
        box=GetComponentInChildren<BoxCollider2D>();
        box.enabled = false;
        Nowhealth = Health;
    }
    public  void Changehealth(int damge)
    {
        Nowhealth += damge;
        if (Nowhealth<=0)
        {
            Destroy(gameObject);
        }
    }
    public void IsCreate()
    {
        box.enabled = true;
        isBuild = true;
    }
}
