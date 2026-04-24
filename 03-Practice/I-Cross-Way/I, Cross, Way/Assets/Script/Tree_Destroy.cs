using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Destroy : MonoBehaviour
{
        GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
                Parent = this.transform.parent.gameObject;
        }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerEnter(Collider other)
        {
                if (other.transform.tag == "House")
                {
                        Destroy(Parent);
                }





        }
}
