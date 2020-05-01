using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour
{

    // "Life" of footprint will be used as alpha val, and to see if it should be deleted
    float Life = 1;

    // reference to material that will be automatically set up
    Material MyMat;

    // bonus! add a particle system effect
    public GameObject ParticleSys;

    // Start is called before the first frame update
    void Start()
    {
        // create a reference to the material so we can change shader properties
        MyMat = GetComponent<Renderer>().material;

        // spawn a particle system
        GameObject ps = Instantiate(ParticleSys, transform);
        Destroy(ps, 1f);    // destroy the particle system after a sec
    }

    // Update is called once per frame
    void Update()
    {
        // decrease "life" over time, 50% per second
        Life -= .25f * Time.deltaTime;

        // use that as the alpha value for the shader
        MyMat.SetFloat("_Alpha", Life);

        // delete footprint if its time
        if (Life <= 0f)
            Destroy(this.gameObject);
    }
}
