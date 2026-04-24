using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

        public float Speed = 1.0f;
        public GameObject Target;
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                move();
    }

        public void move()
        {


                Vector3 dir = Target.transform.position - transform.position;
                dir.Normalize();

                transform.position += dir * Speed * Time.deltaTime;
        }
}
