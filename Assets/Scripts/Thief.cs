using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField]private float m_moveSpeed = 0.3f;

    public GameObject farmer;
    public GameObject egg;

    bool canMoveHorizontal = false;
    bool doubleHit = false;
    

    private void Update()
    {
        MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wood"))
        {
            Debug.Log("wood triggered");
            canMoveHorizontal = true;
            
            if(!doubleHit)
                RandomMoveHorizontalMove(canMoveHorizontal);

            SpawnEgg();
        }
    }


    void MoveForward()
    {
        if(checkMoveDistance())
        {
            transform.Translate(Vector3.forward * m_moveSpeed);
            //will add moving animation..
        }
            
    }

    float CalculateDistance()
    {
        float distance = Vector3.Distance(this.transform.position, farmer.transform.position);
        return distance;
    }

    void SpawnEgg()
    {
        Instantiate(egg, transform.position, Quaternion.identity);
    }

    bool checkMoveDistance()
    {
        if (CalculateDistance() > 25)
        {
            return false;
        }
        return true;
    }

    void RandomMoveHorizontalMove(bool canMove)
    {
        StartCoroutine(MoveHorizontalRoutine(canMove));
    }

    IEnumerator MoveHorizontalRoutine(bool canMove)
    {
        float randomNum = Random.Range(-13f,13f);
        Vector3 destination = new Vector3(randomNum,transform.position.y,transform.position.z);
        Debug.Log(randomNum);
        while(canMove)
        {
            yield return null;
            doubleHit = true;
            transform.position = Vector3.Lerp(this.transform.position,destination, Time.deltaTime*m_moveSpeed*10);
            
            if(Mathf.Abs(transform.position.x - destination.x) < 1f)
            {
                canMove = false;
                doubleHit = false;
            }
        }
    }

}
