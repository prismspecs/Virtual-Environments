using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheckForward : MonoBehaviour
{
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, forward, 10))
            print("There is something in front of the object!");
    }
}
