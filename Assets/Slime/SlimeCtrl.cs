using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCtrl : MonoBehaviour
{
    public float jump_force;

    private Rigidbody rb;
    private bool jumpable;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       jumpable = false;
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(jumpable && Input.GetKey(KeyCode.Space))
       {
            animator.SetBool("Charge",true);
       }

        if (jumpable && Input.GetKeyUp(KeyCode.Space) && (animator.GetCurrentAnimatorStateInfo(0).IsName("Slime_charge") || animator.GetCurrentAnimatorStateInfo(0).IsName("Slime_Full_Charge")) )
        {
            animator.SetBool("Charge", false);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector3(jump_force * (Mathf.Abs(transform.localScale.y - 1.0f) + 0.5f), jump_force * (Mathf.Abs(transform.localScale.y - 1.0f) + 0.5f), 0.0f));
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector3(-(jump_force * (Mathf.Abs(transform.localScale.y - 1.0f) + 0.5f)), jump_force * (Mathf.Abs(transform.localScale.y - 1.0f) + 0.5f), 0.0f));
            }else
            {
                rb.AddForce(new Vector3(0.0f, jump_force * 1.414f * (Mathf.Abs(transform.localScale.y - 1.0f) + 0.5f), 0.0f));
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Block")
        {
            jumpable = true;
        }
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Block")
        {
            jumpable = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Block")
        {
            jumpable = false;
        }
    }
}
