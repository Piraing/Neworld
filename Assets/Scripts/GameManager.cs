using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Energy;
    public float AllTimer;
    public bool isBuild;
    private void Start()
    {
        AllTimer += Time.deltaTime;
        instance = this;
    }
    //能量改变
    public void ChangeEnergy(int ChangeEnergy)
    {
        isBuild = true;
        if (Energy + ChangeEnergy<0)
        {
            isBuild = false;
            return;
        }
        Energy+=ChangeEnergy;
        UiManager.instance.UpdateUI();
    }
    
}
