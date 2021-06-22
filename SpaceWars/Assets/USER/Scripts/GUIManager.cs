using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public void StartBattlezone()
    {
        GameManager.gameInstance._levels.LoadLevel(Enums.Levels.Battlezone);
    }
}
