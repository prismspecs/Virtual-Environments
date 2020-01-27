using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // create a reference to a prefab we can drag/drop
    // that this script will continually spawn
    public GameObject WhatToSpawn;

    void Start()
    {
        // in .5 seconds, start calling this function, every 1 secs
        InvokeRepeating("SpawnIt", .5f, 1f);  
    }

    void SpawnIt()
    {
        // the Instantiate function creates a new instance (or Clone) of
        // some GameObject
        // you need to give it a position and rotation, as well
        // we can just use the position of this Spawner Game Object
        Instantiate(WhatToSpawn, transform.position, Quaternion.identity);

        // a quaternion is a representation of a 3d rotation
        // Quaternion.identity corresponds to "no rotation" - 
        // the object is perfectly aligned with the world or parent axes.

        // bonus: move to a random location after spawning?
        transform.position = new Vector3(Random.Range(-5, 5), 5, Random.Range(-5, 5));
    }
}
