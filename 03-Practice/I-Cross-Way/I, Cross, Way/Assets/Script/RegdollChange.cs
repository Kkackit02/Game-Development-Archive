using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegdollChange : MonoBehaviour
{
        public GameObject charObj;
        public GameObject ragdollObj;
        
        public Rigidbody spine;

        public bool game_Clear = false;

        public void Start()
        {
                
        }
        void Update()
        {
                
        }

        public void ChangeRagdoll()
        {
               


                ragdollObj.gameObject.SetActive(true);
                charObj.gameObject.SetActive(false);
                
                
        }


        void OnTriggerEnter(Collider col)
        {
                if (col.gameObject.tag == "Car")
                {
                        
                        ChangeRagdoll();
                        GameManager gameManager = FindObjectOfType<GameManager>();
                        
                        gameManager.Die();

                        
                        
                }


                if (col.gameObject.tag == "Clear")
                {
                        if (game_Clear == false)
                        {
                                GameManager gameManager = FindObjectOfType<GameManager>();
                                game_Clear = true;
                                gameManager.Goal();
                        }
                        
                        
                        
                }

                if (col.gameObject.tag == "P_Destroy")
                {
                        ChangeRagdoll();
                        GameManager gameManager = FindObjectOfType<GameManager>();
                        gameManager.Die();


                }


        }



}
