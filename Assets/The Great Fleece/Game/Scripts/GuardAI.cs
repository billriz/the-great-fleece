using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GuardAI : MonoBehaviour
{
  
    [SerializeField]
    List<Transform> wayPoints;
    [SerializeField]
    private int _targetPos;

    private NavMeshAgent _agent;
    private Animator _anim;


    private bool _reverse;
    private bool _atTarget;

    void Start()
    {

        _agent = GetComponent<NavMeshAgent>();

        _anim = GetComponent<Animator>();
               
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[_targetPos] != null)
        {
            if (_atTarget == false)
            {
                _agent.SetDestination(wayPoints[_targetPos].position);
                _anim.SetBool("Walk", true);
            }               
            

            var distance = (wayPoints[_targetPos].position - transform.position);

            if (distance.x == 0f && _atTarget == false)
            {
               if (wayPoints.Count < 2)
                {
                    _anim.SetBool("Walk", false);
                    return;

                }

               if (_targetPos == 0 || (_targetPos == wayPoints.Count - 1 && _reverse == false))
                {
                    _atTarget = true;
                    StartCoroutine("GuardIdle");
                }
                

                if (_reverse == true)
                {
                    _targetPos--;
                    if(_targetPos == 0)
                    {
                        _reverse = false;
                        _targetPos = 0;
                    }                    
                }
                else
                {
                    _targetPos++;
                    if (_targetPos == wayPoints.Count)
                    {
                        _reverse = true;
                        _targetPos--;
                    }
                }
            }
        }       
        
    }

    IEnumerator GuardIdle()
    {
        _anim.SetBool("Walk", false);
        yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        _atTarget = false;


    }
}
