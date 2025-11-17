using UnityEngine;

public class CameraPixelFixer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Round(transform.parent.position.x), Mathf.Round(transform.parent.position.y), transform.parent.position.z);
    }
}
