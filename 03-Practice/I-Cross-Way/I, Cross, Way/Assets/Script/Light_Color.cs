using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Color : MonoBehaviour
{

        public GameObject LIGHT_1_R;
        public GameObject LIGHT_1_G;

        public GameObject LIGHT_2_R;
        public GameObject LIGHT_2_G;


        public bool isGreen = false;

        // Start is called before the first frame update
        void Start()
    {
                InvokeRepeating("LIGHT", 5, 5);
        }


        public void LIGHT()
        {

                if (isGreen == true)
                {
                        
                        LIGHT_2_G.gameObject.SetActive(false);
                        LIGHT_2_R.gameObject.SetActive(true);
                        LIGHT_1_G.gameObject.SetActive(false);
                        LIGHT_1_R.gameObject.SetActive(true);
                        isGreen = false;
                }



                else
                {
                        
                        LIGHT_2_G.gameObject.SetActive(true);
                        LIGHT_2_R.gameObject.SetActive(false);
                        LIGHT_1_G.gameObject.SetActive(true);
                        LIGHT_1_R.gameObject.SetActive(false);
                        isGreen = true;
                }



        }
        // Update is called once per frame
        void Update()
    {
        
    }
}
