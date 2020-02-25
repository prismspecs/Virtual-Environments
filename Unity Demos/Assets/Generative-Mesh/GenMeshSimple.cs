using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class GenMeshSimple : MonoBehaviour
{
    // you need to store the mesh data in a Mesh data type instance
    Mesh mesh;

    // we will use a vertex array and triangle array to describe
    // the points in our mesh before assigning them to the mesh itself
    Vector3[] vertices;
    int[] triangles;


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
        // syntax to specify multiple elements in a new array
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),
             new Vector3(0,0,1),
              new Vector3(1,0,1)
        };

        // the triangle array is referring to the vertex array
        // so when we say 0 we mean the Vector3(0,0,0) as noted above
        triangles = new int[]
        {
            0,1,2
        };
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
}
