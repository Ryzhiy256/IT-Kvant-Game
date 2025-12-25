using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{

    public GameObject PanelWithStartButton;
    public GameObject PanelWithLevels;
    public GameObject PanelWithSettings;

   

    public void OpenPanelWithLevels()
    {
        PanelWithStartButton.SetActive(false);
        PanelWithLevels.SetActive(true);
    }
    public void OpenPanelWithSettings() 
    {
        PanelWithStartButton.SetActive(false);
        PanelWithSettings.SetActive(true);
    }

    public void CloseGame() 
    {
        Debug.Log("yes");
        Application.Quit();
    }

    
}
