using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
	
	public Image img;  
	public float gazeTime = 0f;    
	public float waitTime = 3f;     
	public bool hasChangeMat = false;
	public string name;
	public GameObject mainoption1;
	public GameObject mainoption2;
	public GameObject mainoption3;
  	//private Material otherMat;
	public Control control;

	// Use this for initialization
	void Start () {
	}
	
	
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(this.transform.position, this.transform.forward);
		RaycastHit hitInfo;
		
		if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            
			name = hitInfo.collider.gameObject.name;
			MeshRenderer otherRenderer = hitInfo.collider.gameObject.GetComponent<MeshRenderer>();

		    if (otherRenderer != null)
            {
               
			    if (!hasChangeMat && name == "mainoption3")  
                {
                   
					gazeTime += Time.deltaTime;  
						
					 //otherMat = otherRenderer.material; 
                
			    }
				else
				{
					gazeTime = 0f;
					
				}	 
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
				
			hasChangeMat = false;  
        
	    }
 
        if (gazeTime >= waitTime)
        {
            gazeTime = 0f;
            hasChangeMat = true;          
			Destroy(mainoption1);
			Destroy(mainoption2);
			Destroy(mainoption3);
			control.give();
        }
        else
        {
            img.fillAmount = 1 - (gazeTime / waitTime); 
        }
 
	}
	
}
