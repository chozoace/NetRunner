using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour 
{
    int damage = 5;
	void Start ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
         if(collider.name == "Player")
         {
             Debug.Log("Obstacle collision");
             collider.GetComponent<Player>().takeDamage(damage);
         }
    }

	void Update ()
    {
	
	}
}
