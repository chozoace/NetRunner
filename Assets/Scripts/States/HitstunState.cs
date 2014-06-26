using UnityEngine;
using System.Collections;
using System.Timers;

public class HitstunState : RunnerState
{
    public override string StateName { get { return "HitstunState"; } }
    double hitstunDuration = 1000;
    Player thePlayer;
    Vector2 v;
    Timer hitstunTimer = new Timer();

    public override void enter(Player player)
    {
        //start hitstun
        v = new Vector2(4, player.rigidbody2D.velocity.y);
        player.rigidbody2D.velocity = v;
        thePlayer = player;
        hitstunTimer.Interval = hitstunDuration;
        hitstunTimer.Elapsed += new ElapsedEventHandler(endHitstun);
        hitstunTimer.Enabled = true;
    }

    void endHitstun(object sender, ElapsedEventArgs e)
    {
        Debug.Log("ending");
        thePlayer.changeHitstun(RunnerState.noHitstun);
        hitstunTimer.Stop();
    }

    public override void exit(Player player)
    {
        //end hitstun
        player.resetInputs();
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
