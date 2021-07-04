using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]Transform target;
    public bool startPosition = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x - 4, target.position.y + 6f, 3);
        transform.LookAt(new Vector3(target.position.x+3, target.position.y, target.position.z));
        
    }
}
