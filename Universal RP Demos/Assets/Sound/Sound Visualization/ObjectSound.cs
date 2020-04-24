using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public class ObjectSound : MonoBehaviour
{

    public AudioClip MySound;
    private AudioSource MyAudioSource;
    public TextMesh MyTextPrefab;
    public string MyText;

    // Start is called before the first frame update
    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // where did we collide?
        // you can either get the collision position of the first
        // collision contact point in the array, which is easy
        ContactPoint contact = collision.contacts[0];

        
        // or if there are multiple collision points, you may want to
        // find the average position
        Debug.Log(collision.contacts.Length);

        // create an empty Vector3 to store the sum of all collision points
        Vector3 average = Vector3.zero;
        // loop thru all points of collision and add them to the average
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            average += collision.contacts[i].point;
        }
        // then simply divide by the number of collisions to get the average
        average = average / collision.contacts.Length;
        

        // create the text object at the position of the collision
        TextMesh tm = Instantiate(MyTextPrefab, average, Quaternion.identity);

        // change its text property
        tm.text = MyText;

        // play the sound
        MyAudioSource.PlayOneShot(MySound);
        Destroy(tm.gameObject, .5f);   // maybe it should go away quickly?

        // perhaps we should also destroy this game object, as if it were a drop of water
        Destroy(this.gameObject, .5f);

    }

}
