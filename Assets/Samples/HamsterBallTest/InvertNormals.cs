using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertNormals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -1 * normals[i];
        }
        mesh.normals = normals;

        for (int j = 0; j < mesh.subMeshCount; j++)
        {
            int[] tris = mesh.GetTriangles(j);
            for (int k = 0; k < tris.Length; k+=3)
            {
                int temp = tris[k];
                tris[k] = tris[k + 1];
                tris[k + 1] = temp;
            }

            mesh.SetTriangles(tris, j);
        }

        MeshCollider meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
