using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    Player player;
    float moveSpeed;
    Vector3 moveVel;

	void Start ()
    {
        player = Player.Instance();
        moveSpeed = player.MoveSpeed;
        moveVel = new Vector3(moveSpeed, 0, 0);
        this.rigidbody2D.velocity = moveVel;
	}

	void Update () 
    {
        
	}
}
