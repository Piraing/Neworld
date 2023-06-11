using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuild : MonoBehaviour
{
    public GameObject Tower;
    public int ReduceEnergy;
    private GameObject CopyTower, BoolTower;
    private bool isUnder=true;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)&&isUnder==true)
        {
            Destroy(CopyTower);
        }
    }

    //拖动开始
    public void OnBeginDrag(BaseEventData data)
    {
        isUnder = true;
        PointerEventData pointerEventData = data as PointerEventData;
        CopyTower = Instantiate(Tower);
        CopyTower.transform.position = WorldToCamera(pointerEventData.position);
    }
    //拖动
    public void OnDrag(BaseEventData data)
    {
        if (CopyTower == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        CopyTower.transform.position = WorldToCamera(pointerEventData.position); 

    }
    //拖动结束
    public void OnEndDrag(BaseEventData data)
    {
        isUnder = false;
        if (CopyTower == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        Collider2D[] col = Physics2D.OverlapPointAll(WorldToCamera(pointerEventData.position));
        foreach (var c in col)
        {
            if (c.tag == "Land" && c.transform.childCount == 0)
            {
                GameManager.instance.ChangeEnergy(-ReduceEnergy);
                if (GameManager.instance.isBuild == true)
                {
                    CopyTower.transform.parent = c.transform;
                    CopyTower.transform.position = c.transform.position;
                    CopyTower.GetComponent<Tower>().IsCreate();
                    break;
                }
                else
                {
                    GameObject.Destroy(CopyTower);
                }
            }
            else
            {
                Destroy(CopyTower);
            }
        }

    }
    //鼠标坐标
    public static Vector3 WorldToCamera(Vector3 worldposition)
    {
        Vector3 cameraposition = Camera.main.ScreenToWorldPoint(worldposition);
        return new Vector3(cameraposition.x, cameraposition.y, 0);
    }

}
