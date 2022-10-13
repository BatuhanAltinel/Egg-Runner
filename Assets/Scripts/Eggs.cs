using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{
    [SerializeField] private float followSpeed = 12f;


    public void UpdateCubePosition(Transform followedCube, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastCubePosition(followedCube, isFollowStart));
    }

    IEnumerator StartFollowingToLastCubePosition(Transform followedCube, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedCube.position.x, followSpeed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followedCube.position.z, followSpeed * Time.deltaTime));
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
    


