using UnityEngine;

public class RotateCubeY : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 45f, 0) * Time.deltaTime);
    }
}
