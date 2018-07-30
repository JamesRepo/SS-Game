using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      // UpdatePosition();
	}

    public string direction;


    public void OnMouseDown() {
        
        Shape shape = FindObjectOfType<ShapeCreator>().nextShape.GetComponent<Shape>();


        if(direction == "Left") {
            shape.MoveLeft();
        }
        else if (direction == "Right") {
            shape.MoveRight();
        }
        else if (direction == "Down") {
            shape.MoveDown();
        }
        else if (direction == "Up") {
            shape.MoveUp();
        }

    }

    public void UpdatePosition() {

        Shape shape = FindObjectOfType<ShapeCreator>().nextShape.GetComponent<Shape>();

        Vector3 shapePos = shape.GetVecPosition();
        float vXPos = shapePos.x;
        float vYPos = shapePos.y;
        float vZPos = shapePos.z;

        transform.position = new Vector3(transform.position.x, vYPos, transform.position.z);

    }
}
