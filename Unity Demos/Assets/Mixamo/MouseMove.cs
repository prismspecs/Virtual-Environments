using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    // reference to the animator component
    private Animator anim;

    // where will the character move to?
    private Vector3 Destination;

    // character movement speed
    public float Speed = 1f;

    // store the previous position so we can compare it to
    // current position later
    private Vector3 PreviousPosition;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // capture right click
        if(Input.GetMouseButtonDown(1))
        {
            // fire a ray from the 2d space of the monitor
            // to the 3d space of the game world
            RaycastHit hit; // RaycastHit stores some useful info for us

            // ...
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Destination = hit.point;

                // make the character look at the destination
                transform.LookAt(Destination);
            }
        }

        // move the character towards the destination
        transform.position = Vector3.MoveTowards(transform.position, Destination, Speed * Time.deltaTime);

        // derive the speed at which the character is walking so we
        // can send that value to the animator, to do this we need to
        // store the character location from the previous frame
        // and compare it to where it is now
        float MySpeed = (transform.position - PreviousPosition).magnitude / Time.deltaTime;
        anim.SetFloat("speed", MySpeed);    // send to animator

        PreviousPosition = transform.position;  // update previous position

        Debug.Log(PreviousPosition);

    }
}
