using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField]private float m_moveSpeed = 0.35f;
    [SerializeField]private float rbMoveSpeed = 220f;
    Animator anim;
    Rigidbody rb;
    public GameObject farmer;
    public GameObject egg;

    bool canMoveHorizontal = true;
    
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wood"))
        {
            Debug.Log("wood triggered");
            RandomMoveHorizontalMove();
            SpawnEgg();
        }
    }


    void MoveForward()
    {
        if(checkMoveDistance())
        {
            if(anim != null)
            {
                anim.SetBool("CanRun",true);
                transform.Translate(Vector3.forward * m_moveSpeed);
                // rb.velocity = new Vector3(0,0,rbMoveSpeed*Time.deltaTime);
            }
            else
                Debug.LogWarning("Animator has not been found");
            
            //will add moving animation..
        }
            
    }

    void SpawnEgg()
    {
        Instantiate(egg, transform.position, Quaternion.identity);
        anim.SetBool("isHit",true);
        IncreaseMoveSpeedWhenHitting();
        DecreaseMoveSpeed();
        StartCoroutine(StopJumpingRoutine());
    }

    bool checkMoveDistance()
    {
        if (GameManager.gameManager.GetDistance() > 35)
        {
            anim.SetBool("CanRun",false);
            return false;
        }
        return true;
    }

    void RandomMoveHorizontalMove()
    {
        StartCoroutine(MoveHorizontalRoutine());
    }

    IEnumerator MoveHorizontalRoutine()
    {
        float randomNum = Random.Range(-10f,10f);
        float elapsedTime = 0;
        bool canMove = true;
        Debug.Log(randomNum);

        yield return new WaitForSeconds(1.2f);

        Transform startPosition = this.transform;

        while(canMove)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp(elapsedTime / 10f, 0, 1);
            Vector3 destination = new Vector3(randomNum,transform.position.y,transform.position.z);
            transform.position = Vector3.Lerp(startPosition.position,destination, t);
            
            // if (Vector3.Distance(transform.position,destination) < 0.01f)
            // {
            //     transform.position = destination;
            //     canMove = false;
            // }

            if(Mathf.Abs(transform.position.x - destination.x) < 0.01f)
                canMove = false;
        }
    }

    IEnumerator StopJumpingRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isHit",false);
    }

    void IncreaseMoveSpeedWhenHitting()
    {
        m_moveSpeed += 0.3f;
    }

    void DecreaseMoveSpeed()
    {
        StartCoroutine(DecreaseMoveSpeedRoutine());
    }

    IEnumerator DecreaseMoveSpeedRoutine()
    {
        yield return new WaitForSeconds(2f);
        m_moveSpeed -= 0.3f;
    }
}
