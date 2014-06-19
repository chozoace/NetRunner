using UnityEngine;
using System.Collections;

public class InputHandler {
    public KeyCode spaceKey;
    public KeyCode jKey;

    ICommand spaceButton;
    ICommand jButton;
    
	void Start () 
    {
        bindKeys();
	}

    void bindKeys()
    {
        spaceKey = KeyCode.Space;
        jKey = KeyCode.J;

        spaceButton = new JumpCommand();
        jButton = new DashCommand();
    }

    public void handleInput()
    {
        //Left move
        //Right move
        //Jump
        if (Input.GetKeyDown(spaceKey))
        {
            spaceButton.Execute();
        }
        //Charge beam
        //Shoot beam
        //Dash
        else if (Input.GetKeyDown(jKey))
        {
            jButton.Execute();
        }
        //Slide
        
    }
	
	public void Update () 
    {
        handleInput();
	}
}
