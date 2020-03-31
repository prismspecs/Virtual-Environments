using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMove2 : MonoBehaviour
{

    // a multiplier to slow down the keyboard movement
    public float DampenMovement = .25f;

    // reference to child object
    private Transform MyChild;

    // Update is called once per frame
    void Update()
    {
        // move this object based on keyboard input
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += moveVector * DampenMovement;
    }

    private void OnTriggerEnter(Collider other)
    {
        // pick up new child
        // only if object has tag "Pickup"
        if (other.gameObject.tag.Contains("Pickup"))
        {
            Debug.Log("Picked up!");
            // set reference to MyChild (for later transfer)
            MyChild = other.transform;
            // child the other object to this one
            MyChild.transform.parent = transform;
        }

        // transfer child
        if (other.gameObject.name.Contains("Parent"))
        {
            MyChild.transform.parent = other.transform;
            Debug.Log("child has been transferred to " + other.gameObject.name);

            // repositioning it can be done several ways. you could have an
            // empty game object on the new parent to designate where the child goes
            // in this instance I have created a separate script for the new parent
            // and will access that from here
            other.GetComponent<ParentReposition>().RepositionChild(MyChild);
        }
    }
}
