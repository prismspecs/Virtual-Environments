using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class GenMesh1 : MonoBehaviour
{
    // store the mesh data
    Mesh mesh;

    // store the vertices for the generated mesh
    Vector3[] vertices;
    // store the order with which to create the triangles
    int[] triangles;


    // Start is called before the first frame update
    void Start()
    {
        // initialize the new mesh object instance
        mesh = new Mesh();
        // point the mesh filter mesh to our new mesh
        GetComponent<MeshFilter>().mesh = mesh;

        // call our functions
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        // create the vertices and place them into our vert array
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3(1,0,1),
        };

        // order the vertices so the triangles are drawn correctly
        triangles = new int[]
        {
            0,1,2,
            1,3,2,
        };
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

}
