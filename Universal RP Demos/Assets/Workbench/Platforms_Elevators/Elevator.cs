using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private bool GoingUp = false;

    public Transform ElevatorEnd;
    private Vector3 ElevatorStart;

    private float ElevatorStarted;
    public float ElevatorDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        ElevatorStart = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GoingUp)
        {
            float ElevatorLerp = (Time.time - ElevatorStarted) / (ElevatorStarted + ElevatorDuration);
            Debug.Log(ElevatorLerp);
            //transform.position = Vector3.Lerp(ElevatorStart, ElevatorEnd.position, ElevatorLerp);

            transform.Translate(Vector3.up * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("FPSController"))
        {
            // make the player a child of this platform
            other.transform.parent = transform;

            GoingUp = true;
            ElevatorStarted = Time.time;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name.Contains("FPSController"))
        {
            // unparent the player
            other.transform.parent = null;

            GoingUp = false;
        }
    }
}
