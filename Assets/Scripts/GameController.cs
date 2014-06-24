using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    static GameController instance;
    int currentLoadedLevel;

    public static GameController Instance()
    {
        if (instance != null)
            return instance;
        else
        {
            return null;
            //error
        }
    }

	void Start () 
    {
        instance = this;
        currentLoadedLevel = Application.loadedLevel;
	}

    public void nextLevel()
    {
        Debug.Log("loading next level");
        Application.LoadLevel(currentLoadedLevel + 1);
    }

	void Update () 
    {
	    
	}
}
