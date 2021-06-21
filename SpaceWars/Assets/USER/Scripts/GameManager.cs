using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton - Allows us to access a monobehavior from anywhere in the game, and only one instance is called in the game, and it never gets destroyed.

    /// <summary>
    /// Singleton Class for the game. Exists once for the entire game.
    /// </summary>
    public static GameManager gameInstance;    //Create an instance of ourselves

    private void Awake()
    {
        //Check to see if there are other game instances running; when the GameManager gets created
        if(GameManager.gameInstance != null && GameManager.gameInstance != this)
        {
            //Optional TODO: Debug message "Game Instance already exists";
            Destroy(this);
            return;
        }

        gameInstance = this;
        //Even if we change to a different level or scene, keep this existing game manager copy we have right now
        //Root makes it so that we keep track of the entire stack i.e. whatever it is attached to (temp assignments would never come back null <- safety net)
        GameObject.DontDestroyOnLoad(transform.root.gameObject);   
    }

}
