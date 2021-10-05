using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Range(-10f, 10f)] public float speed = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            TranslateUp();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TranslateLeft();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            TranslateDown();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TranslateRight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            TranslateForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            TranslateBack();
        }
    }

    void TranslateUp()
    {
        transform.position += new Vector3(0, speed, 0);
    }

    void TranslateLeft()
    {
        transform.position += new Vector3(-speed, 0, 0);
    }

    void TranslateDown()
    {
        transform.position += new Vector3(0, -speed, 0);
    }

    void TranslateRight()
    {
        transform.position += new Vector3(speed, 0, 0);
    }

    void TranslateForward()
    {
        transform.position += new Vector3(0, 0, speed);
    }

    void TranslateBack()
    {
        transform.position += new Vector3(0, 0, -speed);
    }

}
