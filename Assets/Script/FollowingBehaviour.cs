using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBehaviour : MonoBehaviour
{
    public GameObject target;
    private float smoothTime = .1f;
    private Vector3 velocity = Vector3.zero;


    void FixedUpdate()
    {
        FindTarget();
        TailBehaviour();
    }

    private void FindTarget()
    {
        int index = int.Parse(transform.name);
        target = GameObject.Find((index - 1).ToString());
        

    }

    private void TailBehaviour()
    {
        if (target)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), ref velocity, smoothTime);
        } 

        transform.LookAt(target.transform);
    }
}
