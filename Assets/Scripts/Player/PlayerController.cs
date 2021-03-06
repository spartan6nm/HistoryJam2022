using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public enum PlayerState { NONE, Idle , Moving}
    public PlayerState currentState = PlayerState.NONE; 

    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Seeker seeker;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float nextWayPointDistance;
    [SerializeField]
    private protected Vector2 direction;
    [SerializeField]
    private float perspectiveScale;
    [SerializeField]
    private float scaleRatio;

    bool firstUpdatePathThisRound = true; //this is to change the path code if we are doing it while the agent is moving

    private Vector3 _targetPoint;

    public Vector3 targetPoint
    {
        get { return _targetPoint; }
        set 
        {
            _targetPoint = value;
            GotoState(PlayerState.Moving);
        }
    }


    private Path path;
    int currentWayPoint = 0;
    bool reached;







    private void Awake()
    {
        EventBroker.PlayerMove += NewLocationToMove;
        EventBroker.PlayerStop += StopMoving;

    }

    private void OnDisable()
    {
        EventBroker.PlayerMove -= NewLocationToMove;
        EventBroker.PlayerStop += StopMoving;
    }
    // Start is called before the first frame update
    void Start()
    {
        ScaleCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                ActionUpdate_Idle();
                break;
            case PlayerState.Moving:
                ActionUpdate_Moving();
                break;
        }
        AdjustScale();
    }



    private void NewLocationToMove(Vector3 point)
    {
        targetPoint = point;
    }

    private void StopMoving()
    {
        GotoState(PlayerState.Idle);
    }


    private void AdjustScale()
    {
        Vector3 scale = transform.localScale;
        scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        /*
        if (scale.y < 3.5f)
        {
            scale.y = 3.5f;
            scale.x = 3.5f;
        }
        else if (scale.y > 4.5f)
        {
            scale.y = 4.5f;
            scale.x = 4.5f;
        }
        */
        
        transform.localScale = scale;

    }



    public void ScaleCheck()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                scaleRatio = 3;
                break;
            case 3:
                scaleRatio = 12;
                break;
            case 4:
                scaleRatio = 4;
                break;
            case 5:
                scaleRatio = 10;
                break;
        }
    }

    private void UpdatePath()
    {
        if (seeker.IsDone() && targetPoint != null)
        {
            if (firstUpdatePathThisRound)
            {
                seeker.StartPath(transform.position, targetPoint, OnPathComplete);
                firstUpdatePathThisRound = false; // after we have updated the path for the first time we change this value so every other time untill the ageent is stopped this code is not run
            }
            else
            {
                seeker.StartPath(path.vectorPath[currentWayPoint], targetPoint, OnPathComplete);
            }

        }

    }


    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }



    public void GotoState(PlayerState state)
    {
        if (currentState != PlayerState.NONE)
        {
            switch (currentState)
            {
                case PlayerState.Idle:
                    ActionEnd_Idle();
                    break;
                case PlayerState.Moving:
                    ActionEnd_Moving();
                    break;
            }
        }

        currentState = state;

        if (currentState != PlayerState.NONE)
        {
            switch (currentState)
            {
                case PlayerState.Idle:
                    ActionInit_Idle();
                    break;
                case PlayerState.Moving:
                    ActionInit_Moving();
                    break;
            }
        }

    }



    private void ActionInit_Moving()
    {
        firstUpdatePathThisRound = true;
        InvokeRepeating("UpdatePath", 0.0f, 0.3f);
        EventBroker.CallPlaySound("footStep");
    }
    private void ActionUpdate_Moving()
    {
        try
        {
            if (path == null)
                return;


            direction = ((Vector2)path.vectorPath[currentWayPoint] - rigidBody.position).normalized;

            rigidBody.velocity = direction * speed * Time.fixedDeltaTime;

            float distance = Vector2.Distance(rigidBody.position, path.vectorPath[currentWayPoint]);

            if (distance < nextWayPointDistance)
            {
                currentWayPoint++;
            }

            if (currentWayPoint >= path.vectorPath.Count)
            {
                reached = true;
                CancelInvoke("UpdatePath");
                GotoState(PlayerState.Idle);
                return;
            }
            else
                reached = false;
        }
        catch (Exception e)
        {
            return;
        }
        
    }
    private void ActionEnd_Moving()
    {
        rigidBody.velocity = Vector2.zero;
        EventBroker.CallStopSound("footStep");
        firstUpdatePathThisRound = false;
        CancelInvoke("UpdatePath");
        
    }

    private void goIdle()
    {
        GotoState(PlayerState.Idle);
    }


    private void ActionInit_Idle()
    {

    }
    private void ActionUpdate_Idle()
    {

    }
    private void ActionEnd_Idle()
    {

    }
}
