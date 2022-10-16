using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{
    [SerializeField] private float followSpeed = 12f;


    public void UpdateEggPosition(Transform folowedEgg, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastEggPosition(folowedEgg, isFollowStart));
    }

    IEnumerator StartFollowingToLastEggPosition(Transform folowedEgg, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, folowedEgg.position.x, followSpeed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, folowedEgg.position.z, followSpeed * Time.deltaTime));
        }
    }

    //public void Move(Transform destination,bool isFollowing)
    //{
    //    StartCoroutine(MoveRoutine(destination, isFollowing));
    //}

    //IEnumerator MoveRoutine(Transform destination , bool isFollowing)
    //{
    //    //Transform startPosition = this.transform;
    //    //float elapsedTime = 0f;

    //    //while (isFollowing)
    //    //{

    //    //    elapsedTime += Time.deltaTime;

    //    //    float t = Mathf.Clamp(elapsedTime / timeToMove, 0, 1);

    //    //    transform.position = Vector3.Lerp(startPosition.position, destination.position, t);

    //    //    yield return null;

    //    //}
}
    


