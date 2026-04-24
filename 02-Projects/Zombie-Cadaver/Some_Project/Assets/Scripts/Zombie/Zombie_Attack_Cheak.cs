using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Attack_Cheak : MonoBehaviour
{
        public Player_anim player_ani;
        public GameManager Gm;
    void Start()
    {
                Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
                player_ani = GameObject.Find("Player_model").GetComponent<Player_anim>();
        }

    

    void Update()
    {
        
    }

        public void OnTriggerEnter(Collider other)
        {
                if(other.tag == "Player")
                {
                        Gm.Ondamage(15);
                }
        }
}
