using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCtrl : MonoBehaviour
{
    public float a;
    public float b;
    public float c;

    private Transform transform;
    private Rigidbody rb;
    private Vector3 chargingScale;
    private bool isCharging;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        chargingScale = Vector3.one;
        isCharging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCharging)
        {
            transform.localScale = new Vector3(1.0f, 0.8f + (Mathf.Sin(Time.timeSinceLevelLoad * a) + 1) / 10.0f, 1.0f);
        }
       

        if(Input.GetKey(KeyCode.Space))
        {
            isCharging = true;
            transform.localScale = chargingScale;
            chargingScale.y = chargingScale.y > 0.5f ? chargingScale.y - b*Time.deltaTime : chargingScale.y;
        }
        else
        {
           

            if(isCharging)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.AddForce(new Vector3( -c / chargingScale.y, c / chargingScale.y, 0.0f));
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddForce(new Vector3( c / chargingScale.y, c / chargingScale.y, 0.0f));
                }
                else
                {
                    rb.AddForce(new Vector3(0.0f, c / chargingScale.y, 0.0f));
                }
                   
            }
            chargingScale = Vector3.one;
            isCharging = false;
        }
   
        
    }
}
