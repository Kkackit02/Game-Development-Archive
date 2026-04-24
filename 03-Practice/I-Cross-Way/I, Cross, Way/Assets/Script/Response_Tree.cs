using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response_Tree : MonoBehaviour
{
        public GameManager gm;
        public GameObject Tree;
        private int ran;
        public Transform ResponseTree;



        


        public float Time = 8.0f;
        




        void Start()
    {
                GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
                Time = gm.Time_Tree;
                InvokeRepeating("Invoke", 0, Time);
        }

        

        void Invoke()
        {
                
                Instantiate(Tree, ResponseTree.transform.position, ResponseTree.transform.rotation);
        }

        void SpawnCar()
        {
                
               

               



        }



    void Update()
    {
                
                  
    }
}
