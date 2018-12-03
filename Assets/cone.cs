// Imortant notes ** remove this script when build Android project

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEditor;

using System;



public class ConeCreatorEditor {
	

    
    [MenuItem("GameObject/3D Object/Cone",false,priority = 7)]
    
	public static void CreateCone(){
       
		GameObject cone = new GameObject("Cone");
           
		cone.transform.position = Vector3.zero;
            
		cone.transform.rotation = Quaternion.identity;
           
		cone.transform.localScale = Vector3.one;
            
        Undo.RegisterCreatedObjectUndo(cone, "Undo Creating Cone");
            
		SetMesh(cone);
       
    
	}


    
	//--The function below is refer to https://blog.csdn.net/qq_34469717/article/details/78989320 --//
	private static void SetMesh(GameObject go){
       
		if (go == null){
            
			return;
		}
              
		float myRadius = 0.5f;
        
		int myAngleStep = 20;
        
		Vector3 myTopCenter = new Vector3(0, 1, 0);
        
		Vector3 myBottomCenter = Vector3.zero;
             
		Vector3[] myVertices = new Vector3[360 / myAngleStep * 2 + 2];
        
	    Vector2[] myUV = new Vector2[myVertices.Length];
       

        myVertices[0] = myBottomCenter;
        
		myVertices[myVertices.Length - 1] = myTopCenter;
       
		myUV[0] =  new Vector2(0.5f, 0.5f);
        
		myUV[myVertices.Length - 1] = new Vector2(0.5f,0.5f);
        
     
		for (int i = 1; i <= (myVertices.Length -2) / 2; i++){
           
			float curAngle = i * myAngleStep * Mathf.Deg2Rad;
           
			float curX = myRadius * Mathf.Cos(curAngle);
            
			float curZ = myRadius * Mathf.Sin(curAngle);
            
			myVertices[i] = myVertices[i + (myVertices.Length - 2) / 2] = new Vector3(curX, 0, curZ);
            
			myUV[i] = myUV[i + (myVertices.Length - 2) / 2] = new Vector2(curX + 0.5f, curZ + 0.5f);

        
		}
               
		int[] myTriangle = new int[(myVertices.Length - 2) * 3];       
        
		for (int i = 0; i <= myTriangle.Length - 3; i = i+3){
           
			if (i + 2 < myTriangle.Length / 2){
               
				myTriangle[i] = 0;
                
				myTriangle[i + 1] = i / 3 + 1;
                
				myTriangle[i + 2] = i + 2 == myTriangle.Length / 2 - 1 ? 1 : i / 3 + 2;
            
			}
           
			else{
                
			    myTriangle[i] = myVertices.Length - 1;
             
			    myTriangle[i + 1] = i == myTriangle.Length - 3 ? 19 : i / 3 + 2;
               
		        myTriangle[i + 2] = i / 3 + 1;
            
			}
        
 		}

     

         
		Mesh myMesh = new Mesh();
        
		myMesh.name = "Cone";
        
		myMesh.vertices = myVertices;
        
		myMesh.triangles = myTriangle;
        
		myMesh.uv = myUV;
        
		myMesh.RecalculateBounds();
        
		myMesh.RecalculateNormals();
        
		myMesh.RecalculateTangents();
        
	    MeshFilter mf = go.AddComponent<MeshFilter>();
        
		mf.mesh = myMesh;
        
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        
		Material myMat = new Material(Shader.Find("Standard"));
        
		mr.sharedMaterial = myMat;
    
	}

}
