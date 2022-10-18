using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{

    public void Move(Transform destination,float timeToMove ,bool isFollowing)
    {
        StartCoroutine(MoveRoutine(destination,timeToMove, isFollowing));
    }

    IEnumerator MoveRoutine(Transform destination,float timeToMove, bool isFollowing)
    {
        Transform startPosition = this.transform;
        float elapsedTime = 0f;

        while (isFollowing)
        {
            yield return new WaitForEndOfFrame();
            if (Vector3.Distance(startPosition.position,destination.position) < 0.01f)
            {
                startPosition = destination;
            }

            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp(elapsedTime / timeToMove, 0, 1);

            transform.position = Vector3.Lerp(startPosition.position, destination.position, t);

        }
    }
}




