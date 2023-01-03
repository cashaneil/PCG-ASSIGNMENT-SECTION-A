using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    // Submesh indices, triangle size, submesh count
    private int submeshTopIndex = 0;
    private int submeshBottomIndex = 0;
    private int submeshBackIndex = 0;
    private int submeshLeftIndex = 0;
    private int submeshRightIndex = 0;
    private int submeshFrontIndex = 0;

    private Vector3 triangleSize = Vector3.one;
    
    int submeshCount = 1;

    public void CreateCube(int material)
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();

        MeshBuilder meshBuilder = new MeshBuilder(submeshCount);

        // ---Coordinates for Points creating triangles which together form the cube---
        // ---Top Points
        Vector3 t0 = new Vector3(triangleSize.x, triangleSize.y, -triangleSize.z);
        Vector3 t1 = new Vector3(-triangleSize.x, triangleSize.y, -triangleSize.z);
        Vector3 t2 = new Vector3(-triangleSize.x, triangleSize.y, triangleSize.z);
        Vector3 t3 = new Vector3(triangleSize.x, triangleSize.y, triangleSize.z);

        // --Bottom Points
        Vector3 b0 = new Vector3(triangleSize.x, -triangleSize.y, -triangleSize.z);
        Vector3 b1 = new Vector3(-triangleSize.x, -triangleSize.y, -triangleSize.z);
        Vector3 b2 = new Vector3(-triangleSize.x, -triangleSize.y, triangleSize.z);
        Vector3 b3 = new Vector3(triangleSize.x, -triangleSize.y, triangleSize.z);

        // ---Triangles
        // Top Square
        meshBuilder.TriangleBuilder(t0, t1, t2, submeshTopIndex);
        meshBuilder.TriangleBuilder(t0, t2, t3, submeshTopIndex);

        // Bottom Square
        meshBuilder.TriangleBuilder(b2, b1, b0, submeshBottomIndex);
        meshBuilder.TriangleBuilder(b3, b2, b0, submeshBottomIndex);

        // Back Square
        meshBuilder.TriangleBuilder(t2, b2, b3, submeshBackIndex);
        meshBuilder.TriangleBuilder(t2, b3, t3, submeshBackIndex);

        // Left Side Square
        meshBuilder.TriangleBuilder(t1, b1, t2, submeshLeftIndex);
        meshBuilder.TriangleBuilder(b1, b2, t2, submeshLeftIndex);

        // Right Side Square
        meshBuilder.TriangleBuilder(t0, t3, b0, submeshRightIndex);
        meshBuilder.TriangleBuilder(t3, b3, b0, submeshRightIndex);

        // Front Square
        meshBuilder.TriangleBuilder(b1, t1, t0, submeshFrontIndex);
        meshBuilder.TriangleBuilder(b0, b1, t0, submeshFrontIndex);

        meshBuilder.CreateMesh();
        meshFilter.mesh = meshBuilder.CreateMesh();

        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();

        MaterialsBuilder materialsBuilder = new MaterialsBuilder();

        meshRenderer.material = materialsBuilder.MaterialsList().ToArray()[material]; // By default set material to grey
    }

    // Method for getting cube size from triangle size
    public Vector3 CubeSize()
    {
        return triangleSize * 2;
    }
}
