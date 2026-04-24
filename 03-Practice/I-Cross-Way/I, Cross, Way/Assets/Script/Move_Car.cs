using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Car : MonoBehaviour
{

        public float speed;
        //public bool Cheak_L;
        //public Light_Color light_Color;

        public GameManager gm;
        public bool isGround = false;

        void Start()
    {
                //Light_Color light_Color = GameObject.Find("LIGHT").GetComponent<Light_Color>();
                GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
                speed = gm.P_Speed;
        }

    // Update is called once per frame
    void Update()
        {
                
                //Cheak_L = light_Color.isGreen;
                
                
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                
                
        }



        void OnTriggerEnter(Collider other)
        {
                if (other.transform.tag == "Car")
                {
                        speed = 0.0f;
                }

                if (other.transform.tag == "road")
                {
                        isGround = true;
                }
                
        }

        void OnTriggerExit(Collider other)
        {
                if (other.transform.tag == "Car")
                {
                        speed = gm.P_Speed;
                }


        }
}
