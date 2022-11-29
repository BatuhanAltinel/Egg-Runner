using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float xSpeed;

    private Animator anim;

    public GameObject wood;

    Touch m_Touch;

    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        TouchScreen();
    }

    void TouchScreen()
    {
        if (Input.touchCount > 0)
        {
            m_Touch = Input.GetTouch(0);

            MoveForward();

            if (m_Touch.phase == TouchPhase.Moved)
            {
                Debug.Log("touched the screen");
                transform.position = new Vector3(transform.position.x + m_Touch.deltaPosition.x * xSpeed,
                                        transform.position.y, transform.position.z);
            }
        }
        else
            anim.SetInteger("moveOn", 0);
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed);
        anim.SetInteger("moveOn", 1);
    }

}
