using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform pathmarker1, pathmarker2;
    private Transform destination;
    [SerializeField]
    private float speed = 3.0f;

    // Update is called once per frame
    private void Start()
    {

    }
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, pathmarker1.position) < 0.001f)
        {
            destination = pathmarker2;
        }
        else if(Vector3.Distance(transform.position, pathmarker2.position) < 0.001f)
        {
            destination = pathmarker1;
        }
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            other.transform.SetParent(this.gameObject.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
