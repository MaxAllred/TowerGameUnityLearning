using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true; 

    public float panSpeed = 30f;   
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 15f;
    public float maxY = 60f;
    public float minZ = 0;
    public float maxZ = 67;
    public float minX = 33;
    public float maxX = 110;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {           
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        //scroll positioning & clamp
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

        // vertical positioning & clamp 
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;

        // horizontal positioning & clamp 
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;

    }
}
