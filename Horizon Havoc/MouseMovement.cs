using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float MouseSensitivity = 200f;

    public float TopClamp = -90f;
    public float BottomClamp = 90f;

    float xRotation = 0f;
    float yRotation = 0f;

    public Camera camera; 

    // Start is called before the first frame update
    void Start()
    { 
        //nothing in here :)
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor is hidden by default. Hold tab to see cursor position
        if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //This gets input from mouse 
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;   

        //Mouse rotation
        yRotation += MouseX; //horizontal rotation
        xRotation -= MouseY; //vertical rotation

        //Restricting or clamping rotation 
        xRotation = Mathf.Clamp(xRotation, TopClamp, BottomClamp);

        //Applying rotation to transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
