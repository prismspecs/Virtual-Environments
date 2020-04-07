using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // for changing color when selected
    private Material MyMat;

    public bool Selected = false;

    // where the unit should go after receiving
    // the method call from the selection script
    public Vector3 Destination;

    public float MySpeed = 2f;

    // the target destination will always return a 0 on
    // the Y axis so we just need to remind the unit
    // how tall it is and offset by half that
    public Vector3 MyOffset;

    // Start is called before the first frame update
    void Start()
    {
        // get a reference to the material
        MyMat = GetComponent<Renderer>().material;

        // set Destination to where it already stands
        Destination = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // draw a forward-looking ray from the unit
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Debug.DrawRay(transform.position, forward, Color.green);

        // we can do something if it sees something in front...
        if (Physics.Raycast(transform.position, forward, 10))
        {
            //print("There is something in front of the object!");
        }

        // move towards the Destination
        float dist = Vector3.Distance(transform.position, Destination);
        if(dist > .2f)
        {
            transform.LookAt(Destination);
            transform.Translate(Vector3.forward * MySpeed * Time.deltaTime);
        }
    }

    public void Activate()
    {
        MyMat.color = Color.green;
        Selected = true;
    }
    public void Deactivate()
    {
        MyMat.color = Color.white;
        Selected = false;
    }
    public void SetDestination(Vector3 pos)
    {
        // the select units/clicking script always hits the
        // plane which is at 0 on the Y, but we dont want the unit
        // to go into the floor so we need a positive offset here
        Destination = pos + MyOffset;
    }
}
