using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{

        public AudioSource audioSource;
        public AudioClip ShotSound;

        public GameObject CanonBall;

        public float FirstT = 1;
        public float SecondT = 3;

        public GameObject ResponseBall;
        public float Time = 2.0f;
        void Start()
    {

                audioSource = GetComponent<AudioSource>();
                audioSource.clip = ShotSound;

                audioSource.volume = 0.55f; //0.0f ~ 1.0f사이의 숫자로 볼륨을 조절
                audioSource.loop = false; //반복 여부
                audioSource.mute = false;
                audioSource.priority = 40;


                InvokeRepeating("Invoke", 0, Time);
        }

    
    void Update()
    {
        
    }


        void Invoke()
        {

                Invoke("SpawnCar", Random.Range(FirstT, SecondT));
                
        }


        void SpawnCar()
        {

                audioSource.Play();
                Instantiate(CanonBall, ResponseBall.transform.position, ResponseBall.transform.rotation);


        }
}
