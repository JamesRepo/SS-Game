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

    // Arrays of the shapes to be used. Preview shapes are just shapes but without scripts attached. 
    private readonly string[] shapeList = { "ShapeJ", "ShapeL", "ShapeSmall", "ShapeS", "ShapeSquare", "ShapeT", "ShapeZ" };
    private readonly string[] previewShapeList = { "ShapeJ-Preview", "ShapeL-Preview", "ShapeSmall-Preview", "ShapeS-Preview", "ShapeSquare-Preview", "ShapeT-Preview", "ShapeZ-Preview" };

    // Position of the shapes start position and its preview. Both read only so cannot be changed. 
    private readonly Vector3 startPosition = new Vector3(2, 10, 2);
    private readonly Vector3 previewShapePosition = new Vector3(8, 0, 9);

    // Game Objects for the active and next shape. Next shape is public as it needs to be accessed by other classes.
    private GameObject nextShape;
    private GameObject previewShape;

    // Integers to store the random selection of the shapes.
    private int shapeSelection;
    private int nextShapeSelection;

    // Used to make sure the frst shape is always random.
    private int counter;

    /*
     * 
     *  ==== Unity Functions ====
     * 
     */

    private void Start() 
    {
        shapeSelection = 0;
        nextShapeSelection = 0;
        counter = 0;
        CreateShape();
    }

    /*
     * 
     *  ==== Methods ====
     * 
     */

    /*
     * Creates the shape and preview shape at their relative starting positions.
     */
    public void CreateShape() 
    {
        // Counter is used to make sure the first shape is always random. 
        shapeSelection = counter == 0 ? Random.Range(0, shapeList.Length) : nextShapeSelection;
        // Instansitates a new shape, selected randomly.
        // Instansiate allows us to load a shape that is in the resources folder.
        // Quarternion identiy means that there is no rotation.
        nextShape = (GameObject)Instantiate(Resources.Load(shapeList[shapeSelection]), startPosition, Quaternion.identity);
        nextShapeSelection = Random.Range(0, shapeList.Length);
        if (previewShape != null) 
        {
            Destroy(previewShape);
        }
        previewShape = (GameObject)Instantiate(Resources.Load(previewShapeList[nextShapeSelection]), previewShapePosition, Quaternion.identity);
        counter++;
    }

    /*
     * Get method so the UI controls and Arrow controls can access the shape. 
     */
    public GameObject GetNextShape() {
        return nextShape;
    }
}
