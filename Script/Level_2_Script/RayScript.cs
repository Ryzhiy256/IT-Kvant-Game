using UnityEngine;

public class RayScript : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Clue;

    private bool CheckTouchObject = false;


    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject touchObject;

        if (Physics.Raycast(ray, out hit)) 
        {
            touchObject = hit.collider.gameObject;
            if (hit.collider.gameObject.tag == "TouchTag") 
            {
                Clue.SetActive(true);
            }
            else { Clue.SetActive(false); }

            if (hit.collider.gameObject.tag == "TouchTag" && Input.GetKeyDown(KeyCode.E)) 
            {
                Ray test = Camera.main.ScreenPointToRay(Input.mousePosition);
                var p = test.origin + test.direction * 10f;
                touchObject.transform.position = p;


                //Vector3 touchObjectPositionWihtMouse = new Vector3(touchObject.transform.position.x + Input.GetAxis("Mouse X"),
                //        touchObject.transform.position.y + Input.GetAxis("Mouse Y"),
                //        transform.position.z + Mathf.Abs(Mathf.Abs(touchObject.transform.position.z) - Mathf.Abs(transform.position.z)));
                ////Vector3 positionMouse = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Mathf.Abs(Mathf.Abs(touchObject.transform.position.z) - Mathf.Abs(transform.position.z)));
                //touchObject.transform.position = Vector3.Lerp(touchObject.transform.position, touchObjectPositionWihtMouse, Time.deltaTime);
                if (transform.forward.z > 0f) 
                {
                    
                }
                else if (transform.forward.x > 0f) 
                {

                }
                //Vector3 positionMouse = new Vector3(0, Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
                //touchObject.transform.position = Vector3.Lerp(touchObject.transform.position, positionMouse, Time.deltaTime);
                //touchObject.transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
                //Debug.Log("Yes");
            }
            string objectTag = hit.collider.gameObject.tag;
            Debug.Log(objectTag);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) { CheckTouchObject = false; }
    }
}
