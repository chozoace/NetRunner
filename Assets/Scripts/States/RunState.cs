using UnityEngine;
using System.Collections;

public class RunState : RunnerState
{
    public override string StateName { get { return "RunState"; } }

    public override void enter(Player player)
    {
        Debug.Log("start running anim");
    }
    public override void exit(Player player)
    {
        Debug.Log("end running anim");
    }
    public override void handleInput(Player player, KeyCode input)
    {

    }
    public override void UpdateState(Player player)
    {
        if(!player.IsGrounded)
        {
            player.changeState(RunnerState.airborne);
        }
        else
        {
            if(player.CurrentSpeed.x == 0)
            {
                player.changeState(RunnerState.idle);
            }
        }
    }
}
