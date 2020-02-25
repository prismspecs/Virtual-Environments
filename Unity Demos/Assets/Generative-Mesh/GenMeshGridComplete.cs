using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeshGridComplete : MonoBehaviour
{
    // you need to store the mesh data in a Mesh data type instance
    Mesh mesh;

    // we will use a vertex array and triangle array to describe
    // the points in our mesh before assigning them to the mesh itself
    Vector3[] vertices;
    int[] triangles;

    // define the size of our grid
    public int xSize = 20;
    public int zSize = 20;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the mesh and link it to the MeshFilter component
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // create the grid, but because we want to use the Wait function,
        // we need to do this as a Coroutine
        StartCoroutine(CreateShape());
        
    }

    // because we want to see our mesh update over time (for learning purposes)
    // we need to move the UpdateMesh method into the Update function
    private void Update()
    {
        UpdateMesh();
    }

    IEnumerator CreateShape()
    {

        // you can even give your mesh a name
        mesh.name = "Procedural Grid";

        // we want as many verts as the size of our grid plus 1 on both axes
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        int i = 0;  // create an index for later
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                // for the coordinates we can just use our iterators
                //vertices[i] = new Vector3(x, 0, z);
                //i++;

                // so how would you make this more interesting?
                // random variations in height?
                //vertices[i] = new Vector3(x, Random.Range(0, 2), z);
                //i++;

                // variations in height based on Perlin noise?
                // try changing the increment!
                float y = Mathf.PerlinNoise(x * .3f, z) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        // we also need to set up all of our triangles that use these verts
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tri = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tri + 0] = vert + 0;
                triangles[tri + 1] = vert + xSize + 1;
                triangles[tri + 2] = vert + 1;
                triangles[tri + 3] = vert + 1;
                triangles[tri + 4] = vert + xSize + 1;
                triangles[tri + 5] = vert + xSize + 2;

                vert++;
                tri += 6;

                yield return new WaitForSeconds(.02f);
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        // clear any previous data just in case
        mesh.Clear();

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
