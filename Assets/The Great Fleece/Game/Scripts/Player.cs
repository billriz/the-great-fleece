using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    private NavMeshAgent _agent;

    private Animator _anim;
    [SerializeField]
    private GameObject _coin;
    [SerializeField]
    private bool _hasThrownCoin;

        
    // Start is called before the first frame update
    void Start()
    {

        _agent = GetComponent<NavMeshAgent>();

        _anim = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
          
        if (Input.GetMouseButtonDown(0))
        {

            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                _anim.SetBool("Walk", true);
               // Debug.Log("Point: " + _agent.destination);
            }           
        }

        var distance = (_agent.destination - transform.position);            
        
        if (distance.x == 0f)
        {

            _anim.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && _hasThrownCoin == false)
        {
            _anim.SetTrigger("Throw");
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(_coin, hitInfo.point, Quaternion.identity);
                _hasThrownCoin = true;
                SendGuardtoCoinPos(hitInfo.point);
            }
        }

        void SendGuardtoCoinPos(Vector3 CoinPos)
        {
            GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");

            foreach(var guard in guards)
            {
                NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
                GuardAI currentAI = guard.GetComponent<GuardAI>();
                Animator currentAnim = guard.GetComponent<Animator>();

                currentAI.coinTossed = true;
                currentAgent.SetDestination(CoinPos);
                currentAnim.SetBool("Walk", true);
                currentAI.coinPos = CoinPos;
            }
        }
    }
}
