using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBounce : MonoBehaviour
{

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // give it a push
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 RandDirection = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            rb.AddForce(RandDirection * 10);
        }

        if(rb.velocity.magnitude < .5f)
        {
            Vector3 RandDirection = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            rb.AddForce(RandDirection * 10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name.Contains("Wall"))
        {
            // take the velocity down to zero
            rb.velocity = Vector3.zero;

            // random
            //Vector3 RandDirection = new Vector3(Random.Range(-100,100), 0, Random.Range(-100,100));
            //rb.AddForce(RandDirection * 10);

            // more intentional random
            // get relative magnitude of impact
            float magnitude = collision.relativeVelocity.magnitude;
            Debug.Log(magnitude);

            // get normalized opposite vector from impact
            Vector3 force = transform.position - collision.transform.position;
            // random offset
            force += new Vector3(Random.Range(-.1f, .1f), 0, Random.Range(-.1f, .1f));
            // add the new total force to the object
            rb.AddForce(force * magnitude * 10);
            Debug.Log(force);
        }
    }
}
