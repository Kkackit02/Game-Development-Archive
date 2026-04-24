using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        
        public Text Mag_Ammo_Text;
        public Text RemainMag_Ammo_Text;

        public Gun gun;
        public float ammo = 0;
        public float Remain_ammo = 0;

        public bool isdie = false;
        public int Player_Health = 100;
        public Slider Health;
        public Animator Player_Animator;
        void Start()
        {


                Health = GameObject.Find("PlayerHealth").GetComponent<Slider>();
                Player_Animator = GameObject.Find("Player_model").GetComponent<Animator>();
                Health.value = Player_Health;
                isdie = false;
                GameObject.Find("Player").GetComponent<CapsuleCollider>().enabled = true;
                gun = GameObject.Find("Gun1(Clone)").GetComponent<Gun>();
                Cursor.visible = false;
        }

    // Update is called once per frame
    void Update()
    {
                ammo = gun.magAmmo;
                Remain_ammo = gun.ammoRemain;

                Mag_Ammo_Text.text = "" + ammo;
                RemainMag_Ammo_Text.text = "" + Remain_ammo;
                //ammo_text.text = ammo;
        }


        public void Ondamage(int damage)
        {
                Health.value -= damage;
                Player_Animator.SetTrigger("isAttack");

                if(Health.value <= 0)
                {
                        PlayerDead();
                }
        }

        public void PlayerDead()
        {
                isdie = true;
                StopAllCoroutines();
                Player_Animator.SetTrigger("Die");
                GameObject.Find("Player").GetComponent<CapsuleCollider>().enabled = false;
        }
}
