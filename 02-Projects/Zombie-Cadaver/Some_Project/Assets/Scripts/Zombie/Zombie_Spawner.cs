using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawner : MonoBehaviour
{

        private WaitForSeconds ws;
        public bool isDie = false;
        public GameObject Zombie;

        public GameManager Gm;

        public float MaxSpawnTime = 5.0f;
        public float MinSpawnTime = 1.0f;


        // Start is called before the first frame update
        void Start()
    {

                Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
                MaxSpawnTime = Gm.MaxSpawnTime;
                MinSpawnTime = Gm.MinSpawnTime;
                StartCoroutine(ZombieSpawner());
        }

    // Update is called once per frame
    void Update()
    {
                
        }




        IEnumerator ZombieSpawner()
        {
                while (!isDie)
                {
                        ws = new WaitForSeconds(3f);


                        Instantiate(Zombie, this.gameObject.transform.position, this.gameObject.transform.rotation);



                        yield return ws;





                }

        }

}
