using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public Shape shape;

    public void UserInput(string action)
    {
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
            FindObjectOfType<Shape>().MoveShape("Down");
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


        // Space key is pressed - block moves -1 on the Y axis
        // This statement also includes a timer to make the block fall without user input
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
                Grid.DeleteFullRows();
                // Grid.DeleteFullX();
                // Grid.DeleteFullZ();
                shape.NewShape();
            }
        }


        //// Rotation 
        //else if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    shape.transform.Rotate(0, 90, 0);
        //    if (shape.CheckShape())
        //    {
        //        shape.UpdateGrid();
        //    }
        //    else
        //    {
        //        shape.transform.Rotate(0, -90, 0);
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{
        //    shape.transform.Rotate(90, 0, 0);
        //    if (shape.CheckShape())
        //    {
        //        shape.UpdateGrid();
        //    }
        //    else
        //    {
        //        shape.transform.Rotate(-90, 0, 0);
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.E))
        //{
        //    shape.transform.Rotate(0, 0, 90);
        //    if (shape.CheckShape())
        //    {
        //        shape.UpdateGrid();
        //    }
        //    else
        //    {
        //        shape.transform.Rotate(0, 0, -90);
        //    }
        //}
    }

}
