using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 prevMousePosition;
    public float sensitivity = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 deltaMouse = prevMousePosition - Input.mousePosition;
            GetComponent<Transform>().transform.position += deltaMouse * sensitivity;

        }
        prevMousePosition = Input.mousePosition;
    }
}
