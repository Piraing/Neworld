using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //todo:ÉèÖÃÐÞ¸Ä°´¼ü
    public int speed;
    public float Minx, Maxx, Miny, Maxy;
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Minx, Maxx), Mathf.Clamp(transform.position.y, Miny, Maxy), -10f);
        Move();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
