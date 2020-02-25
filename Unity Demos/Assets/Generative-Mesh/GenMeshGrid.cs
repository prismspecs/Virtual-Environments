using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeshGrid : MonoBehaviour
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

        // call our functions
        CreateShape();
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
