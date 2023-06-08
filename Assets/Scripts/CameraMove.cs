using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Player;
    public float Minx, Maxx, Miny, Maxy,Min,Max;
    public int Speed;
    private void Update()
    {
        //相机范围限制
        transform.position = new Vector3(Mathf.Clamp(Player.position.x, Minx, Maxx), Mathf.Clamp(Player.position.y, Miny, Maxy), -10f);
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, Min, Max);
            Camera.main.orthographicSize = Camera.main.orthographicSize-Input.GetAxis("Mouse ScrollWheel") *Speed;

        }
    }
}
