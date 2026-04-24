using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Ctr : MonoBehaviour
{

        public enum State
        {
                IDLE,
                TRACE,
                ATTACK,
                DIE
        }
        public GameObject BloodEffect;
        //몬스터의 상태를 저장할 변수
        public State state = State.IDLE;

        public float attackDist = 2.0f;
        public float traceDist = 10.0f;
        public float hp = 100.0f;




        public float MaxHP = 200.0f;
        public float MinHP = 50.0f;


        public float MaxSpeed = 4.5f;
        public float MinSpeed = 2.0f;




        public Transform BloodPoint;
        public bool isDie = false;

        public GameObject LeftHand;
        public GameObject RightHand;

        private WaitForSeconds ws;

        private Transform monsterTr;
        private Transform playerTr;
        private NavMeshAgent agent;
        private Animator monsterAni;
        private Rigidbody rd;

        private int hashTrace = Animator.StringToHash("isTrace");
        private int hashAttack = Animator.StringToHash("isAttack");
        private int hashDie = Animator.StringToHash("Die");
        private int hashHit = Animator.StringToHash("Hit");

        public GameManager Gm;


        public List<GameObject> ZombieTextures = new List<GameObject>();

        void Awake()
        {

                
                ws = new WaitForSeconds(0.3f);
                        rd = GetComponent<Rigidbody>();
                        agent = GetComponent<NavMeshAgent>();
                        monsterTr = GetComponent<Transform>();
                        monsterAni = GetComponent<Animator>();
                        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                        StartCoroutine(CheckMonsterState());
                        StartCoroutine(MonsterAction());
                        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();

                        agent.speed = Random.Range(MaxSpeed, MinSpeed);
                        hp = Random.Range(MaxHP, MinHP);


          

                for (int i = 0; i < 48; i++)
                {
                        ZombieTextures[i].SetActive(false);
                }
                int idx = Random.Range(0, 48);
                ZombieTextures[idx].SetActive(true);
             

        }
       



                IEnumerator CheckMonsterState()
                {
                        while (!isDie)
                        {
                                yield return ws;

                                float dist = Vector3.Distance(monsterTr.position, playerTr.position);
                                //몬스터와 주인공간의 거리가 공격사정거리 이내인 경우
                                if (dist <= attackDist)
                                {
                                        state = State.ATTACK;
                                }
                                //공격사정거리보다 크고 추적사정거리 이내인 경우
                                else if (dist <= traceDist)
                                {
                                        state = State.TRACE;
                                }
                                else if (hp <= 0)
                                {
                                        state = State.DIE;
                                }
                                else
                                {
                                        state = State.IDLE;
                                }


                        }
                }



    


                IEnumerator MonsterAction()
                {
                        while (!isDie)
                        {
                                switch (state)
                                {
                                        case State.IDLE:
                                                agent.isStopped = true;
                                                monsterAni.SetBool(hashTrace, false);

                                                break;


                                        case State.TRACE:
                                                agent.SetDestination(playerTr.position);
                                                agent.isStopped = false;
                                                monsterAni.SetBool(hashTrace, true);
                                                monsterAni.SetBool(hashAttack, false);
                                                //this.transform.LookAt(playerTr);

                                                break;

                                        case State.ATTACK:

                                                monsterAni.SetBool(hashAttack, true);
                                                break;

                                        case State.DIE:

                                                break;


                                }
                                yield return ws;


                        }

                }



        // Update is called once per frame


        private void Update()
        {
                
                
        }


        public void OnTriggerEnter(Collider other)
                {
                        if (other.tag == "Bullet")
                        {
                                Debug.Log("Hit");
                                hp -= Random.Range(25f, 75f);
                                if (hp > 0)
                                {
                                        monsterAni.SetTrigger(hashHit);
                                        //스파크이펙트를 동적으로 생성      - Instantiate(객체, 위치, 각도);
                                        //quaternion.LookRotation(벡터) --> 벡터의 각도를 쿼터니언 타입으로 변환(산출)
                                        GameObject Blood = Instantiate(BloodEffect, BloodPoint.position, BloodPoint.rotation);
                                        Destroy(Blood, 0.6f);
                                }




                                if (hp <= 0.0f)
                                {

                                        StopAllCoroutines();
                                        state = State.DIE;
                                        agent.isStopped = true;
                                        agent.height = 0;
                                        agent.enabled = false;
                                        GetComponent<CapsuleCollider>().enabled = false;
                                        isDie = true;
                                        rd.useGravity = false;
                                        monsterAni.SetTrigger(hashDie);
                                        RightHand.GetComponent<SphereCollider>().enabled = false;
                                        LeftHand.GetComponent<SphereCollider>().enabled = false;


                                }

                        }

         
                if (Gm.isdie == true)
                {
                        Debug.Log("PlayerDead");
                        float dist = Vector3.Distance(monsterTr.position, playerTr.position);
                        if (dist <= attackDist)
                        {
                                monsterAni.SetTrigger("Eat");
                        }
                        
                        //StopAllCoroutines();
                        agent.isStopped = true;

                }


                        
                }





                void MonsterDie()
                {


                }


        
                public void Damage(float damage)
                {
                        monsterAni.SetTrigger(hashHit);
                        hp -= damage;


                        if (hp <= 0.0f)
                        {
                                MonsterDie();
                        }
                }

                public void Animation_OFF()
                {
                        monsterAni.enabled = false;
                }

        }


