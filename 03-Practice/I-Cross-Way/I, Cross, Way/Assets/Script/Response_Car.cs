using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response_Car : MonoBehaviour
{
        public GameManager gm;
        public GameObject[] CarNumber;
        private int ran;
        public Transform ResponseCar;



        public float GM_F;
        public float GM_S;


        public float Time;
        




        void Start()
    {
                GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
                Time = gm.Time_GM;
                InvokeRepeating("Invoke", 0, Time);
        }

        

        void Invoke()
        {
                Invoke("SpawnCar", Random.Range(GM_F, GM_S));
        }

        void SpawnCar()
        {
                Debug.Log("생성");
                ran = Random.Range(0, CarNumber.Length);
                //Debug.Log(ran);
                Instantiate(CarNumber[ran], ResponseCar.transform.position, ResponseCar.transform.rotation);

                GM_F = gm.First_Time;
                GM_S = gm.Seconde_Time;



        }



    void Update()
    {
                
                  
    }
}
