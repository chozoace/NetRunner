using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    static Player instance = null;

    [SerializeField] KeyCode jumpKey;
    [SerializeField] KeyCode dashKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode beamKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode slideKey;
        
    [SerializeField] float moveSpeed;
    [SerializeField] float rightMoveSpeed;
    [SerializeField] float leftMoveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
    [SerializeField] float jumpSpeed;
    public float JumpSpeed { get { return jumpSpeed; } }
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;
    float groundRadius = .02f;

    private bool MovingRight;
    public bool IsMoveRight { get { return MovingRight; } set { MovingRight = value; } }
    private bool MovingLeft;
    public bool IsMoveLeft { get { return MovingLeft; } set { MovingLeft = value; } }
    private bool grounded = false;
    public bool IsGrounded { get { return grounded; } }
    bool prevGrounded = false;
    string currentState;
    public string CurrentState { get { return currentState; } }

    ICommand jumpButton;
    ICommand dashButton;
    ICommand slideButton;
    ICommand beamButton;
    ICommand rightButton;
    ICommand leftButton;

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
        myState = RunnerState.running;
        Vector2 startVelocity = new Vector2(moveSpeed, 0);
        this.rigidbody2D.velocity = startVelocity;
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
            v.x = moveSpeed;
            rigidbody2D.velocity = v;
        }
        else if(MovingLeft && !MovingRight)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = leftMoveSpeed;
            rigidbody2D.velocity = v;
        }
        else if(MovingRight && !MovingLeft)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = rightMoveSpeed;
            rigidbody2D.velocity = v;
        }
        else if(!MovingLeft && !MovingRight)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = moveSpeed;
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
        currentState = myState.StateName;

        Debug.Log(myState);
	}
}
