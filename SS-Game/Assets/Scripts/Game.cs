
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    
    private GameObject nextCube;

    private int height = 10;
    private int width = 10;
    private int gridSize = 10;

    public static Transform[,,] grid = new Transform[10, 10, 10];

    private string[] shapeList = new string[] { "ShapeJ", "ShapeL", "ShapeLong", "ShapeS", "ShapeSquare", "ShapeT", "ShapeZ" };



	// Use this for initialization
	void Start () {
        SpawnNewCube();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    //public bool CheckInGrid(Vector3 position) {
    //    return ((int)position.x >= 0 && (int)position.x < width && (int)position.y >= 0);
    //}

    //public Vector3 Round (Vector3 position) {
    //    return new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.x));
    //}


    /*
     * Method for spawning a new cube.
     * 
     */
    public void SpawnNewCube() {
        // New variable that stores a random number to select a random shape from the array
        int shapeSelection = Random.Range(0, shapeList.Length - 1);  
        // Instansitates a new cube, selected randomly.
        // It is cast as a Game Object
        // Instansiate allows us to load a shape that is in the resources folder
        GameObject nextCube = (GameObject)Instantiate(Resources.Load(shapeList[shapeSelection]), new Vector3(5, 10, 5), Quaternion.identity);
    }
}
