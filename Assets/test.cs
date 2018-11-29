﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
	
	public Image img;  
	public float gazeTime = 0f;    
	public float waitTime = 3f;     
	public string name;
	public string previousname;
	public GameObject mainoption1;
	public GameObject mainoption2;
	public GameObject mainoption3;
	public GameObject spot1;
	public GameObject spot2;
	public GameObject spot3;
	public GameObject spot4;
  	//private Material otherMat;
	public Control control;
	
	public GameObject breakObject1;
	public GameObject breakObject2;
	public GameObject breakObject3;
	public GameObject breakObject4;
	
	public GameObject repairObject1;
	public GameObject repairObject2;
	public GameObject repairObject3;
	public GameObject repairObject4;
	public GameObject repairObject5;
	public GameObject repairObject6;
	public GameObject repairObject7;
	
	public GameObject cover1;
	public GameObject cover2;
	
	public int open1 = 0;
	public int open2 = 0;
	
	public Texture breakTexture;
	
	public int switch1 = 0;
	
	public int repairIndex1 = 0;
	public int repairIndex2 = 0;
	public int repairIndex3 = 0;
	public int repairIndex4 = 0;
	
	public Texture fixTexture1;
	public Texture fixTexture2;

	// Use this for initialization
	void Start () {
	}
	
	void controller (int type){
		Destroy(mainoption1);
		Destroy(mainoption2);
		Destroy(mainoption3);
		if (type==1){//real mode
			switch1 = 1;
			Destroy(spot1);
			Destroy(spot2);
			Destroy(spot3);
			Destroy(spot4);
			
			breakObject1.GetComponent<Renderer>().material.color = Color.black;
			breakObject2.GetComponent<Renderer>().material.color = Color.yellow;
			breakObject3.GetComponent<Renderer>().material.mainTexture = breakTexture;
			breakObject4.GetComponent<Renderer>().material.mainTexture = breakTexture;
		}
		if (type==2){ // train mode
			switch1 = 1;
			breakObject1.GetComponent<Renderer>().material.color = Color.black;
			breakObject2.GetComponent<Renderer>().material.color = Color.yellow;
			breakObject3.GetComponent<Renderer>().material.mainTexture = breakTexture;
			breakObject4.GetComponent<Renderer>().material.mainTexture = breakTexture;
		}
		if (type==3){ // free flight
			switch1 = 2;
			
			Destroy(spot1);
			Destroy(spot2);
			Destroy(spot3);
			Destroy(spot4);
		}
	}
	
	
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(this.transform.position, this.transform.forward);
		RaycastHit hitInfo;
		
		if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            
			name = hitInfo.collider.gameObject.name;
			MeshRenderer otherRenderer = hitInfo.collider.gameObject.GetComponent<MeshRenderer>();

		    if (name != null)
            {
			    
					if (previousname == ""){
						previousname = name;
					}
					if (previousname != name){
						previousname = name;
						gazeTime = 0f;
					}
					if (previousname == name){
						if (name == "mainoption3" || name == "mainoption2" || name == "mainoption1"){
							gazeTime += Time.deltaTime; 
						}
						
						if (switch1 == 1){
							//==========================//
							if (name == "spot1") {
								gazeTime += Time.deltaTime;
							}
							
							if (name == "spot2") {
								gazeTime += Time.deltaTime;
							}
							
							if (name == "spot3") {
								gazeTime += Time.deltaTime;
							}
							
							if (name == "spot4") {
								gazeTime += Time.deltaTime;
							}
							//==========================//
							if (name == "repairObject1") {
								gazeTime += Time.deltaTime;
							}
							
							if (name == "repairObject2" && repairIndex1 == 1) {
								gazeTime += Time.deltaTime;
							}
							
							if (name == "breakObject1" && repairIndex1 == 2) {
								gazeTime += Time.deltaTime;
							}
							//==========================//
							if (name == "cover1(1)") {
								gazeTime += Time.deltaTime;
							}
							
							if (name == "repairObject3" && repairIndex2 == 1){
								gazeTime += Time.deltaTime;
							}
							
							if (name == "repairObject4" && repairIndex2 == 2){
								gazeTime += Time.deltaTime;
							}
							
							if (name == "breakObject4" && repairIndex2 == 3){
								gazeTime += Time.deltaTime;
							}
							//==========================//
							if (name == "breakObject2") {
								gazeTime += Time.deltaTime;
							}
							
							if (name == "repairObject7" && repairIndex3 == 1) {
								gazeTime += Time.deltaTime;
							}
							//==========================//
							if (name == "cover2(1)"){
								gazeTime += Time.deltaTime;
							}
							
							if (name == "repairObject5" && repairIndex4 == 1){
								gazeTime += Time.deltaTime;
							}
							
							if (name == "breakObject3" && repairIndex4 == 2){
								gazeTime += Time.deltaTime;
							}
							
							
							
						}
						
						
					}          				 
						
					 //otherMat = otherRenderer.material; 
                
			     
		    }
            
		    else
			{
                
				name = "";
            
		    }
 
        
	    }
        
        else
        {
            
			name = "";
				
			gazeTime = 0f;
				
        
	    }
 
        if (gazeTime >= waitTime)
        {
            gazeTime = 0f;         
			control.give();
			//==========================//
			if (previousname == "mainoption3"){
				controller(3);
			}
			
			if (previousname == "mainoption2"){
				controller(2);
			}
			
			if (previousname == "mainoption1"){
				controller(1);
			}
			//==========================//
			if (previousname == "spot1"){
				Destroy(spot1);
			}
			
			if (previousname == "spot2"){
				Destroy(spot2);
			}
			
			if (previousname == "spot3"){
				Destroy(spot3);
			}
			
			if (previousname == "spot4"){
				Destroy(spot4);
			}
			//==========================//
			
			if (previousname == "repairObject1"){
				repairIndex1 = 1;
				repairObject1.transform.Rotate(0,90,0);
				print("repairObject1");
			}

			if (previousname == "repairObject2"){
				repairIndex1 = 2;
				repairObject2.transform.Rotate(90,0,0);
				print("repairObject2");
			}
			
			if (previousname == "breakObject1"){
				breakObject1.GetComponent<Renderer>().material.color = Color.grey;
			}
			//==========================//
			if (previousname == "cover1(1)"){
				if (open1==0){
					repairIndex2 = 1;
					cover1.transform.Rotate(90,0,0);
					print("open");
					open1 = 1;
				}
				if (open1 == 1){
					cover1.transform.Rotate(90,0,0);
					open1 = 0;
				}
			}
			
			if (previousname == "repairObject3"){
				repairIndex2 = 2;
				repairObject3.transform.Rotate(Vector3.up*90.0f,Space.Self);
				print("repairObject3");
			}
			
			if (previousname == "repairObject4"){
				repairIndex2 = 3;
				repairObject4.transform.Rotate(Vector3.up*90.0f,Space.Self);
				print("repairObject4");
			}
			
			if (previousname == "breakObject4"){
				breakObject4.GetComponent<Renderer>().material.mainTexture = fixTexture1;
			}
			//==========================//
			if (previousname == "breakObject2"){
				repairIndex3 = 1;
				breakObject2.GetComponent<Renderer>().material.color = Color.black;
			}
			
			if (previousname == "repairObject7"){
				repairObject7.GetComponent<Renderer>().material.color = Color.green;
			}
			//==========================//
			if (previousname == "cover2(1)"){
				if (open2 ==0){
					repairIndex4 = 1;
					cover2.transform.Rotate(Vector3.up*90.0f,Space.Self);
					open2 = 1;
				}
				if (open2 == 1){
					cover2.transform.Rotate(Vector3.down*90.0f,Space.Self);
					open2 = 0;
				}
			}
			
			if (previousname == "repairObject5"){
				repairIndex4 = 2;
				repairObject5.GetComponent<Renderer>().material.color = Color.red;
			}
			
			if (previousname == "breakObject3"){
				breakObject3.GetComponent<Renderer>().material.mainTexture = fixTexture2;
			}
        }
        else
        {
            img.fillAmount = 1 - (gazeTime / waitTime); 
        }
 
	}
	
}
