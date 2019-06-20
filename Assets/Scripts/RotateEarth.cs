using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public float rotspeed;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotspeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotspeed * Mathf.Deg2Rad;
        Debug.Log(rotX);
      
        transform.Rotate(Vector3.up, -rotX, Space.World);
        
        transform.Rotate(Vector3.right, rotY, Space.World);
    }
    // Update is called once per frame
    void Update()
    {

    }
   
}
