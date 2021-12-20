using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    private NavMeshAgent _agent;

    private Animator _anim;

        
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
                Debug.Log("Point: " + _agent.destination);
            }           
        }

        var distance = (_agent.destination - transform.position);            
        
        if (distance.x == 0f)
        {

            _anim.SetBool("Walk", false);
        }
    }
}
