using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float hMove = 0f;

    bool jump = false;
    bool check = false;

    //bool holding = false;

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal2") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }



    }



    public void OnLanding()
    {
      if (check == false)
      {
        check = true;
      }
      else{
        animator.SetBool("IsJumping", false);
        check = false;
      }
    }

    private void FixedUpdate()
    {
        //Move char
        controller.Move(hMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
