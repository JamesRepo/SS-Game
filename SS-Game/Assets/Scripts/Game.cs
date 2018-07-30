
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject nextShape;
    // private const int gridWidth = 10;
    public Shape newShap;


    //private string[] shapeList = new string[] { "ShapeJ", "ShapeL", "ShapeSmall", "ShapeS", "ShapeSquare", "ShapeT", "ShapeZ" };

  //  private Cell[] gridCells = new Cell[gridWidth];

  //  private GameObject[] gameCells = new GameObject[gridWidth];
	// Use this for initialization
	void Start () {
       // ShapeCreator creator = new ShapeCreator();
       // creator.CreateShape();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    ///*
    // * Method for spawning a new cube.
    // * 
    // */
    //public void SpawnNewCube() {
    //    // New variable that stores a random number to select a random shape from the array
    //    int shapeSelection = Random.Range(0, shapeList.Length);
    //    // Instansitates a new cube, selected randomly.
    //    // It is cast as a Game Object
    //    // Instansiate allows us to load a shape that is in the resources folder
    //    nextShape = (GameObject)Instantiate(Resources.Load(shapeList[shapeSelection]), new Vector3(2, 12, 2), Quaternion.identity);
    //}


}
