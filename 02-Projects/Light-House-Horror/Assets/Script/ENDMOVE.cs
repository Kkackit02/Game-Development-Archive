using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDMOVE : MonoBehaviour
{

        private float fDestroyTime = 2.5f;
        private float fTickTime;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                fTickTime += Time.deltaTime;

                if (fTickTime >= fDestroyTime)
                { // 2초 뒤에 실행 

                        transform.position = new Vector3(0, 6, -9);
                        
                }
        }

}