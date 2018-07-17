using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    private const int gridHeight = 10;
    private const int gridWidth = 10;
    private Cell [] playArea = new Cell [gridWidth];

    public static Transform [,,] gameArea = new Transform [gridWidth, gridWidth, gridHeight];

	// Use this for initialization
	void Start () {
        for (int a = 0; a < gridWidth; a++) {
            playArea[a] = null;
        }
     
	}
	
	// Update is called once per frame
	void Update () {

	}

    // method used to round the float point values to a whole number
    public static Vector3 RoundPosition(Vector3 vPos) {
        return new Vector3(Mathf.Round(vPos.x), Mathf.Round(vPos.y), Mathf.Round(vPos.z));
    }
    // Method to check if the block is within the grid 
    public static bool CheckShapeInGrid(Vector3 position) {
        bool check = ((int)position.x >= 0 && (int)position.x < gridWidth && (int)position.z >= 0 && (int)position.z < gridWidth && (int)position.y >= 0);
        return check;
    }
    // Method for deleting a row if complete, y parameter is the y co-ordinate being checked and deleted
    public void DeleteRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                Destroy(gameArea[xPos, yPos, zPos].gameObject);
                gameArea[xPos, yPos, zPos] = null;
            }
        }
    }
    // Method for dropping all the blocks above when a line is deleted, parameter y is the row being deleted
    public void DropRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                if (gameArea[xPos, yPos, zPos] != null) {
                    gameArea[xPos, yPos - 1, zPos] = gameArea[xPos, yPos, zPos]; // Puts the row where the deleted row was in the data structure 
                    gameArea[xPos, yPos, zPos] = null; // Makes the position the row is being dropped from null 
                    gameArea[xPos, yPos - 1, zPos].position += new Vector3(0, -1, 0);
                }
            }
        }
    }
    // Method to drop the rows above
    public void DropRowsAbove(int yPos) {
        for (int i = 0; i < gridHeight; ++i) {
            DropRow(i);
        }
    }
    // Method for checking if row is full
    public bool IsRowFull(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                if (gameArea[xPos, yPos, zPos] == null) {
                    return false;
                }
            }
        }
        return true;
    }
    // Method for performing checks and carrying out action
    public void CheckAndDestroy() {
        for (int yPos = 0; yPos < gridHeight; ++yPos) {
            if (IsRowFull(yPos)) {
                DeleteRow(yPos);
                DropRowsAbove(yPos);
                --yPos;
            }
        }
    }
}