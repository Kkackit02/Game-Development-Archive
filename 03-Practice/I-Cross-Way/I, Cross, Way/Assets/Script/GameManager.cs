using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        public float O_Speed = 0.0f;
        public float P_Speed = 15.0f;
        public float Time_GM = 0.7f;
        public float Time_Tree = 7f;
        public float First_Time = 0.0f;
        public float Seconde_Time = 0.3f;

        int i;
        int Now_Stage = 0;
        public Text timeText;
        public Text Stage;
        public GameObject gameoverText;
        public Text recordText;
        public GameObject Claer;
        public Text ClearText;


        public AudioSource audioSource;
        public AudioClip DieSound;
        public AudioClip ClearSound;
        public AudioClip AgainGame;


        

        float[] bestTime =  new  float [17];


        public float goalTime;
        public bool isGameover;
        public bool isClaer;

        public float P_walk = 2.5f;
        public float P_Run = 5.5f;

        void Start()
    {
                Cursor.visible = false;

                O_Speed = P_Speed;

                goalTime = 0;

                isGameover = false;
                isClaer = false;

                audioSource = GetComponent<AudioSource>();
                audioSource.clip = DieSound;

                audioSource.volume = 0.15f; //0.0f ~ 1.0f사이의 숫자로 볼륨을 조절
                audioSource.loop = false; //반복 여부
                audioSource.mute = false;
                audioSource.priority = 0;

                for (i = 0; i < 17; i++)
                {
                        if (SceneManager.GetActiveScene().buildIndex == i)
                        {
                                Now_Stage = i;
                                Debug.Log(i);
                                Debug.Log(Now_Stage);

                                if (Now_Stage == 18)
                                {
                                        Cursor.visible = false;
                                }

                                if (Now_Stage == 0)
                                {
                                        Cursor.visible = true;
                                }

                                else
                                {
                                        Cursor.visible = false;
                                }

                                
                        }
                }
        }

        // Update is called once per frame
        

        void Update()
        {
                
                
                



               if (isGameover == false)
                {
                        goalTime += Time.deltaTime;
                        timeText.text = "Time : " + (int)goalTime;
                        Stage.text = "Stage : " + Now_Stage;
                        if (isClaer == true)
                        {
                                if (Input.GetKeyDown(KeyCode.P))
                                {
                                        SceneManager.LoadScene(Now_Stage + 1);
                                }

                                if(Input.GetKeyDown(KeyCode.R))
                                {
                                        SceneManager.LoadScene(Now_Stage);
                                        audioSource.volume = 0.5f;
                                        audioSource.PlayOneShot(AgainGame);
                                }
                        }
                }

                else
                {

                        Claer.SetActive(false);
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                                SceneManager.LoadScene(Now_Stage);
                        }
                }

               
        }


        public void Die()
        {
                isGameover = true;
                audioSource.volume = 1f;
                audioSource.Play();
                gameoverText.SetActive(true);
                string S_BestTime = "BestTime" + Now_Stage;
                bestTime[Now_Stage] = PlayerPrefs.GetFloat(S_BestTime);
                recordText.text = "Best Time : " + (int)bestTime[Now_Stage];

        }

        public void Goal()
        {

                Debug.Log("골");
                isClaer = true;

                string S_BestTime = "BestTime" + Now_Stage;
                bestTime[Now_Stage] = PlayerPrefs.GetFloat(S_BestTime);
                



                if (goalTime < bestTime[Now_Stage])
                {
                        
                        bestTime[Now_Stage] = goalTime;

                        PlayerPrefs.SetFloat(S_BestTime, bestTime[Now_Stage]);
                }

                if (bestTime[Now_Stage] == 0)
                {
                        bestTime[Now_Stage] = goalTime;

                        PlayerPrefs.SetFloat(S_BestTime, bestTime[Now_Stage]);
                }
                ClearText.text = "Best Time : " + (int)bestTime[Now_Stage];
                Claer.SetActive(true);
                audioSource.volume = 0.5f;
                audioSource.PlayOneShot(ClearSound);


        }

        public void RegdollSound()
        {
                audioSource.Play();     
        }


}
