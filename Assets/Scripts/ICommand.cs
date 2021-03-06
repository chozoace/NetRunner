﻿using UnityEngine;
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
    public override void ExecuteRelease() { jumpRelease(); }

    Player player = Player.Instance();
    float jumpSpeed = Player.Instance().JumpSpeed;

    void jump()
    {
        if (player.CurrentState != "AirState")
        { 
            player.changeState(RunnerState.airborne);
            Vector2 v = player.rigidbody2D.velocity;
            v.y = jumpSpeed;
            player.rigidbody2D.velocity = v;
        }
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
        player.IsMoveRight = true;
    }
    void rightMoveRelease()
    {
        player.IsMoveRight = false;
    }
}

class LeftMoveCommand : ICommand
{
    public override void Execute() { leftMove(); }
    public override void ExecuteRelease() { leftMoveRelease(); }

    Player player = Player.Instance();

    void leftMove()
    {
        player.IsMoveLeft = true;
    }
    void leftMoveRelease()
    {
        player.IsMoveLeft = false;
    }
}

class SlideCommand : ICommand
{
    public override void Execute() { slide(); }
    public override void ExecuteRelease() { slideRelease(); }

    void slide()
    {
        Debug.Log("slide");
    }
    void slideRelease()
    {

    }
}