using UnityEngine;

public class ClosePanelScript : MonoBehaviour
{
    public GameObject PanelWithStartButton;
    public GameObject PanelWithLevels;
    public GameObject PanelWithSettings;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PanelWithLevels.SetActive(false);
            PanelWithSettings.SetActive(false);
            PanelWithStartButton.SetActive(true);
        }
    }
}
