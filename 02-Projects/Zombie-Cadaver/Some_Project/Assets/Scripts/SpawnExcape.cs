using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExcape : MonoBehaviour
{
        public int ran;
        public List<Vector3> Spawn_Vector3 = new List<Vector3>(); 
    void Start()
    {
                ran = Random.Range(0, 3);
                this.gameObject.transform.position = Spawn_Vector3[ran]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
                
        private void OnTriggerExit(Collider other)
        {
                if(other.tag == "Player")
                {
                        Destroy(this);
                }
        }

}
