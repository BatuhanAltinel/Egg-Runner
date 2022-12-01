using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] GameObject farmer;
    [SerializeField] GameObject thief;

    // Start is called before the first frame update
    void Awake()
    {
        if(gameManager == null)
            gameManager = this;
        else
            Destroy(gameObject);
    }

    public float GetDistance()
    {
        float distance = Vector3.Distance(thief.transform.position, farmer.transform.position);
        return distance;
    }
}
