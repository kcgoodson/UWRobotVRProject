using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{

    Rigidbody myBody;
    public float speed;


    void Start()
    {
        myBody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = myBody.transform.position;
            position.x--;
            myBody.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = myBody.transform.position;
            position.x++;
            myBody.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = myBody.transform.position;
            position.y++;
            myBody.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = myBody.transform.position;
            position.y--;
            myBody.transform.position = position;
        }
    }

    }
   