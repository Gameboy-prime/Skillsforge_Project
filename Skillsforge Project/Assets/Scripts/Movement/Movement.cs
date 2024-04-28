using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 initialXPos;
    private Vector2 finalXPos;
    private Vector3 swipeVector;
    private bool isSwiping = false;
    [SerializeField] private float checkSwipeDistance = .02f;
    public float minimumSwipeDistance = .2f;

    private bool canSwipe;


    // Update is called once per frame
    void Update()
    {
        //Inputs
        if (Input.touchCount > 0 && !MenuManager.isPaused)
        {
            Touch touch = Input.GetTouch(0);

            // Only perform swipe detection if a swipe is not already in progress
            if (!isSwiping)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    initialXPos = touch.position;
                }
                else if (Mathf.Abs(touch.position.x - initialXPos.x) > .01f || Mathf.Abs(touch.position.y - initialXPos.y) > .01f)
                {
                    canSwipe = true;

                    finalXPos = touch.position;




                    if (canSwipe)
                    {
                        Swipe();
                        isSwiping = true;
                        //canSwipe= false;

                    }
                    /*Vector2 deltaPos = touch.position - initialXPos;
                    if (deltaPos.magnitude >= checkSwipeDistance)
                    {
                        finalXPos = touch.position;
                        isSwiping = true;
                        //Swipe();
                         // Set flag to indicate swipe is in progress
                    }*/
                }

            }
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isSwiping = false; // Reset flag when touch ends
            }
        }


        KeyBoardControls();


    }


    //This is if the controls are from a keyboard
    private void KeyBoardControls()
    {
        if (this.transform.position.x < Boundary.rightMove && Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(6, 0, 0));


        }
        if (this.transform.position.x > Boundary.leftMove && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-6, 0, 0));

        }

    }

    private void Swipe()
    {


        swipeVector = (finalXPos - initialXPos);
        float swipeMagnitudeX = swipeVector.x;
        float swipeMagnitudeY = swipeVector.y;

        swipeVector.Normalize();
        if (swipeVector.magnitude > minimumSwipeDistance)
        {
            //Check if the magintiude on the horixontal is greater than than the vertical to determine if it is up, down, left or right
            if (Mathf.Abs(swipeMagnitudeX) > Mathf.Abs(swipeMagnitudeY))
            {
                //Swipe Left or Right
                if (swipeVector.x > 0.0f && this.transform.position.x < Boundary.rightMove)
                {

                    transform.Translate(new Vector3(6, 0, 0));
                }
                else if (swipeVector.x < 0.0f && this.transform.position.x > Boundary.leftMove)
                {

                    transform.Translate(new Vector3(-6, 0, 0));
                }
            }
        }

    }
}
