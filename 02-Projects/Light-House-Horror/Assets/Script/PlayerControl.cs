using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{ 


        public float moveSpeed = 5.0f;
        public float rotSpeed = 3.0f;
        public Transform Enemy;

        public Camera fpsCam;

        void Start()
        {
                Cursor.lockState = CursorLockMode.Locked;//마우스 커서 고정
                Cursor.visible = false;//마우스 커서 보이기

        }

        void Update()
        {
                MoveCtrl();
                RotCtrl();
        }

        void MoveCtrl()
        { //키보드 W,S,A,D Player 이동 함수
                if (Input.GetKey(KeyCode.W))
                {
                        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                        this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.A))
                {
                        this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D))
                {
                        this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }

        }

        
       

                void RotCtrl()
        { //마우스 회전 시점이동 함수
                float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
                float rotY = Input.GetAxis("Mouse X") * rotSpeed;

                this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
                fpsCam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
        }
}