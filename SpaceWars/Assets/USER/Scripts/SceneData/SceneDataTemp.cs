/// <summary>
/// DATASTRUCTURE: Temporary settings and data only valid for the currently running session.
/// </summary>
public class SceneDataTemp
{
    //Default start of game at menu; private so no other script knows what it is
    private Enums.GameStates _gameState = Enums.GameStates.Menu;

    public Enums.GameStates gameState
    {
        //If someone asks for the public state, it will tell it whatever it is set to
        get { return _gameState; }

        //But if someone changes the game mode (no matter from wherever) we change and call the event system through GameManager
        //(we can listen to this in other scripts and so we dont have to write the tracking code multiple times;
        //basically, its this script thats doing all the job and telling the Game Manager)
        set 
        { 
            _gameState = value;
            GameManager.gameInstance._events.InvokeChangeMode(_gameState);
        }
    }
}
