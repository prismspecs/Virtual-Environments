using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    // create a reference to the bucket
    public Bucket TheBucket;

    // Start is called before the first frame update
    void Start()
    {
        TheBucket = FindObjectOfType<Bucket>();
    }

    // when you click an object, add it to the bucket list
    private void OnMouseDown()
    {
        // add the game object that this script is attached to
        int NumThings = TheBucket.AddThing(this.gameObject);
        
        // disable the object
        this.gameObject.SetActive(false);

        // for now just log the output of how manys things are in the bucket
        Debug.Log(NumThings);

        if (NumThings > 3)
        {
            Debug.Log("Too many things already in bucket!");

            TheBucket.DropThing();
        }
    }
}
