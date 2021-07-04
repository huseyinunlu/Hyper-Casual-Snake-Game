using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartandPause : MonoBehaviour
{
    bool isReady = false;
    public bool isStarted = false;

    LeadingPoint leadingP;
    GameObject gesture;
    public bool isFinished = false;
    CameraMovement mainCamera;

    float number = 0f;
    bool reduce = false;

    GameObject beforeStartPanel;
    GameObject startPanel;
    public GameObject finishPanel;
    float timer = 0;

    void Start()
    {
        finishPanel = GameObject.Find("Finished");
        gesture = GameObject.Find("Gesture");
        leadingP = GameObject.Find("0").GetComponent<LeadingPoint>();
        beforeStartPanel = GameObject.Find("beforeStartPanel");
        startPanel = GameObject.Find("StartPanel");
        mainCamera = FindObjectOfType<CameraMovement>();
    }

    void Update()
    {
        if (isReady)
        {
            mainCamera.startPosition = true;
            beforeStartPanel.transform.position = new Vector3(1080,0,0);
            startPanel.transform.position = new Vector3(0,0,0);
            GestureMove();
        }
        BeginToMove();
        Finish();
    }

    private void GestureMove()
    {

        if (number > 1f)
        {
            reduce = true;
        }
        if (number < -1f)
        {
            reduce = false;
        }
        if (reduce)
        {
            number -= Time.deltaTime * 3;
        }
        else
        {
            number += Time.deltaTime * 3;
        }
        gesture.transform.position = new Vector3((number * 200) + (Screen.width / 2), gesture.transform.position.y, gesture.transform.position.z);
    }


    private void BeginToMove()
    {
        if (Input.touchCount<0 && isReady)
        {

            isReady = false;
            isStarted = true;
            GameObject.Find("InfoForController").SetActive(false);
            gesture.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && isReady)
        {

            isReady = false;
            isStarted = true;
            GameObject.Find("InfoForController").SetActive(false);
            gesture.SetActive(false);
        }
    }

    private void Finish()
    {
        if (isFinished)
        {
            timer += Time.deltaTime;
            if (timer < .3f)
            {
                finishPanel.transform.position = new Vector3(0, 0, 0);
            }
            
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
