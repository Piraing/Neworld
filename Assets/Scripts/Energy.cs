using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Energy : MonoBehaviour
{
    private GameObject Text;
    private void Start()
    {
        Text = GameObject.Find("EnergyUI");
        //销毁物体增加能量
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(new Vector2(Camera.main.ScreenToWorldPoint(Text.transform.position).x, Camera.main.ScreenToWorldPoint(Text.transform.position).y), 2));
        sequence.AppendCallback(
            () =>
            {
                Destroy(gameObject);
                GameManager.instance.ChangeEnergy(10);
            }
            );
        
    }
}
        
  

