using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour 
{
    
	void Start () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //next level
            GameController.Instance().nextLevel();
        }
    }
	
	void Update () 
    {
	
	}
}
