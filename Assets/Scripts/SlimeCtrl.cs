using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCtrl : MonoBehaviour
{

    public float jump_force;
    public float min_jump_speed;
    public float charge_speed;


    private float charge_gauge = 0.0f;
    private bool on_floor = false;
    private bool full_charge = false;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(on_floor && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("charge",true);
        }else
        {
            animator.SetBool("charge", false);
        }

        if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "charge" && Input.GetKeyUp(KeyCode.Space))
        {
            if(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
               
                float current_time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                float length = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
                float t = current_time / length;
                animator.SetBool("jump",true);
                rb.AddForce(new Vector3(-jump_force * t, jump_force * t, 0.0f));
            }
            else if(Input.GetKey(KeyCode.RightArrow) &&!Input.GetKey(KeyCode.LeftArrow))
            {
                
                float current_time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                float length = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
                float t = current_time / length;
                animator.SetBool("jump", true);
                rb.AddForce(new Vector3(jump_force * t, jump_force * t, 0.0f));
            }
            else
            {
                
                float current_time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                float length = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
                float t = current_time / length;
                animator.SetBool("jump", true);
                rb.AddForce(new Vector3(0.0f, jump_force * t, 0.0f));
            }
        }else
        {
            animator.SetBool("jump", false);
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

    public void FullCharge()
    {
        full_charge = true;
    }
}
