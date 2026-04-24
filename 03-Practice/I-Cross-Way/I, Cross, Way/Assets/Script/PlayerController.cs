using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public float speed_Player = 2.5f;
        public float run_Player = 5.5f;
        public float rotSpeed_X = 1.0f;
        private float now_speed;

        public Animator animator;
        
        float horizontalMove;
        float verticalMove;
        public GameManager gm;

        public GameManager hr;
        public bool isWAR = false;

        public bool HardMod = false;


        void Start()
    {
                animator = GetComponent<Animator>();
                GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

                //GameManager hr = GameObject.Find("HardModCheak").GetComponent<HardModeCheak>();


                speed_Player = gm.P_walk;
                run_Player = gm.P_Run;
                now_speed = speed_Player;

    }

        // Update is called once per frame
        void Update()
        {
                float MouseX = Input.GetAxis("Mouse X");
                float MouseY = Input.GetAxis("Mouse Y");
                horizontalMove = Input.GetAxisRaw("Horizontal");
                verticalMove = Input.GetAxisRaw("Vertical");



                transform.Rotate(Vector3.up * rotSpeed_X * MouseX);


                if (Input.GetKey(KeyCode.W) == true)
                {
                        transform.Translate(Vector3.forward * now_speed * Time.deltaTime);


                }
                if (Input.GetKey(KeyCode.S) == true)
                {
                        transform.Translate(Vector3.back * now_speed * Time.deltaTime);


                }

                if (HardMod == false)
                {
                        if (Input.GetKey(KeyCode.A) == true)
                        {
                                transform.Translate(Vector3.left * now_speed * Time.deltaTime);


                        }
                        if (Input.GetKey(KeyCode.D) == true)
                        {
                                transform.Translate(Vector3.right * now_speed * Time.deltaTime);


                        }
                }
                
                

               

                if (Input.GetKey(KeyCode.LeftShift) == true)
                {
                        now_speed = run_Player;
                        
                        isWAR = true;

                        if (horizontalMove == 0 && verticalMove == 0)
                                {
                                        animator.SetBool("isRun", false);
                                }
                        else
                        {
                                animator.SetBool("isRun", true);
                        }

                                        
                }
                else
                {
                        now_speed = speed_Player;
                        animator.SetBool("isRun", false);
                        isWAR = false;
                }



                if (horizontalMove == 0 && verticalMove == 0)
                {
                        animator.SetBool("isWalk", false);
                        isWAR = false;
                }
                else
                {
                        animator.SetBool("isWalk", true);
                        isWAR = true;



                
                }




        }
                
        }
