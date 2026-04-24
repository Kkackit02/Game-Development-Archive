using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{

    public int random_value;

    void Start()
    {
        //StartCoroutine(Random_Walk());
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    IEnumerator Random_Walk()
    {

            random_value = Random.Range(0, 4);
            Debug.Log(random_value);

            if (random_value == 0)
            {
                transform.Translate(0.15f, 0, 0);
            }
            else if (random_value == 1)
            {
                transform.Translate(-0.15f, 0, 0);
            }
            else if (random_value == 2)
            {
                transform.Translate(0, 0.15f, 0);

            }
            else if (random_value == 3)
            {
                transform.Translate(0, -0.15f, 0);
            }
            else
            {

            }

            yield return new WaitForSeconds(0.001f);
    }
        

    public void Move()
    {
        StartCoroutine(Random_Walk());
    }
}
