﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Head-Follow Mode")]
    [SerializeField] private int headFollowModeId = 0;
    [SerializeField] private Vector3 headFollowModeCamOffset = new Vector3(0f, 1.6f, 0f);
    [SerializeField] private float camSensitivity = 2.0f;
    [SerializeField] private Transform playerTransform;

    [Header("Interaction Mode")]
    [SerializeField] private int taskModeId = 1;
    [SerializeField] private GameObject focusObj;
    [SerializeField] private Vector3 taskModeCamOffset = new Vector3(0f, 0f, -2f);
    //interact with public variables

    //Visualization purpose
    [Header("Debugging data")]
    [SerializeField] private float xAxis, yAxis = 0.0f;
    private int currCamMode;

    private void Update(){

        if (currCamMode == headFollowModeId){
            HeadFollowMode();
        }
        else if(currCamMode == taskModeId){
            TaskMode(focusObj);
        }
    }

    public void ChangeCamMode(GameObject task){

        if (task == null){
            Debug.Log("Normal Mode");
            currCamMode = headFollowModeId;
            focusObj = null;
        }
        else{
            Debug.Log("Interaction Mode");
            currCamMode = taskModeId;
            focusObj = task;
        }
    }

    private void HeadFollowMode(){

        //Have same position as the attachTarget with an offset
        transform.position = playerTransform.position + headFollowModeCamOffset;

        //get mouse coords
        xAxis += camSensitivity * Input.GetAxis("Mouse X");
        yAxis -= camSensitivity * Input.GetAxis("Mouse Y");

        //convert mouse coords to eulerAngles 
        transform.eulerAngles = new Vector3(yAxis, xAxis, 0.0f);

        //same I too don't know wtf Euler Angles are but it works
        //Thanks StackOverflow
    }

    private void TaskMode(GameObject taskObj){
        transform.position = taskObj.transform.position + taskModeCamOffset;
    }
}