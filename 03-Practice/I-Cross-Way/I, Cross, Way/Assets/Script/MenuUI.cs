using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuUI : MonoBehaviour
{


        public bool Hardmode_Button = false;
        // Start is called before the first frame update
        void Start()
    {
                

    }

        public void OnClickStartButton()
        {
                Cursor.visible = false;
                SceneManager.LoadScene(1);

        }



        public void OnClickExitButton()
        {
                Application.Quit();
        }

        public void OnClickMenuButton()
        {
                Cursor.visible = true;
                
                SceneManager.LoadScene(0);

        }

        public void OnClickCopyrightButton()
        {
                Cursor.visible = true;
                
                SceneManager.LoadScene(19);

        }
}
