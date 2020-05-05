using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    // a List has some advantages over an array
    // importantly, you don't need to define the size of a List
    // when it is created, it's more flexible. However, it comes
    // at a detriment to performance so you should be careful
    public List<GameObject> Stuff = new List<GameObject>();

    public int AddThing(GameObject go)
    {
        // add the GameObject passed to this method
        // to the bucket's List
        Stuff.Add(go);

        // return the number of things the bucket currently holds
        return Stuff.Count;
    }

    private void OnMouseOver()
    {
        // if player right clicks on the bucket
        if (Input.GetMouseButtonDown(1))
        {
            // .. but this is no good!
            foreach (GameObject go in Stuff)
            {
                go.SetActive(true);
                Stuff.Remove(go);
            }

            for (int i = Stuff.Count - 1; i >= 0; i--)
            {
                Stuff[i].SetActive(true);
                Stuff.RemoveAt(i);
            }
        }
    }
}
