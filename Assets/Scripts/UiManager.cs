using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public Text ShowEnergy;
    private void Start()
    {
        instance = this;
    }
    public void UpdateUI()
    {
        //ˢ��UI��ʾ
        ShowEnergy.text = GameManager.instance.Energy.ToString();
    }
}
