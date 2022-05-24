using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    public bool enable_floor;
    public bool enable_left_wall;
    public bool enable_right_wall;
    public int block_num;

    public GameObject[] block;

    public GameObject floor;
    public GameObject left_wall;
    public GameObject right_wall;


    // Start is called before the first frame update
    void OnValidate()
    {
        floor.SetActive(enable_floor);
        left_wall.SetActive(enable_left_wall);  
        right_wall.SetActive(enable_right_wall);
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.sharedMesh = block[block_num].GetComponent<MeshFilter>().sharedMesh;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterials = block[block_num].GetComponent<MeshRenderer>().sharedMaterials;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
