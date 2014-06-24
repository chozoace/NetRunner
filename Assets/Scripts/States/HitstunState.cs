using UnityEngine;
using System.Collections;

public class HitstunState : RunnerState
{
    public override string StateName { get { return "HitstunState"; } }
    float hitstunDuration = 2f;
    Player thePlayer;
    Vector2 v;

    public override void enter(Player player)
    {
        //start hitstun
        v = new Vector2(4, player.rigidbody2D.velocity.y);
        player.rigidbody2D.velocity = v;
        thePlayer = player;
        Invoke("endHitstun", 2f); //what the fuck do you mean null???
    }

    void endHitstun()
    {
        Debug.Log("ending");
        thePlayer.changeHitstun(RunnerState.noHitstun);
    }

    public override void exit(Player player)
    {
        //end hitstun
    }
    public override void handleInput(Player player, KeyCode input)
    {

    }
    public override void UpdateState(Player player)
    {
        //check for other state
        Debug.Log("Hitstunned");
    }
}
