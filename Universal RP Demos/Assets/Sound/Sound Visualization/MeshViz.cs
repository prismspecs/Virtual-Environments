using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshViz : MonoBehaviour
{
    // you need to store the mesh data in a Mesh data type instance
    Mesh mesh;

    // we will use a vertex array and triangle array to describe
    // the points in our mesh before assigning them to the mesh itself
    Vector3[] vertices;
    int[] triangles;

    static int slices = 64;

    // define the size of our grid
    public int xSize = slices;
    public int zSize = slices;

    // an AudioSource object so the music can be played  
    private AudioSource aSource;
    // a float array that stores the audio samples  
    public float[] samples = new float[slices];

    // Start is called before the first frame update
    void Start()
    {
        // initialize the mesh and link it to the MeshFilter component
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        aSource = GetComponent<AudioSource>();

        // call our functions
        CreateShape();
        
    }

    private void Update()
    {
        UpdateMesh();
    }

    void CreateShape()
    {
        // we want as many verts as the size of our grid plus 1 on both axes
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        int i = 0;  // create an index for later
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                // for the coordinates we can just use our iterators
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }


    }

    void UpdateMesh()
    {

        // clear any previous data just in case
        mesh.Clear();

        // obtain the samples from the frequency bands of the attached AudioSource  
        aSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        //For each sample  
        for (int i = 0; i < samples.Length; i++)
        {
            
            for(int n = 0; n < samples.Length; n++)
            {
                int w = i + samples.Length * n;
                vertices[w].Set(vertices[w].x, Mathf.Clamp(samples[i] * 100, 0, 100), vertices[w].z);
            }
 
        }

    // assign the vertices and triangles to the mesh
    mesh.vertices = vertices;
        mesh.triangles = triangles;

        // uncomment after looking at lighting without it
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}