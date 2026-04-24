using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
        public float BallSpeed = 30.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                transform.Translate(Vector3.forward * BallSpeed * Time.deltaTime);
        }
}
