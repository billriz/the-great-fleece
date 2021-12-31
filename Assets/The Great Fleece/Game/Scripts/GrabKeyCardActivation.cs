using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _grabKeyCardCutScene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            _grabKeyCardCutScene.SetActive(true);
            GameManager.Instance.HasCard = true;

        }
    }


}
