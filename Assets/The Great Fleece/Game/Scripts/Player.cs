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

                //Debug.Log("Hit: " + hitInfo.point);
                _agent.SetDestination(hitInfo.point);
                _anim.SetBool("Walk", true);
            }
        }
        var heading = _agent.destination - transform.position;

        Debug.Log(heading);
        
        if (heading.x == 0f)
        {

            _anim.SetBool("Walk", false);
        }
    }
}
