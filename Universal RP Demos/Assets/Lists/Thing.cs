using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{

    public Bucket TheBucket;

    // Start is called before the first frame update
    void Start()
    {
        TheBucket = FindObjectOfType<Bucket>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        TheBucket.AddThing(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
