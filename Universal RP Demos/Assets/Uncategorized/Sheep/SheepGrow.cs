using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGrow : MonoBehaviour
{

    public float SheepScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // use the single sheep scale float for X Y and Z
        transform.localScale = new Vector3(SheepScale, SheepScale, SheepScale);

        // bonus testing effect: scale with Y position
        //SheepScale = transform.position.y;
    }
}
