using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotate : MonoBehaviour
{
        Camera viewCamera;
        private Vector3 mousePos;
        //public GameObject Gun_Muzzle;
        //public Transform aim;


        //public float rotSpeed_X = 3.0f;

        void Start()
    {
                viewCamera = Camera.main;
        }

    // Update is called once per frame
    void Update()
    {
                /*
                Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float rayDistance;

                if (groundPlane.Raycast(ray, out rayDistance))
                {
                        Vector3 point = ray.GetPoint(rayDistance);
                        this.gameObject.transform.LookAt(point);
                        Gun_Muzzle.transform.LookAt(point);
                }

        */


                /*
                float MouseX = Input.GetAxis("Mouse X");
                float MouseY = Input.GetAxis("Mouse Y");


                transform.Rotate(Vector3.up * rotSpeed_X * MouseX);
                Gun_Muzzle.transform.LookAt(aim);
                */


        }
}
