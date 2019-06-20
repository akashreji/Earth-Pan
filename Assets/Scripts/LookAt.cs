using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAt : MonoBehaviour
{

    public float zoom = 5f;
    public float speed = 2f;
    public Transform target1;
    bool moveCamera = false;
   public Vector3 targetPosition;
    Vector3 firstPosition;
    Quaternion playerRot;

    public GameObject IndiaCam;

    string tagName;
    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
        Vector3 distanceVector = transform.position - targetPosition;
        Vector3 distanceVectorNormalized = distanceVector.normalized;
        targetPosition = (distanceVectorNormalized * zoom);
    }

    // Update is called once per frame
    void Update()
    {

       if (Input.GetMouseButtonDown(1))
        {
            setTarget();
        }
        if (Input.GetMouseButtonDown(3))
            transform.position = Vector3.Lerp(transform.position, firstPosition, speed * Time.deltaTime);
        if (moveCamera)
        move();
    }

    private void move()
    {
        // Vector3 offset = new Vector3(0, 0, -2f);
        
        transform.position = Vector3.Lerp(transform.position,IndiaCam.transform.position, speed * Time.deltaTime);
        
        if (transform.position == targetPosition) 
        moveCamera = false;
    }

    public void setTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,1000))
        {
            targetPosition = hit.point;
            Debug.Log(hit.collider.gameObject.tag);

            tagName = hit.collider.gameObject.tag;
            
           
            if(tagName=="India")
            moveCamera = true;
           // IndiaCam.gameObject.GetComponent<Transform>();
           

        }
    }
}
