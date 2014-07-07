using UnityEngine;
using System.Collections;

public class RunnerState : MonoBehaviour
{
    public static RunState running = new RunState();
    public static AirState airborne = new AirState();
    public static NoHitstun noHitstun = new NoHitstun();
    public static HitstunState hitstunned = new HitstunState();
    public static IdleState idle = new IdleState();

    public virtual string StateName { get { return "Default"; } }

    public RunnerState() { }
    public virtual void enter(Player player) { }
    public virtual void exit(Player player) { }
    public virtual void handleInput(Player player, KeyCode input) { }
    public virtual void UpdateState(Player player) { }
}