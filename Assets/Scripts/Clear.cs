using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public GameObject clearUI;
    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
       {
            clearUI.SetActive(true);
       }
    }
}
