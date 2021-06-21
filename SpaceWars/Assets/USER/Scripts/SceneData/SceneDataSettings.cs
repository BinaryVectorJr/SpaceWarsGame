using System.Collections.Generic;

/// <summary>
/// DATASTRUCTURE: Persistent for all game saves, and long term storage.
/// </summary>
public class SceneDataSettings
{
    public string version = "0.1";
    public string filename = "settings.dat";
    public string lastSave = "save1.dat";

    /// <summary>
    /// Saver and loader for the settings
    /// </summary>
    #region Save/Load Settings
    public void Save()
    {
        SceneDataWriter.Save(GameManager.gameInstance.u_DataPath + filename, this);
    }

    public SceneDataSettings Load()
    {
        var settings = SceneDataWriter.Load<SceneDataSettings>(GameManager.gameInstance.u_DataPath + filename);

        if (settings != null)
        {
            return settings;
        }

        return this;
    }
    #endregion
}
