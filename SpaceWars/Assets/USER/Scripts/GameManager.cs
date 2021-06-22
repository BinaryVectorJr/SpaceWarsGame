using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton - Allows us to access a monobehavior from anywhere in the game, and only one instance is called in the game, and it never gets destroyed.
    //Create an instance of ourselves
    public static GameManager gameInstance;

    //Data objects
    public SceneDataTemp u_DataTemp = new SceneDataTemp();
    public SceneDataSaved u_DataSaved = new SceneDataSaved();
    public SceneDataSettings u_DataSettings = new SceneDataSettings();
    public string u_DataPath;

    public GameManagerEvents _events = new GameManagerEvents();

    public LevelManager _levels;

    private void Awake()
    {
        SetupSingleton();
        InitData();
    }

    #region Singleton
    /// <summary>
    /// Singleton Class for the game. Exists once for the entire game.
    /// </summary>
    private void SetupSingleton()
    {
        //Check to see if there are other game instances running; when the GameManager gets created
        if (GameManager.gameInstance != null && GameManager.gameInstance != this)
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
    #endregion

    #region Data
    private void InitData()
    {
        //Loading in our settings and game save
        u_DataPath = Application.persistentDataPath + "/";
        u_DataSettings = u_DataSettings.Load();
        u_DataSaved = u_DataSaved.Load();
    }
    #endregion
}
