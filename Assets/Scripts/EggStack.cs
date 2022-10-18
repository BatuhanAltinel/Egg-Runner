using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStack : MonoBehaviour
{

    public Transform[] stackPoints = new Transform[15];

    List<GameObject> _eggList = new List<GameObject>();

    private int _eggListIndexCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Egg"))
        {
            _eggList.Add(other.gameObject);

            other.gameObject.GetComponent<Eggs>().Move(stackPoints[_eggListIndexCounter], 1f, true);
            _eggListIndexCounter++;
        }
    }
}
