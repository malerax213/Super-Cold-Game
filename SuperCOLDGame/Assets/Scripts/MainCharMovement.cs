using UnityEngine;
using System.Collections;

public class MainCharMovement : MonoBehaviour
{


    public GameObject FPSCamera;
    public float horizontalSpeed;
    public float verticalSpeed;

    float h1, v1;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        h1 = horizontalSpeed * Input.GetAxis("Mouse X");
        v1 = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h1, 0);
        FPSCamera.transform.Rotate(-v1, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.1f);
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -0.1f);
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(-0.1f, 0, 0);
                }
                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.Translate(0.1f, 0, 0);
                    }
                }
            }
        }
    }
}