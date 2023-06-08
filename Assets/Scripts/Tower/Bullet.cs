using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int Towerdamge;
    private Transform Tar;
    public void Target(Transform target)
     {
         Tar = target;
     }
    private void Update()
    {
        if (Tar!=null)
        {
            transform.Translate((Tar.transform.position - transform.position).normalized * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            Destroy(gameObject);
            collision.GetComponentInParent<Enemy>().ChangeEnemyBlood(-Towerdamge);
        }
    }

}
