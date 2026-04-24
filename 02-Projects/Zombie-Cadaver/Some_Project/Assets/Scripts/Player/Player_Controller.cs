using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_Controller : MonoBehaviour
{
        public float Player_Walk_Speed = 3.0f;
        public float Player_Run_Speed = 5.0f;
        public float Player_Reload_Speed = 1.0f;
        public float rotSpeed_X = 3.0f;

        public float now_Speed = 0f;
        float horizontalMove;
        float verticalMove;

        public Gun gun;
        private float count = 0;


        public GunController gunController;
        void Start()
        {
 
        }


        void Update()
        {

                
                

                float MouseX = Input.GetAxis("Mouse X");
                float MouseY = Input.GetAxis("Mouse Y");
                horizontalMove = Input.GetAxisRaw("Horizontal");
                verticalMove = Input.GetAxisRaw("Vertical");
               
                transform.Rotate(Vector3.up * rotSpeed_X * MouseX);
                


                if (Input.GetKey(KeyCode.W))
                {
                        transform.Translate(Vector3.forward * now_Speed * Time.deltaTime);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                        transform.Translate(Vector3.back * now_Speed * Time.deltaTime);
                }




                if (Input.GetKey(KeyCode.D))
                {
                        transform.Translate(Vector3.right * now_Speed * Time.deltaTime);

                }
                else if (Input.GetKey(KeyCode.A))
                {
                        transform.Translate(Vector3.left * now_Speed * Time.deltaTime);



                }
          




                

                if(Input.GetMouseButton(0))
                {
                        if (gun.state == Gun.State.Ready)
                        {
                                gunController.Shoot();
                        }
                        
                        
                }


                if(Input.GetMouseButton(1))
                {
                        now_Speed = 0;
                        count = 2f;
                }
                else
                {

                        count -= 2 * Time.deltaTime;
                           
                }


                if(Input.GetKey(KeyCode.R))
                {
                        gunController.Reload();
                }

                if (gun.state == Gun.State.Reloading)
                {
                        if(count < 1)
                        {
                                now_Speed = Player_Reload_Speed;
                        }
                        
                }
                

                else if (gun.state == Gun.State.Empty || gun.state == Gun.State.Ready)
                {
                        if(count < 1)
                        {
                                if (Input.GetKey(KeyCode.LeftShift))
                                {
                                        now_Speed = Player_Run_Speed;
                                }
                                else
                                {
                                        now_Speed = Player_Walk_Speed;
                                }
                        }
                        
                }
                   
        }
}
