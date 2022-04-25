using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    // public vars
    public bool inputGiven;
    public bool attached = false;

    //private vars
    private bool objectInRange = false;
    private GameObject magneticObject;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if input and object in range, attract
        if (inputGiven && objectInRange && !attached)
        {
            if (magneticObject.transform.parent == null)
            {
                Debug.Log("Attached");
                magneticObject.transform.SetParent(this.transform);
                rb = magneticObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.detectCollisions = false;
                attached = true;

                // move up slightly for moving around
                //magneticObject.transform.position += new Vector3(0, 0.05f, 0);
            }
        }

        // drop 
        else if (!inputGiven && attached)
        {
            Debug.Log("Detached");
            magneticObject.transform.SetParent(null);
            rb.isKinematic = false;
            rb.detectCollisions = true;
            attached = false;
        }

        
    }


    // Enter trigger 
    private void OnTriggerEnter(Collider other)
    {
        // entering object should be magnetic, and only see first one
        if (other.tag == "Magnetic" && magneticObject == null)
        {
            objectInRange = true;
            magneticObject = other.gameObject;
        }
    }

    // Exit trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Magnetic" && !attached)
        {
            objectInRange = false;
            magneticObject = null;
        }
    }

}
