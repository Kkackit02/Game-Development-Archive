using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
        GameObject Parent;

        Rigidbody rigidbody;
        // Start is called before the first frame update
        void Start()
    {
                rigidbody = GetComponent<Rigidbody>();

                Parent = this.transform.parent.gameObject;
        }
        
    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter(Collider other)
    {
                if (other.transform.tag == "Destroy")
                {
                        Destroy(Parent);
                }



                
                
    }
}
