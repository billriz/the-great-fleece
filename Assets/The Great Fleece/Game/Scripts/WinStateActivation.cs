using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _winGameCutScene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (GameManager.Instance.HasCard == true)
            {

                _winGameCutScene.SetActive(true);
            }
            else
            {

                Debug.Log("Must Have Card");
            }

        }
    }


}
