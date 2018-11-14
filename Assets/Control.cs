using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
		if (Input.GetKey(KeyCode.Joystick1Button2))
            		{
                		this.transform.Translate(Vector3.left*0.1f,Space.Self);
            		}	
			
	}
}
