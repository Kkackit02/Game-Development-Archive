using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

       
        public AudioClip footSound;

        void OnTriggerEnter(Collider _col)
        {
                if (_col.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                        AudioSource.PlayClipAtPoint(footSound, transform.position);
                }
        }
        
}
