using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //InputHandler inputHandler;
    static Player instance = null;

    [SerializeField] KeyCode jumpKey;
    [SerializeField] KeyCode dashKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode beamKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode slideKey;
    
    
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
    [SerializeField] float jumpSpeed;
    public float JumpSpeed { get { return jumpSpeed; } }
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;
    float groundRadius = .02f;

    public bool MovingRight;
    public bool MovingLeft;
    bool grounded = false;
    bool prevGrounded = false;

    ICommand jumpButton;//jump
    ICommand dashButton;//dash
    ICommand slideButton;//slide
    ICommand beamButton;//charge and shoot
    ICommand rightButton;//right
    ICommand leftButton;//left

    RunnerState myState;

    public static Player Instance()
    {
        if (instance != null)
        {
            return instance;
        }
        else
        {
            return null;
            //Error
        }
    }

	void Start () 
    {
        instance = this;
        MovingLeft = false;
        MovingRight = false;
        bindKeys();
        //myState = new RunnerState();
        myState = RunnerState.running;


       //inputHandler = new InputHandler();
	}

    public void changeState(RunnerState state)
    {
        myState.exit(this);
        myState = state;
        myState.enter(this);
    }

    void bindKeys()
    {
        jumpButton = new JumpCommand();
        dashButton = new DashCommand();
        rightButton = new RightMoveCommand();
        leftButton = new LeftMoveCommand();
        slideButton = new SlideCommand();
    }

    void getKeysDown()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            jumpButton.Execute();
        }
        else if(Input.GetKeyDown(dashKey))
        {
            dashButton.Execute();
        }
        else if(Input.GetKeyDown(rightKey))
        {
            rightButton.Execute();
        }
        else if(Input.GetKeyDown(leftKey))
        {
            leftButton.Execute();
        }
        else if(Input.GetKeyDown(slideKey))
        {
            slideButton.Execute();
        }
    }

    void getKeysUp()
    {
        if(Input.GetKeyUp(jumpKey))
        {
            jumpButton.ExecuteRelease();
        }
        else if(Input.GetKeyUp(dashKey))
        {
            dashButton.ExecuteRelease();
        }
        else if (Input.GetKeyUp(rightKey))
        {
            rightButton.ExecuteRelease();
        }
        else if(Input.GetKeyUp(leftKey))
        {
            leftButton.ExecuteRelease();
        }
        else if(Input.GetKeyUp(slideKey))
        {
            slideButton.ExecuteRelease();
        }
    }

    void UpdateMovement()
    {
        if(MovingRight && MovingLeft)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = 0;
            rigidbody2D.velocity = v;
        }
        else if(MovingLeft && !MovingRight)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = -MoveSpeed;
            rigidbody2D.velocity = v;
        }
        else if(MovingRight && !MovingLeft)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = MoveSpeed;
            rigidbody2D.velocity = v;
        }
        else if(!MovingLeft && !MovingRight)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = 0;
            rigidbody2D.velocity = v;
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
	
	void Update ()
    {
        getKeysDown();
        getKeysUp();
        UpdateMovement();
        myState.Update(this);

        //Debug.Log(myState);
        if (!prevGrounded && grounded)
        {
            changeState(RunnerState.running);
            myState = RunnerState.running;
            prevGrounded = true;
        }
        else if (!grounded)
            prevGrounded = false;
	}
}
