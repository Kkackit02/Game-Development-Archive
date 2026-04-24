using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regdoll_Sound : MonoBehaviour
{
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider col)
        {
                if (col.gameObject.tag == "Car")
                {


                        GameManager gameManager = FindObjectOfType<GameManager>();

                        gameManager.RegdollSound();



                }
        }
}
