public class GameManagerEvents
{
    //Events always have 3 pieces - Delegate (in-charge of running the pieces of the event), the event itself, and a way to invoke it

    public delegate void gameModeChanged(Enums.GameStates state);
    public event gameModeChanged doGameModeChanged;

    public void InvokeChangeMode(Enums.GameStates state)
    {
        if(doGameModeChanged != null)
        {
            doGameModeChanged(state);
        }
        
    }
}
