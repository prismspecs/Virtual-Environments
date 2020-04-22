using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInterval : MonoBehaviour
{

    public GameObject SpawnThis;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(SpawnThis, transform.position, Quaternion.identity);
        }
    }
}
