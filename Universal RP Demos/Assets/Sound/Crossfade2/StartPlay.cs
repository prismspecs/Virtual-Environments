using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlay : MonoBehaviour
{

    public Radio MyRadio;
    public AudioClip MyClip;

    // Start is called before the first frame update
    void Start()
    {
        MyRadio.ChangeMusic(MyClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
