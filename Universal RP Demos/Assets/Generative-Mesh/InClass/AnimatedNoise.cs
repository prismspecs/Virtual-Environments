using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class AnimatedNoise : MonoBehaviour
{
    // optional... spawn game objects
    public GameObject myObj;

    // store the mesh data
    Mesh mesh;

    // store the vertices for the generated mesh
    Vector3[] vertices;
    // store the order with which to create the triangles
    int[] triangles;

    // how many "tiles" or quads we want on both axes
    public int xSize = 20;
    public int zSize = 20;

    // optional, animate where you are sampling the wave
    // within the noise map
    private float waveSurfer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the new mesh object instance
        mesh = new Mesh();
        // point the mesh filter mesh to our new mesh
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.name = "Generated Mesh";

        // call our functions
        // run CreateShape as a coroutine so that it can happen
        // as a non-blocking function
        //StartCoroutine(CreateShape());

    }

    private void Update()
    {
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        // tell our vertices array how many points its going to store
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        // create an index to refer to a specific vertex
        int i = 0;

        for (int z = 0; z < zSize + 1; z++)
        {
            for (int x = 0; x < xSize + 1; x++)
            {
                // generate a noise-based height
                float y = Mathf.PerlinNoise(x * .2f + waveSurfer, z * .2f) * 5f;

                // optionally animate the noise
                waveSurfer += .00001f;

                vertices[i] = new Vector3(x, y, z);
                i++;

                // create a prefab at this location as well
                //GameObject newObj = Instantiate(myObj, new Vector3(x, 0, z), Quaternion.identity);
                //newObj.transform.localScale = new Vector3(1, y, 1);
                //yield return new WaitForSeconds(.1f);
            }
        }

        // 
        triangles = new int[xSize * zSize * 6];
        int tri = 0;
        int vert = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tri + 0] = vert + 0;
                triangles[tri + 1] = vert + xSize + 1;
                triangles[tri + 2] = vert + 1;

                triangles[tri + 3] = vert + xSize + 1;
                triangles[tri + 4] = vert + xSize + 2;
                triangles[tri + 5] = vert + 1;

                vert++;
                tri += 6;

            }

            vert++;
        }
    }

    void UpdateMesh()
    {
        // clear the mesh data just in case
        mesh.Clear();

        // assign the vertices and triangles to your mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        // if no vertices exist, give an exit condition
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }

}
