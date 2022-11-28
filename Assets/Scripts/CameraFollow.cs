using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMove();
    }

    void CameraMove()
    {
        transform.position = Vector3.Lerp(transform.position,player.position + offset,Time.deltaTime);
    }
}
