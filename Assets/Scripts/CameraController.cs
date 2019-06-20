using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform rotationTarget;
    Transform target;
    float zoomDistance;
    float scrollSensitivity = 3f;

    public float minDistance=3f;
    public float maxDistance=100f;

    public float rotationSensitivity = 1f;
    public float angle1;
    public float angle2;
    Vector3 lastPosition;
    // Start is called before the first frame update

    private void Awake()
    {
        rotationTarget = transform.parent;
        target = rotationTarget.transform.parent;

        zoomDistance = Vector3.Distance(target.position,transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        
        if(Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;     
        }
        if (Input.GetMouseButtonDown(2))
        {
            lastPosition = Input.mousePosition;
        }
    
    //   Zoom();
        Orbit();
    }
    void Zoom()
    {
        float num = Input.GetAxis("Mouse ScrollWheel");
        zoomDistance -= num * scrollSensitivity;

        zoomDistance = Mathf.Clamp(zoomDistance, minDistance, maxDistance);
        Vector3 pos = target.position;
        pos -= transform.forward * zoomDistance;
        transform.position = Vector3.Lerp(transform.position, pos, scrollSensitivity);
    }

    void Orbit()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            float angleY = -delta.y * rotationSensitivity;
            float angleX = delta.x * rotationSensitivity;

            Vector3 angles = rotationTarget.transform.eulerAngles;
            angles.x += angleY*Time.deltaTime;
            angles.x = Mathf.Clamp(angles.x, angle1, angle2);

            rotationTarget.transform.eulerAngles = angles;
            target.transform.RotateAround(target.position, Vector3.up, angleX*Time.deltaTime);         
        }
    }
}
