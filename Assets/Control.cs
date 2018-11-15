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

	public void give(){
		permission = true;
	}
	
	public void removePermission(){
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
			if (Input.GetAxis("Horizontal")<0 && Input.GetAxis("Horizontal")>-0.95){
				this.transform.Rotate(Vector3.down*0.5f,Space.Self);
			}
			if (Input.GetAxis("Horizontal")>0 && Input.GetAxis("Horizontal")<0.95){
				this.transform.Rotate(Vector3.up*0.5f,Space.Self);
			}
			if (Input.GetAxis("Horizontal")>=0.95)
			{
				this.transform.Rotate(Vector3.left*0.5f,Space.Self);
			}
			if (Input.GetAxis("Horizontal")<=-0.95)
			{
				this.transform.Rotate(Vector3.right*0.5f,Space.Self);
			}
			if (Input.GetKey(KeyCode.Joystick1Button0))
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
			if (Input.GetKey(KeyCode.Joystick1Button2))
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
