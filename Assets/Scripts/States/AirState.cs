using UnityEngine;
using System.Collections;

public class AirState : RunnerState
{
    public override string StateName { get { return "AirState"; } }

    public override void enter(Player player)
    {
        //Debug.Log("Change to Air Anim");
    }
    public override void exit(Player player)
    {
        //Debug.Log("End air anim");
    }
    public override void handleInput(Player player, KeyCode input)
    {
        
    }
    public override void UpdateState(Player player)
    {
        if(player.IsGrounded && player.rigidbody2D.velocity.y <= 0)
        {
            player.changeState(RunnerState.running);
        }
    }
}