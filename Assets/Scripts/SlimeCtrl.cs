using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCtrl : MonoBehaviour
{

    public float jump_force;
    public float move_speed;
    public float charge_speed;


    private float charge_gauge = 0.0f;
    private bool on_floor = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if(Input.GetKey(KeyCode.LeftArrow) && charge_gauge <= 0.0f)
        //{
        //    transform.Translate(-move_speed * Time.deltaTime, 0.0f, 0.0f);
        //}

        //if(Input.GetKey(KeyCode.RightArrow) && charge_gauge <= 0.0f)
        //{
        //    transform.Translate(move_speed * Time.deltaTime, 0.0f, 0.0f);
        //}

        if(Input.GetKey(KeyCode.Space) && on_floor)
        {
            charge_gauge = charge_gauge + charge_speed * Time.deltaTime > 1.0f ? 1.0f : charge_gauge + charge_speed * Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space) && on_floor)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector3(-1.0f, 1.0f, 0.0f) * charge_gauge * jump_force /1.414f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector3(1.0f, 1.0f, 0.0f) * charge_gauge * jump_force / 1.414f);
            }
            else
            {
                rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * charge_gauge * jump_force);
            }

            charge_gauge = 0.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            on_floor = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            on_floor = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            on_floor = false;
        }
    }
}
