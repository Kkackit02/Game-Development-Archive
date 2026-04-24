using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_destroy : MonoBehaviour
{
        public float time_Max;
        float count;
        public void Update()
        {
                count = count + 3 * Time.deltaTime;

                if (count > time_Max)
                {
                        Destroy(this.gameObject);
                }
        }
}