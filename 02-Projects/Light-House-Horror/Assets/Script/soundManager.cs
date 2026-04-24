using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
        public AudioClip soundExplosion;   //Audioclip이라는 데이터타입에 변수생성
        
        AudioSource myAudio; //컴퍼넌트에서 AudioSource가져오기
        
        public static soundManager instance; //다른 스크립트에서 이스크립트에있는 함수를 호출할때 쓰임

        void Awake()  // Start함수보다 먼저 호출됨
        {
                if (soundManager.instance == null)  //게임시작했을때 이 instance가 없을때
                        soundManager.instance = this;  // instance를 생성
        }
        // Use this for initialization
        void Start()
        {
                myAudio = GetComponent<AudioSource>();  //myAudio에 컴퍼넌트에있는 AudioSource넣기
                myAudio.Play();
                myAudio.loop = true;
        }

        public void PlaySound()
        {
                myAudio.volume = 1.0f;
        }

        public void Stop()
        {
                myAudio.volume = 0f;
                
        }

        // Update is called once per frame
        void Update()
        {

        }
}
//player스크립트 -> void OnTriggerEnter2D(Collider2D col)이곳에
//soundManager.instance.PlaySound(); 이거 추가

