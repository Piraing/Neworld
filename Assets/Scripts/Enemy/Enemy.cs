using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Enemydamge, speed,Blood, NowBlood;
    public GameObject Cen,Enm;
    private bool isWalk = true;
    public float Enemydamgetime;
    private float timer;
    protected virtual void Start()
    {
        NowBlood = Blood;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Move();
    }
    void Move()
    {
        if (isWalk == true)
        {
            transform.Translate((Cen.transform.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tower")
        {
            isWalk = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tower")
        {
            Tower tower = collision.GetComponentInParent<Tower>();
            if (timer >= Enemydamgetime)
            {
                timer = 0;
                tower.Changehealth(-Enemydamge);
            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tower")
        {
            isWalk = true;
            timer = 0;
        }
    }
    public  void ChangeEnemyBlood(int damge)
    {
        NowBlood += damge;
        if (NowBlood<=0)
        {
            Enm.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            Instantiate(Enm);
            
        }
    }
}
