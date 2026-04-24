using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Angel : MonoBehaviour
{
        public GameObject Enemy;
        public GameObject Player;
        public Transform Player2;
        private float Speed;
        public float origin_Speed;

      

        void start()
        {
                Speed = origin_Speed;
                soundManager.instance.PlaySound();

        }
        /*
        void OnBecameVisible()
        {
                Speed = 0f;
        }

        void OnBecameInvisible()
        {
                Speed = 10f;
        }

        */

        void Update()
    {
                //transform.LookAt(Player2);
                
                transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, Speed * Time.deltaTime);
                
    }

        public void DeadSceneChange()
        {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Dead");

        }

        void OnTriggerEnter(Collider Coll)
        {
                if(Coll.gameObject.tag == "Looking")
                {
                        Speed = 0f;
                        
                        soundManager.instance.Stop();
                }

                if (Coll.gameObject.tag == "Life")
                {


                        DeadSceneChange();
                }

                if (Coll.gameObject.tag == "NoLooking")
                {
                        
                        soundManager.instance.PlaySound();
                }
        }

        void OnTriggerExit(Collider Coll)
        {
                if (Coll.gameObject.tag == "Looking")
                {
                        Speed = origin_Speed;


                }
        }


        
}
