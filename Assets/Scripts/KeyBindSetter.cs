using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyBindSetter : MonoBehaviour
{
    public string[] Keys;
    private int KeyIndex;

    private KeyCode[] KeyDefs;
    private int KeyDefIndex = 0;

    private bool completedBinding = false;
    public bool IsReady { get { return completedBinding; } }

	void Start () 
    {
        StartCoroutine(getKeys());
	}
	
    IEnumerator getKeys()
    {
        KeyIndex = 0;
        KeyDefs = new KeyCode[Keys.Length];
        while(KeyIndex < Keys.Length)
        {
            if(ReadKey())
            {
                KeyIndex++;
            }
            yield return null;
        }
        completedBinding = true; 
    }

    bool ReadKey()
    {
        KeyCode testKey = 0;

        for (int i = 0; i < 40; i++ )
        {
            if(Input.GetKeyDown(testKey))
            {
                //add to list of controls
                KeyDefs[KeyDefIndex] = testKey;
                KeyDefIndex++;
                return true;
            }
            testKey++;
        }
        return false;
    }

    void OnGUI()
    {
        if(!IsReady)
        {

        }
    }

	KeyCode[] getKeyDefs()
    {
        if(!IsReady)
        {
            return KeyDefs;
        }
        return null;
    }
}
