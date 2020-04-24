using UnityEngine;
using System.Collections;

public class SpectrumVisualizer : MonoBehaviour
{
    // an AudioSource object so the music can be played  
    private AudioSource aSource;
    // a float array that stores the audio samples  
    public float[] samples = new float[64];
    // a renderer that will draw a line at the screen  
    private LineRenderer lRenderer;
    // a reference to the cube prefab  
    public GameObject cube;
    // the transform attached to this game object  
    private Transform goTransform;
    // the position of the current cube. Will also be the position of each point of the line.  
    private Vector3 cubePos;
    // an array that stores the Transforms of all instantiated cubes  
    private Transform[] cubesTransform;


    void Awake()
    {
        //Get and store a reference to the following attached components:  
        //AudioSource  
        aSource = GetComponent<AudioSource>();
        //LineRenderer  
        lRenderer = GetComponent<LineRenderer>();
        //Transform  
        goTransform = GetComponent<Transform>();
    }

    void Start()
    {
        // the line should have the same number of points as the number of samples  
        lRenderer.positionCount = samples.Length;

        // the cubesTransform array should be initialized with the same length as the samples array  
        cubesTransform = new Transform[samples.Length];

        // center the audio visualization line at the X axis, according to the samples array length  
        goTransform.position = new Vector3(-samples.Length / 2, goTransform.position.y, goTransform.position.z);

        // create a temporary GameObject, that will serve as a reference to the most recent cloned cube  
        GameObject tempCube;

        // for each sample  
        for (int i = 0; i < samples.Length; i++)
        {
            // instantiate a cube placing it at the right side of the previous one  
            tempCube = Instantiate(cube, new Vector3(goTransform.position.x + i, goTransform.position.y, goTransform.position.z), Quaternion.identity);

            // get the recently instantiated cube Transform component  
            cubesTransform[i] = tempCube.GetComponent<Transform>();

            // make the cube a child of this game object  
            cubesTransform[i].parent = goTransform;
        }
    }

    void Update()
    {
        // obtain the samples from the frequency bands of the attached AudioSource  
        aSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        //For each sample  
        for (int i = 0; i < samples.Length; i++)
        {
            /*Set the cubePos Vector3 to the same value as the position of the corresponding 
             * cube. However, set it's Y element according to the current sample.*/
            cubePos.Set(cubesTransform[i].position.x, Mathf.Clamp(samples[i] * 150, 0, 150), cubesTransform[i].position.z);

            // if the new cubePos.y is greater than the current cube position  
            if (cubePos.y >= cubesTransform[i].position.y)
            {
                // Set the cube to the new Y position  
                cubesTransform[i].position = cubePos;
            }
            else
            {
                // The spectrum line is below the cube, make it fall  
                // or just have rigidbody on the cube
                //cubesTransform[i].position -= gravity;
            }

            /*Set the position of each vertex of the line based on the cube position. 
             * Since this method only takes absolute World space positions, it has 
             * been subtracted by the current game object position.*/
            lRenderer.SetPosition(i, cubePos - goTransform.position);
        }
    }
}