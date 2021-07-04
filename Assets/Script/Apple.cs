using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    Transform LeadingPoint;
    float magnetRange = 1f;
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        LeadingPoint = GameObject.Find("0").transform;
        transform.tag = "Apple";
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(LeadingPoint.transform.position, transform.position) < magnetRange)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, LeadingPoint.position, step);
        }
    }
}
