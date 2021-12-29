using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
   
    [SerializeField]
    private GameObject _gameOverCutScene;
    [SerializeField]
    private Animator _anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            Color color = new Color(.6f, .1f, .1f, .3f);
            renderer.material.SetColor("_TintColor", color);
            _anim.enabled = false;
            StartCoroutine(AlertRoutine());

        }
    }

    IEnumerator AlertRoutine()
    {

        yield return new WaitForSeconds(0.5f);
        _gameOverCutScene.SetActive(true);

    }
}
