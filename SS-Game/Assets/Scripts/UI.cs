using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public static void GetShape(Shape s) {
        
    }


    public void UserInput(string action)
    {
        

        Shape shape = FindObjectOfType<ShapeCreator>().nextShape.GetComponent<Shape>();



        // Right arrow pressed - block moves +1 on the X axis
        if (action == "Right") {
            shape.MoveRight();
        }


        // Left arrow is pressed - block moves -1 on the X axis
        else if (action == "Left") {
            shape.MoveLeft();
        }


        // Down arrow is pressed - block moves +1 on the Z axis
        else if (action == "Down") {
            shape.MoveDown();
        }


        // Up arrow is pressed - block moves -1 on the Z axis
        else if (action == "Up") {
            shape.MoveUp();
        }

        // Drop
        else if (action == "Drop"){
            shape.Drop();
        }

        // Rotation 
        else if (action == "RotX") {
            shape.RotateX();
        }
        else if (action == "RotY") {
            shape.RotateY();
        }
        else if (action == "RotZ") {
            shape.RotateZ();
        }
    }
}
