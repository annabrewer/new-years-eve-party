using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MeshColorNull : EditorWindow
{
     private string error = "";
     
     [MenuItem("Window/Mesh Color Null")]
     public static void ShowWindow() {
         EditorWindow.GetWindow(typeof(MeshColorNull));
     }
 
     void OnGUI() {
         GUILayout.Label ("Nulls out the color array in the mesh");
         GUILayout.Space(20);
 
         if (GUILayout.Button ("Null Color")) {
             error = "";
             NullTheColor();
         }
         
         GUILayout.Space(20);
         GUILayout.Label(error);
     }
     
     void NullTheColor() {
         Transform curr = Selection.activeTransform;
 
         if (curr == null) {
             error = "No appropriate object selected.";
             Debug.Log (error);    
             return;
         }
 
         MeshFilter mf = curr.GetComponent<MeshFilter>();
 
         if (mf == null || mf.sharedMesh == null) {
             error = "No mesh on the object.";
             Debug.Log (error);
             return;
         }
         
         mf.sharedMesh.colors = null;
     }
 }