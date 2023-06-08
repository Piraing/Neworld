using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject Enemy;
    public List<Transform> Pos = new List<Transform>();
    public float EnemyCreateTime;
    public GameObject light,light1;
    private float timer;
    private int waves;
    private void Update()
    {
        timer += Time.deltaTime;
        EnemyRandomCreate();

    }
    void EnemyRandomCreate()
    {
        if (GameManager.instance.AllTimer <= 20)
        {
            if (timer >= EnemyCreateTime)
            {
                timer = 0;
                Instantiate(Enemy);
                waves = Random.Range(0, 3);
                if (waves == 0)
                {
                    Enemy.transform.position = Pos[Random.Range(0, 2)].position;
                }
                else if (waves == 1)
                {
                    Enemy.transform.position = Pos[Random.Range(3, 5)].position;
                }
                else if (waves == 2)
                {
                    Enemy.transform.position = Pos[Random.Range(6, 8)].position;
                }
                else if (waves == 3)
                {
                    Enemy.transform.position = Pos[Random.Range(9, 11)].position;
                }
            }
        }
        else if (GameManager.instance.AllTimer >= 20&& GameManager.instance.AllTimer <= 30)
        {
            if (timer >=1)
            {
                timer = 0;
                Instantiate(Enemy);
                Enemy.transform.position = Pos[Random.Range(0, 2)].position;
            } 
        }
        else if (GameManager.instance.AllTimer >= 30)
        {
            Destroy(light);
            light1.GetComponent<Light>().intensity = 1;
        }
    }
}
