using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ==== Arrow Controls ====
 * ------------------------
 * This class is attached to the arrows around the base of the play area.
 * There is a public variable for the direction, so the individual arrows
 * specify what direction they move the shape in the Unity editor. 
 * 
 */

public class ArrowControls : MonoBehaviour {

    /*
     *
     * ==== Variables ====
     *  
     * 
     */

    public string direction;

    /*
     * 
     * ==== Unity Functions ====
     * 
     */

    /*
     * This method is Unity specific. It is called when the Game Object it 
     * is attached to is clicked on by a mouse, or touched via a touch screen
     * in this case.
     * Here it gets the Shape that is the active Game Object and moves it the 
     * relevant direction, determined by the public variable in the Unity 
     * editor.
     * The directions are actually only relative to the stating camera position.
     */
    public void OnMouseDown() 
    {
        // Gets the shape
        Shape shape = FindObjectOfType<ShapeCreator>().GetNextShape().GetComponent<Shape>();
        // Makes sure the game isn't paused before allowing movement.
        if (!UISystem.isGamePaused) 
        {
            switch (direction) 
            {
                // LEFT
                case "Left":
                    shape.MoveLeft();
                    break;
                // RIGHT
                case "Right":
                    shape.MoveRight();
                    break;
                // DOWN
                case "Down":
                    shape.MoveDown();
                    break;
                // UP
                case "Up":
                    shape.MoveUp();
                    break;
            }
        }
    }
}