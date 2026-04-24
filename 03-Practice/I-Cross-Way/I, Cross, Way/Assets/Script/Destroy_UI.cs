using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

                this.gameObject.SetActive(true);
        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) == true)
                {
                        Destroy(this.gameObject);
                }

    }
}
