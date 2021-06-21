/// <summary>
/// DATASTRUCTURE: Long term storage. Stores details of session, for future use. AKA Save File Data
/// </summary>
public class SceneDataSaved
{
    /// <summary>
    /// Saver and loader for data
    /// </summary>
    #region Save/Load Data
    public void Save()
    {
        SceneDataWriter.Save(GameManager.gameInstance.u_DataPath + GameManager.gameInstance.u_DataSettings.lastSave, this);
    }

    public SceneDataSaved Load()
    {
        var save = SceneDataWriter.Load<SceneDataSaved>(GameManager.gameInstance.u_DataPath + GameManager.gameInstance.u_DataSettings.lastSave);

        if (save != null)
        {
            return save;
        }

        return this;
    }
    #endregion
}
