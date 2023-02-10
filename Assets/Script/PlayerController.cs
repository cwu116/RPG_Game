using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    CurState curstate;
    NavMeshAgent agent;

    Vector3 destination;
    // Start is called before the first frame update

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        MouseManager.instance.OnMouseClicked += MovePlayer;
        curstate = CurState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (curstate)
        {
            case CurState.idle:
                animator.Play("Idle_Battle");
                break;
            case CurState.run:
                animator.Play("RunForwardBattle");
                break;
        }

        CheckArrive();
    }

    public void MovePlayer(Vector3 destination)
    {
        curstate = CurState.run;
        agent.destination = destination;
        this.destination = destination;
    }

    void CheckArrive()
    {
        if ((transform.position - destination).magnitude < 0.5)
            curstate = CurState.idle;
    }
}

enum CurState
{
    idle,
    run
}
