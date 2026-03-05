using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float LeftBorder;
    public float RightBorder;

    private bool check = false;


    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            if (transform.position.x > LeftBorder) { transform.position -= new Vector3(5 * Time.deltaTime, 0, 0); }
            else { check = false; }
        }
        else 
        {
            if (transform.position.x < RightBorder) { transform.position += new Vector3(5 * Time.deltaTime, 0, 0); }
            else { check = true; }
        }
    }
}
