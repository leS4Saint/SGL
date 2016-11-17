using UnityEngine;
using System.Collections;

public class CamScroll : MonoBehaviour
{
    //obvious
    public float cameraMoveSpeed = 2;
    //margin for the left/right borders of the screen
    public int lrMargin = Screen.width / 10;
    //same as above but up/down
    public int udMargin = Screen.height / 10;
    //position of mouse on screen
    public Vector2 mousePos;
    //this is for toggling the camera control type
    public bool cameraType = false;

    void Update()
    {
        //i let these update every frame so if the player resizes the window the margins stay the same percentage of screen
        lrMargin = Screen.width / 10;
        udMargin = Screen.height / 10;
        //gets the positon of mouse on screen
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        //toggles camera type
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (cameraType == true)
            {
                cameraType = false;
                //resets the camera to the standard rotation
                transform.rotation = Quaternion.Euler(32.45f, 0, 0);
            }
            else
            {
                cameraType = true;
            }
        }

        //this block runs if the camera is at standard mode
        if (cameraType == false)
        {
            //these 4 if statements check if the mouse is in the screen margins and move the camera
            if (mousePos.x < lrMargin || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += -transform.right * ShiftCheck();
            }
            if (mousePos.x > Screen.width - lrMargin || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += transform.right * ShiftCheck();
            }
            if (mousePos.y < udMargin || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += -Vector3.forward * ShiftCheck();
            }
            if (mousePos.y > Screen.height - udMargin || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.forward * ShiftCheck();
            }

            //these zoom in and out
            if (Input.GetKey(KeyCode.E))
            {
                transform.position += transform.forward * ShiftCheck();
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position += -transform.forward * ShiftCheck();
            }
        }

        //this block runs if camera is in free fly mode
        if (cameraType == true)
        {
            //should be obvious
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += -transform.right * ShiftCheck();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += transform.right * ShiftCheck();
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += -transform.forward * ShiftCheck();
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += transform.forward * ShiftCheck();
            }
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(0, 0, 1 * ShiftCheck(), Space.Self);
            }
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, -1 * ShiftCheck(), Space.Self);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.up * ShiftCheck();
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += -transform.up * ShiftCheck();
            }
            //makes the camera rotate if you hold right mouse button
            if (Input.GetButton("Fire2"))
            {
                transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            }
        }
    }

    //this function checks if you hold shift and if so multiplies camera move speed
    float ShiftCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return cameraMoveSpeed * 3;
        }
        else
        {
            return cameraMoveSpeed;
        }
    }
}