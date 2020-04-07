using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    // a list of all colliders inside this collider
    private List<Collider> colliders = new List<Collider>();

    // any time a unit enters this trigger
    private void OnTriggerEnter(Collider other)
    {
        // only add if its not already in the list
        if (!colliders.Contains(other))
        {
            // add it to the list of colliders
            colliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // when unit is no longer within the box, remove it from list
        colliders.Remove(other);
    }

    public List<Collider> GetColliders()
    {
        return colliders;
    }
}
