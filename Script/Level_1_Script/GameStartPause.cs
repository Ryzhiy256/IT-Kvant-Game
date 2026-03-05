using UnityEngine;

public class GameStartPause : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame() 
    {
        Time.timeScale = 1;
    }
}
