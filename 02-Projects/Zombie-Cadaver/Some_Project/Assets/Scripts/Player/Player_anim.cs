using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_anim : MonoBehaviour
{

        
        public Animator Player_Animator;
        public Transform Aim;

        public GameManager Gm;

    void Start()
    {
                Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
                
                Player_Animator = GetComponent<Animator>();
                
                
    }

    // Update is called once per frame
    void Update()
        {







                this.transform.LookAt(Aim);






                if (Input.GetKey(KeyCode.W))
                {
                        //transform.Translate(Vector3.forward * now_Speed * Time.deltaTime);
                        
                        Player_Animator.SetFloat("v", 1f, 0.1f, Time.deltaTime);
                        //Player_Animator.SetBool("isWalk", true);
                }
        else if(Input.GetKey(KeyCode.S))
                {
                        //transform.Translate(Vector3.back * now_Speed * Time.deltaTime);
                        
                        Player_Animator.SetFloat("v", -1f, 0.1f, Time.deltaTime);
                        //Player_Animator.SetBool("isWalk", true);
                }
        else
                {
                        Player_Animator.SetFloat("v", 0f, 0.1f, Time.deltaTime);
                }



        if (Input.GetKey(KeyCode.D))
                {
                        //transform.Translate(Vector3.right * now_Speed * Time.deltaTime);
                        
                        Player_Animator.SetFloat("h", 1f, 0.1f, Time.deltaTime);
                        //Player_Animator.SetBool("isWalk", true);
                }
        else if (Input.GetKey(KeyCode.A))
                {
                        //transform.Translate(Vector3.left * now_Speed * Time.deltaTime);

                        Player_Animator.SetFloat("h", -1f, 0.1f, Time.deltaTime);
                        //Player_Animator.SetBool("isWalk", true);
                }
        else
                {
                        Player_Animator.SetFloat("h", 0f, 0.1f, Time.deltaTime);
                }

        /*
        if(Player_Animator.GetFloat("h") <= 0 && Player_Animator.GetFloat("v") <= 0)
                {
                        Player_Animator.SetBool("isWalk", false);
                }
                */


      
        
        if(Input.GetKey(KeyCode.Mouse1))
                {
                        Player_Animator.SetBool("isAim", true);
                }
                else
                {
                        Player_Animator.SetBool("isAim", false);
                }

        if(Input.GetKey(KeyCode.Mouse0))
                {
                        Player_Animator.SetTrigger("Fire");
                }
                

        if(Input.GetKey(KeyCode.LeftShift))
                {
                        Player_Animator.SetBool("isRun", true);
                }
        else
                {
                        Player_Animator.SetBool("isRun", false);
                }


        if(Input.GetKey(KeyCode.P))
                {
                        Gm.Ondamage(2);
                }
        
    }


        
}
