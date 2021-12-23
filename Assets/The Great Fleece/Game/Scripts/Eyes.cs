using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    
    
    [SerializeField]
    private GameObject _gameOvercutScene;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameOvercutScene.SetActive(true);

        }
    }

}
