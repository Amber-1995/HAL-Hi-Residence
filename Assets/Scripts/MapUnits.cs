using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUnits : MonoBehaviour
{
    [Range(0,1000)]
    public int size;

    // Start is called before the first frame update
    void OnValidate()
    {
        MeshFilter mfilter = GetComponent<MeshFilter>();
        mfilter.mesh.Clear();

      
        Mesh mesh = mfilter.mesh;
        mesh.vertices = new Vector3[]
        {
            new Vector3 (- 1 - size*0.5f,  0.5f, -0.5f),
            new Vector3 (  - size * 0.5f,  0.5f, -0.5f),
            new Vector3 (  - size * 0.5f, -0.5f, -0.5f),
            new Vector3 (    size * 0.5f,  0.5f, -0.5f),
            new Vector3 (    size * 0.5f, -0.5f, -0.5f),
            new Vector3 (1 + size * 0.5f,  0.5f, -0.5f),

            new Vector3 (- 1 - size*0.5f,  0.5f, -0.5f),
            new Vector3 (- 1 - size*0.5f,  0.5f,  0.5f),
            new Vector3 (  - size * 0.5f,  0.5f, -0.5f),
            new Vector3 (  - size * 0.5f,  0.5f,  0.5f),
            new Vector3 (    size * 0.5f,  0.5f, -0.5f),
            new Vector3 (    size * 0.5f,  0.5f,  0.5f),
            new Vector3 (1 + size * 0.5f,  0.5f, -0.5f),
            new Vector3 (1 + size * 0.5f,  0.5f,  0.5f),

            new Vector3 (  - size * 0.5f, -0.5f, -0.5f),
            new Vector3 (  - size * 0.5f, -0.5f,  0.5f),
            new Vector3 (    size * 0.5f, -0.5f, -0.5f),
            new Vector3 (    size * 0.5f, -0.5f,  0.5f),
         

        };

        mesh.triangles = new int[]{
            0,1,2,2,1,3,2,3,4,4,3,5,
            6,7,9,6,9,8,8,9,11,8,11,10,10,11,13,10,13,12,
            15,14,16,15,16,17
        };
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
