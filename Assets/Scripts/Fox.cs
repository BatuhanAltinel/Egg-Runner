using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField]private float m_moveSpeed = 0.3f;

    float distance;
    public GameObject farmer;
    public GameObject egg;

    float timer = 4;
    

    private void Update()
    {
        MoveForward();
        SpawnEgg();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * m_moveSpeed);
    }

    float CalculateDistance()
    {
       return distance = Vector3.Distance(this.transform.position, farmer.transform.position);
    }

    void SpawnEgg()
    {
        
        if (CalculateDistance() < 15)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                Instantiate(egg, transform.position, Quaternion.identity);
                timer = 0;
            }
        }

        if (CalculateDistance() > 15)
        {
            timer = 4;
        }
    }
}
