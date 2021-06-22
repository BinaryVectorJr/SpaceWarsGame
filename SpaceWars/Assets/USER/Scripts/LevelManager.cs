using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Creating a container of a custom type "Level"
    [Serializable]
    public struct Level
    {
        public Enums.Levels gameLevel;
        public int levelID;
    }

    [SerializeField]
    public List<Level> gameLevels = new List<Level>();

    public void LoadLevel(Enums.Levels levelType)
    {
        if(gameLevels.Any(x=>x.gameLevel == levelType))
        {
            var currentLevel = gameLevels.FirstOrDefault(x => x.gameLevel == levelType);
            SceneManager.LoadScene(currentLevel.levelID);
        }
        else
        {
            Debug.LogWarning("Level could not be found: " + levelType.ToString());
        }
    }
}
