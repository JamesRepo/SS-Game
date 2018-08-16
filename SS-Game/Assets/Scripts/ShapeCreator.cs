using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  ==== Shape Creator ====
 *  -----------------------
 *  This class is used to instansiate the shapes used in the game. 
 * 
 */

public class ShapeCreator : MonoBehaviour {

    /*
     * 
     *  ==== Variables ====
     *
     */

    // Array of the shapes to be used
    private string[] shapeList;
    // Vector 3 position for the shapes to be created at
    private Vector3 startPosition = new Vector3(2, 9, 2);
    // GameObject object to store instance of a shape
    public GameObject nextShape;
 

    private GameObject previewShape;

    private bool gamePlaying = false;

    private Vector2 previewShapePosition = new Vector2(-6.5f, 15);

    public int levelSelect;

    /*
     * 
     *  ==== Constructor ====
     * 
     */

    public ShapeCreator() {}

    /*
     * 
     *  ==== Unity Functions ====
     * 
     */

    private void Start() {
        ChooseShapes(levelSelect);
        CreateShape();
    }

    /*
     * 
     *  ==== Methods ====
     * 
     */

    // Method to determine which selection of shapes will be used, depending on the level being played.
    public string [] ChooseShapes(int level) {
        if (level == 0) {
            shapeList = new string[] { "ShapeSmall", "ShapeCorner" };
        }

        if (level == 1) {
            shapeList = new string[] { "ShapeJ", "ShapeL", "ShapeSmall", "ShapeS", "ShapeSquare", "ShapeT", "ShapeZ" };
        }

        return shapeList;
    }

    // Method to create a shape
    public void CreateShape() {

        // New variable that stores a random number to select a random shape from the array
        int shapeSelection = Random.Range(0, shapeList.Length);

        // Instansitates a new shape, selected randomly.
        // It is cast as a Game Object
        // Instansiate allows us to load a shape that is in the resources folder
        nextShape = (GameObject)Instantiate(Resources.Load(shapeList[shapeSelection]), startPosition, Quaternion.identity);

    }

}
