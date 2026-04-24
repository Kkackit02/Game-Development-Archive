using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

        public enum State
        {
                Ready,
                Empty,
                Reloading
        }

        public State state { get; private set; }

        public Transform aim_D;
        public Transform aim_A;
        public Transform muzzle;
        public Transform Ori_muzzle;
        public Projectile projectile;
        
        public GameObject bullet_effect;
        public Transform shall_bullet;

        public GameObject Shot_effect;
        public Transform Shot_Light_point;


        public Animator player_animator;
        private AudioSource gunAudioPlayer;
        public AudioClip shotClip;
        public AudioClip reloadClip;
        public AudioClip noAmmoClip;

        public int ammoRemain = 357;
        public int magCapacity = 51;
        public int magAmmo;
        public float reloadTime = 5f;

        public float msBetweenShots = 0;

        public float msBetweenShots_O = 80;
        public float msBetWeenShots_A = 60;
        public float muzzleVelocity = 85;

        float nextShotTime;

        public List<Transform> Muzzle_List = new List<Transform>();





        


        public void Awake()
        {
                player_animator = GameObject.Find("Player_model").GetComponent<Animator>();
                gunAudioPlayer = GetComponent<AudioSource>();
        }
        public void OnEnable()
        {
                magAmmo = magCapacity;
                state = State.Ready;

        }
        public void Start()
        {
                aim_D = GameObject.Find("Aim").transform;
                aim_A = GameObject.Find("Aim_A").transform;

        }
        public void Update()
        {

                if(Input.GetMouseButton(2))
                {
                        msBetweenShots = msBetWeenShots_A;
                        this.gameObject.transform.LookAt(aim_A);
                }
                else
                {
                        msBetweenShots = msBetweenShots_O;
                        this.gameObject.transform.LookAt(aim_D);
                }



                
        }
        public void Shoot()
        {
                if (state == State.Ready)
                {
                        if (magAmmo <= 0)
                        {
                                state = State.Empty;
                                gunAudioPlayer.PlayOneShot(noAmmoClip);
                        }

                        else
                        {
                                if (Time.time > nextShotTime)
                                {
                                        if(Input.GetMouseButton(1))
                                        {
                                                muzzle = Ori_muzzle;
                                                
                                        }
                                        else
                                        {
                                                muzzle = Muzzle_List[Random.Range(0, 3)];
                                        }
                                        


                                        nextShotTime = Time.time + msBetweenShots / 1000;
                                        Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
                                        newProjectile.SetSpeed(muzzleVelocity);
                                        gunAudioPlayer.PlayOneShot(shotClip);
                                        Instantiate(bullet_effect, shall_bullet.transform.position, shall_bullet.transform.rotation);
                                        Instantiate(Shot_effect, Shot_Light_point.transform.position, Shot_Light_point.transform.rotation);
                                        magAmmo -= 1;
                                }
                        }
                }
               
        
        }

        public bool Reload()
        {
                if (state == State.Reloading || ammoRemain <= 0 || magAmmo >= magCapacity)
                {
                        return false;
                }

                StartCoroutine(ReloadRoutine());
                return true;
        }

        private IEnumerator ReloadRoutine()
        {
                player_animator.SetTrigger("Reload");
                player_animator.SetBool("Reload_Bool", true);
                state = State.Reloading;
                gunAudioPlayer.PlayOneShot(reloadClip);
                yield return new WaitForSeconds(reloadTime);

                int ammoToFill = magCapacity - magAmmo;

                if (ammoRemain < ammoToFill)
                {
                        ammoToFill = ammoRemain;
                }

                magAmmo += ammoToFill;
                ammoRemain -= ammoToFill;

                player_animator.SetBool("Reload_Bool", false);
                state = State.Ready;
                

        }
}
