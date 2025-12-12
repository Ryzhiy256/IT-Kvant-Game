using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public void LoadScene(string nameScene) 
    {
        SceneManager.LoadScene(nameScene);
    }
}
