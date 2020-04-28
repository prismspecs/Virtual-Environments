using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// make this script work in edit mode!
[ExecuteInEditMode]
public class StayInSocket : MonoBehaviour
{

    public Transform MySocket;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = MySocket.position;
    }
}
