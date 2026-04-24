using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{

        public AudioSource audioSource;
        public AudioClip Bgm_main;

        public static bgm Instance;

        private void Awake()
        {
                if (Instance != null)
                {
                        Destroy(gameObject);
                        return;
                }

                Instance = this;
                DontDestroyOnLoad(transform.gameObject);
        }





        // Start is called before the first frame update
        void Start()
    {
                

                audioSource = GetComponent<AudioSource>();
                audioSource.clip = Bgm_main;

                audioSource.volume = 0.25f; //0.0f ~ 1.0f사이의 숫자로 볼륨을 조절
                audioSource.loop = true; //반복 여부
                audioSource.mute = false;
                audioSource.priority = 100;

                audioSource.Play();

                
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
