using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EventPlayer : MonoBehaviour
{
    public TextMeshProUGUI CountCoinText;
    public GameObject Teleport;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinTag")) 
        {
            other.gameObject.SetActive(false);
            CountCoinText.text = (int.Parse(CountCoinText.text) + 1).ToString();

            if (int.Parse(CountCoinText.text) >= 20) 
            {
                   Teleport.SetActive(true);
            }
        }

        if (other.gameObject.CompareTag("FailTag"))
        {
            transform.position = new Vector3(0, 2.276f, -25.00607f);
        }

        if (other.gameObject.CompareTag("TeleportTag")) 
        {
            SceneManager.LoadScene("Level_2_Scene");
        }
    }

}
