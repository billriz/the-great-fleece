using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
  
    [SerializeField]
    private AudioClip _voClip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            AudioSource.PlayClipAtPoint(_voClip, Camera.main.transform.position);

        }
    }
}
