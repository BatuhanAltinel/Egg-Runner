using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStack : MonoBehaviour
{
    private Vector3 _firstEggPos;
    private Vector3 _currentEggPos;

    public GameObject stackPoint;

    List<GameObject> _eggList = new List<GameObject>();
    private int _eggListIndexCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            _eggList.Add(other.gameObject);
            if (_eggList.Count == 1)
            {
                _firstEggPos = stackPoint.transform.position;
                _currentEggPos = new Vector3(other.transform.position.x, _firstEggPos.y, other.transform.position.z);
                other.gameObject.transform.position = _currentEggPos;
                _currentEggPos = new Vector3(other.transform.position.x, transform.position.y + 1.3f, other.transform.position.z);
                other.gameObject.GetComponent<Eggs>().UpdateEggPosition(transform, true);
            }
            else if (_eggList.Count > 1)
            {
                other.gameObject.transform.position = _currentEggPos;
                _currentEggPos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 1.3f, other.transform.position.z);
                other.gameObject.GetComponent<Eggs>().UpdateEggPosition(_eggList[_eggListIndexCounter].transform, true);
                _eggListIndexCounter++;
            }
        }
    }
}
