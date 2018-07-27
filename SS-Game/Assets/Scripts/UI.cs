using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     //   shape = shape.GetComponent<Shape>();
	}

    public static void GetShape(Shape s) {
        
    }


    public void UserInput(string action)
    {
        

        Shape shape = FindObjectOfType<Game>().nextShape.GetComponent<Shape>();



        // Right arrow pressed - block moves +1 on the X axis
        if (action == "Right")
        {
            shape.transform.position += new Vector3(1, 0, 0);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.position += new Vector3(-1, 0, 0);
            }
        }


        // Left arrow is pressed - block moves -1 on the X axis
        else if (action == "Left")
        {
            shape.transform.position += new Vector3(-1, 0, 0);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.position += new Vector3(1, 0, 0);
            }
        }


        // Down arrow is pressed - block moves +1 on the Z axis
        else if (action == "Down")
        {
            shape.transform.position += new Vector3(0, 0, -1);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.position += new Vector3(0, 0, 1);
            }
        }


        // Up arrow is pressed - block moves -1 on the Z axis
        else if (action == "Up")
        {
            shape.transform.position += new Vector3(0, 0, 1);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.position += new Vector3(0, 0, -1);
            }
        }

        else if (action == "Drop")
        {
            shape.transform.position += new Vector3(0, -1, 0);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.position += new Vector3(0, 1, 0);
            }
        }


        // Rotation 
        else if (action == "RotX")
        {
            shape.transform.Rotate(0, 90, 0);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.Rotate(0, -90, 0);
            }
        }
        else if (action == "RotY")
        {
            shape.transform.Rotate(90, 0, 0);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.Rotate(-90, 0, 0);
            }
        }
        else if (action == "RotZ")
        {
            shape.transform.Rotate(0, 0, 90);
            if (shape.CheckShape())
            {
                shape.UpdateGrid();
            }
            else
            {
                shape.transform.Rotate(0, 0, -90);
            }
        }



    }
}
