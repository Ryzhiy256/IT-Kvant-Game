using UnityEngine;

public class RayScript : MonoBehaviour
{
    private string targetTag = "TouchTag";
    private float dragDistance = 5f;
    private float speed = 10f;

    private Rigidbody currentTarget;
    private Camera cam;

    public GameObject panelWithClue;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        //Для появления и исчезновения подсказки
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag(targetTag))
            {
                panelWithClue.SetActive(true);
            }
            else
            {
                panelWithClue.SetActive(false);
            }
        }

        //Захват необходимого объект и отключение его физики
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.transform.CompareTag(targetTag))
                {
                    currentTarget = hit.collider.GetComponent<Rigidbody>();
                    panelWithClue.SetActive(true);

                    currentTarget.useGravity = false;
                    currentTarget.linearVelocity = Vector3.zero;
                    currentTarget.angularVelocity = Vector3.zero;
                }
                else 
                {
                    panelWithClue.SetActive(false);
                }
            }
        }

        

        if (Input.GetKeyUp(KeyCode.E)) 
        {
            currentTarget.useGravity = true;   
            currentTarget = null;

        }

    }

    private void FixedUpdate()
    {
        if (currentTarget != null)
        {
            Vector3 targetPosition = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, dragDistance));

            Vector3 direction = targetPosition - currentTarget.position;

            currentTarget.linearVelocity = direction * speed;


        }
    }
}
