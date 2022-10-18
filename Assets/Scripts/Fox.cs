using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField]private float m_moveSpeed = 0.3f;

    public GameObject farmer;
    public GameObject egg;
    

    private void Update()
    {
        MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wood"))
        {
            Debug.Log("wood triggered");
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

    void RandomHorizontalMove()
    {

    }


}
