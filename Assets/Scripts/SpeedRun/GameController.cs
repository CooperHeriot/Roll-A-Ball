using UnityEngine;

public enum GameType { Normal, SpeedRun }
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameType gameType;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void SetGameType(GameType _gameType)
    {
        gameType = _gameType;
    }

    public void ToggleSpeedRun(bool _gameType)
    {
        if (_gameType)
            SetGameType(GameType.SpeedRun);
        else
            SetGameType(GameType.Normal);
    }
}
