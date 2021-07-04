using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed = 5;
    float distanceTravelled;



    private void FixedUpdate()
    {
        if (distanceTravelled >= pathCreator.path.length-.5f)
        {
            FindObjectOfType<StartandPause>().isFinished = true;
            speed = 0;
        }
        distanceTravelled += speed * Time.deltaTime;
        transform.position = new Vector3(pathCreator.path.GetPointAtDistance(distanceTravelled,end).x, pathCreator.path.GetPointAtDistance(distanceTravelled,end).y, transform.position.z);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled,end);
    }

}
