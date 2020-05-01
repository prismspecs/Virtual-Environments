using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintGen : MonoBehaviour
{

    public Transform LeftFoot;
    public Transform RightFoot;

    public GameObject LeftFootprint;
    public GameObject RightFootprint;

    // Update is called once per frame
    void Update()
    {
        // for our purposes, just move him forward
        transform.Translate(Vector3.forward * Time.deltaTime);

        transform.Rotate(Vector3.up * 22 * Time.deltaTime);
    }

    public void FootDown(int whichFoot)
    {
        // for whichFoot, 0 is left foot and 1 is right foot

        // derive a position that is where the foot is but at Y = 0
        Vector3 LeftFootAdjusted = new Vector3(LeftFoot.position.x, 0.01f, LeftFoot.position.z);
        Vector3 RightFootAdjusted = new Vector3(RightFoot.position.x, 0.01f, RightFoot.position.z);

        // get rotation of character...
        Vector3 rot = transform.rotation.eulerAngles;

        // my footprints need to be rotated by 180 degrees
        rot = new Vector3(rot.x, rot.y + 180, rot.z);

        if(whichFoot == 0)
            Instantiate(LeftFootprint, LeftFootAdjusted, Quaternion.Euler(rot));
        else
            Instantiate(RightFootprint, RightFootAdjusted, Quaternion.Euler(rot));
    }

}
