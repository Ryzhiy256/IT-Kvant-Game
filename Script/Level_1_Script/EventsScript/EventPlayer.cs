using UnityEngine;
using TMPro;

public class EventPlayer : MonoBehaviour
{
    public TextMeshProUGUI CountCoinText;

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
                //Тут должен быть скрипт появления перехода на новый уровень    
            }
        }

        if (other.gameObject.CompareTag("FailTag"))
        {
            transform.position = new Vector3(0, 2.276f, -25.00607f);
        }
    }

}
