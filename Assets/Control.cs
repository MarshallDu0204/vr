using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control : MonoBehaviour {
    AudioSource audioData;
	bool permission = false;
	// Use this for initialization
	void Start () {
		audioData = GetComponent<AudioSource>();
	}

	public void give(){//give the permission to control the robot
		permission = true;
	}
	
	public void removePermission(){// remove the permission
		permission = false;
	}


	
	// Update is called once per frame
	void Update () {
		if (permission == true) {
			if (Input.GetAxis("Vertical")<0){
				this.transform.Rotate(Vector3.forward*0.5f,Space.Self);
			}
			if (Input.GetAxis("Vertical")>0){
				this.transform.Rotate(Vector3.back*0.5f,Space.Self);
			}
			if (Input.GetAxis("Horizontal")<0 && Input.GetAxis("Horizontal")>-0.95){//light push for first kind of turn
				this.transform.Rotate(Vector3.down*0.5f,Space.Self);
			}
			if (Input.GetAxis("Horizontal")>0 && Input.GetAxis("Horizontal")<0.95){
				this.transform.Rotate(Vector3.up*0.5f,Space.Self);
			}
			if (Input.GetAxis("Horizontal")>=0.95)// hard push for second turn
			{
				this.transform.Rotate(Vector3.left*0.5f,Space.Self);
			}
			if (Input.GetAxis("Horizontal")<=-0.95)
			{
				this.transform.Rotate(Vector3.right*0.5f,Space.Self);
			}
			if (Input.GetKey(KeyCode.Joystick1Button0))//go
			{
				this.transform.Translate(Vector3.right*0.1f,Space.Self);
			}
			if (Input.GetKeyDown(KeyCode.Joystick1Button0))
			{
				audioData.Play(0);
			}
			if (Input.GetKeyUp(KeyCode.Joystick1Button0))
			{
				audioData.Pause();
			}
			if (Input.GetKey(KeyCode.Joystick1Button2))//back
			{
				this.transform.Translate(Vector3.left*0.1f,Space.Self);						
			}
			if (Input.GetKeyDown(KeyCode.Joystick1Button2))
			{
				audioData.Play(0);
			}
			if (Input.GetKeyUp(KeyCode.Joystick1Button2))
			{
				audioData.Pause();
			}	
			
		}
		
	}

}
