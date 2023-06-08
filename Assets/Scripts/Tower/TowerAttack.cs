using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : Tower
{
    public List<GameObject> Enemy = new List<GameObject>();
    public GameObject Bullet, BulletPos;
    private float timer;
    public float ShootTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            Enemy.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy.Remove(collision.gameObject);
    }
    protected override void Start()
    {
        base.Start();
        if (Enemy.Count != 0)
        {
            timer = 0;
            Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ShootTime && Enemy.Count != 0l && isBuild == true)
        {
            timer = 0;
            Attack();
        }
    }
    void Attack()
    {
        if (Enemy[0]!=null)
        {
            GameObject BulletShoot = Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
            BulletShoot.GetComponent<Bullet>().Target(Enemy[0].transform);
        }
        
    }
}
