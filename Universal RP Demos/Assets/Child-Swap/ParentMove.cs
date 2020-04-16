using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMove : MonoBehaviour
{

    // a multiplier to slow down the keyboard movement
    public float DampenMovement = .25f;

    // reference to child object
    public Transform MyChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move this object based on keyboard input
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += moveVector * DampenMovement;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);

        if(other.gameObject.name.Contains("Parent"))
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
