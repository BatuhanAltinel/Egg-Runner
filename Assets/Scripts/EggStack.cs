using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStack : MonoBehaviour
{

    [SerializeField] float timeToMove = 1f;
    public Transform firstEggPosition;
    public Transform currentEggPosition;

    [SerializeField] GameObject eggParent;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Egg"))
        {
            
            other.gameObject.GetComponent<Eggs>().Move(firstEggPosition, timeToMove, true);
            other.gameObject.GetComponent<Eggs>().Move(currentEggPosition,timeToMove,true);
            other.gameObject.transform.parent = eggParent.transform;
            
        }
    }

  
}
