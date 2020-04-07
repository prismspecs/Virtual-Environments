using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheckForward : MonoBehaviour
{

    public float ViewDistance = 3f;

    private float MyRotation;

    // the camera will rotate + or - the rotation amount
    // from the offset position, so you can be more intentional
    // with where it's looking
    public float RotationAmount = 30f;
    public float RotationOffset;

    public float RotateSpeed = .1f;

    // also have an angle offset to make the camera point
    // up or down a bit like a real security cam
    public float Tilt = 15f;

    // bonus: setoff an alert light if player is seen
    public Material AlertLight;

    void Update()
    {
        // rotate the surveillance cube
        // since sine waves go from -1 to 1, if we multiply it
        // by 30, it will go from -30 degrees to positive 30 degrees
        // we will make the rotation amount a public variable
        MyRotation = Mathf.Sin(Time.time * RotateSpeed) * RotationAmount;

        // to directly set the total rotation of a game object in degrees we
        // can use transform.eulerAngles
        // we want it to swivel around its Y axis so just multiply Vector3.up
        // by MyRotation
        transform.eulerAngles = new Vector3(Tilt, MyRotation + RotationOffset, 0f);
        

        // create a vector that shoots out from the center of this object
        // we can create ViewDistance as a public float so we can change it
        // from the editor
        Vector3 forward = transform.TransformDirection(Vector3.forward) * ViewDistance;
        Debug.DrawRay(transform.position, forward, Color.green);

        // need to store data about the raycast hit
        RaycastHit hit;

        // looking in front of this game object, what do we see?
        if (Physics.Raycast(transform.position, forward, out hit, ViewDistance))
        {
            
            if(hit.transform.name.Contains("ThirdPersonController"))
            {
                Debug.Log("I see the player!");
                AlertLight.EnableKeyword("_EMISSION");
            } 
        }
        else
        {
            Debug.Log("I don't see anything...");
            AlertLight.DisableKeyword("_EMISSION");
        }
    }
}
