using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMouse : MonoBehaviour
{

    // reference the Animator component so we can trigger animations
    // and change parameters, etc.
    private Animator anim;

    // where will the character move to?
    private Vector3 Destination;

    // how many units per second?
    public float Speed = 1f;

    // 
    Vector3 PreviousPosition;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    // link the animator

    }

    // Update is called once per frame
    void Update()
    {
        // on right click
        if (Input.GetMouseButtonDown(1))
        {
            // create a raycast variable to store data
            RaycastHit hit;

            // fire a ray from the camera to the world and see where it hits
            // optionally use a layer mask here...
            // https://answers.unity.com/questions/1108781/set-ray-only-when-raycast-a-specific-layer.html
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                // that point is the destination
                Destination = hit.point;

                // rotate the character to look in that direction
                transform.LookAt(Destination);

            }
        }
        
        // move the character towards the destination
        transform.position = Vector3.MoveTowards(transform.position, Destination, Time.deltaTime * Speed);

        // we need to derive speed so we can feed it into the animator
        // one way to do this is to store the previous position every frame and
        // do some relative math using the .magnitude method
        float MySpeed = (transform.position - PreviousPosition).magnitude / Time.deltaTime;
        anim.SetFloat("speed", MySpeed);
        PreviousPosition = transform.position;

        Debug.Log(MySpeed);
    }
}
