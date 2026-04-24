using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans_Regdoll : MonoBehaviour
{
        public GameObject Player_Origin;
        public GameObject Player_Regdoll;
        public Vector3 pos;

    void Start()
    {

                Player_Origin = GameObject.Find("Player_Origin");
                pos = Player_Origin.transform.position;

        }

    // Update is called once per frame
    void Update()
    {
                pos = Player_Origin.transform.position;
        }

        void OnEnable()
        {

                
                Player_Origin = GameObject.Find("Player_Origin");
                Player_Regdoll = GameObject.Find("Regdoll_Player");
                pos = Player_Origin.transform.position;
                Player_Regdoll.transform.position = new Vector3(pos.x,pos.y,pos.z);
        }
}
