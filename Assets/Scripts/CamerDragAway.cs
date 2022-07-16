using UnityEngine;

public class CamerDragAway : MonoBehaviour
{
    public float panSpeed = 1f;

    // Update is called once per frame
    void Update()
    {

        Quaternion rot = transform.rotation;

        if (Input.GetKey("a"))
        {
            rot.y -= panSpeed * (Time.deltaTime / 7);
        } else if (Input.GetKey("d"))
        {
            rot.y += panSpeed * (Time.deltaTime / 7);
        } else if (Input.GetKey("w"))
        {
            rot.x -= panSpeed * (Time.deltaTime / 7);
        } else if (Input.GetKey("s")){
            rot.x += panSpeed * (Time.deltaTime / 7);
        }

        transform.rotation = rot;

    }
}
