using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{




        public void isStart()
        {
                SceneManager.LoadScene("MainGame");
        }
        public void isExit()
        {
                print("Quit!");
                Application.Quit();
        }
        public void Menu()
        {

                SceneManager.LoadScene("Menu");
        }


}

