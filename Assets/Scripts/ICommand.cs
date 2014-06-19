using UnityEngine;
using System.Collections;

public class ICommand
{
    public ICommand() { }
    public virtual void Execute() { }
    public virtual void ExecuteRelease() { }
};

class JumpCommand : ICommand
{
    public override void Execute() { jump(); }
    public override void ExecuteRelease() { }

    Player player = Player.Instance();
    float jumpSpeed = Player.Instance().JumpSpeed;

    void jump()
    {
        Debug.Log("Jumping");
        //change to air state
        player.changeState(RunnerState.airborne);
        Vector2 v = player.rigidbody2D.velocity;
        v.y = jumpSpeed;
        player.rigidbody2D.velocity = v;
    }
    void jumpRelease()
    {

    }
}

class DashCommand : ICommand
{
    public override void Execute() { dash(); }
    public override void ExecuteRelease() { dashRelease(); }

    void dash()
    {
        Debug.Log("Dashing");
        //change to dash state
    }
    void dashRelease()
    {

    }
}

class RightMoveCommand : ICommand
{
    public override void Execute() { rightMove(); }
    public override void ExecuteRelease() { rightMoveRelease(); }

    Player player = Player.Instance();

    void rightMove()
    {
        player.MovingRight = true;
        //change to run state
    }
    void rightMoveRelease()
    {
        Debug.Log("released");
        player.MovingRight = false;
    }
}

class LeftMoveCommand : ICommand
{
    public override void Execute() { leftMove(); }
    public override void ExecuteRelease() { leftMoveRelease(); }

    Player player = Player.Instance();

    void leftMove()
    {
        player.MovingLeft = true;
        //change to run state
    }
    void leftMoveRelease()
    {
        player.MovingLeft = false;
    }
}

class SlideCommand : ICommand
{
    public override void Execute() { slide(); }
    public override void ExecuteRelease() { slideRelease(); }

    void slide()
    {
        //change to slide state
        Debug.Log("slide");
    }
    void slideRelease()
    {

    }
}