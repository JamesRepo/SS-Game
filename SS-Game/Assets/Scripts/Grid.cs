using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ==== Grid ==== 
 * ---------------
 * This class is for the grid in which the shapes are placed.
 * It contains methods to check if there are shapes in positions
 * in the grid and to delete the rows when neccesary.
 * 
 */

public class Grid : MonoBehaviour {

    /*
     * 
     * ==== Variables ====
     * 
     */

    // Determine the height and width of the grid.
    private const int gridHeight = 15;
    private const int gridWidth = 5;
    // The height at which the game will end.
    private const int gameOverHeight = 8;
    // Three dimensional array, the actual data structure of the grid.
    public static Transform [,,] gameArea;
    // Counts the number of rows cleared in one go, used for scoring
    public static int numberRowsCleared;

    /*
     * 
     * ==== Unity Functions =====
     * 
     */

    // Used to initialise the array rows cleared.
    void Start() {
        gameArea = new Transform[gridWidth, gridHeight, gridWidth];
        numberRowsCleared = 0;
	}

    /*
     * 
     * ==== Methods ====
     * 
     */

    // Method used to round the float point values to a whole number. Not entirely sure its neccesary but makes certain of no errors. 
    public static Vector3 RoundPosition(Vector3 vPos) {
        return new Vector3(Mathf.Round(vPos.x), Mathf.Round(vPos.y), Mathf.Round(vPos.z));
    }
    // Method to check if the block is within the grid. Called in the Shape class.
    public static bool CheckGridLimits(Vector3 pos) {
        bool check = ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.z >= 0 && (int)pos.z < gridWidth && (int)pos.y >= 0 && (int)pos.y < gridHeight);
        return check;
    }

    // Check row to delete whole bottom. 
    public static bool CheckRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                if (gameArea[xPos, yPos, zPos] == null) {
                    return false;
                }
            }
        }
        numberRowsCleared++;
        FindObjectOfType<Scoring>().IncrementLevelCounter();
        return true;
    }

    // Delete a row. 
    public static void DeleteRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                // Deletes from scene.
                Destroy(gameArea[xPos, yPos, zPos].gameObject);
                // Deletes from array.
                gameArea[xPos, yPos, zPos] = null;  
            }
        } 
    }

    // Deletes all of the rows that have been completed. 
    public static void DeleteFullRows() {
        for (int yPos = 0; yPos < gridHeight; ++yPos) {
            if (CheckRow(yPos)) {
                DeleteRow(yPos);
                DropAllRows(yPos + 1);
                --yPos;
            }
        }
        FindObjectOfType<Scoring>().RowClearScore(numberRowsCleared);
        numberRowsCleared = 0;
    }

    // Drops the rows above the one that has been deleted. 
    public static void DropRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                // Check if there is a cell there.
                if (gameArea[xPos, yPos, zPos] != null) {
                    // Move it down.
                    gameArea[xPos, yPos - 1, zPos] = gameArea[xPos, yPos, zPos];
                    // Delete old array spot.
                    gameArea[xPos, yPos, zPos] = null;
                    // Move the cube in the game.
                    gameArea[xPos, yPos - 1, zPos].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    // Cycles through all the rows that might need to be dropped. 
    public static void DropAllRows(int yPos) {
        for (int i = yPos; i < gridHeight; ++i) {
            DropRow(i);
        }
    }

    // Checks if the game over height has been reached.
    public bool CheckGameOver(Shape shape) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                foreach (Transform cell in shape.transform) {
                    Vector3 vPos = RoundPosition(cell.position);
                    if (vPos.y >= gameOverHeight) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    // Updates the grid with a shapes new position when it moves. Called in Shape class. 
    public void UpdateGrid(Shape shape) {
        // Three for loops to cycle all the positions in the 3D array.
        for (int x = 0; x < gridWidth; ++x) {
            for (int y = 0; y < gridHeight; ++y) {
                for (int z = 0; z < gridWidth; ++z) {
                    if (gameArea[x, y, z] != null && gameArea[x, y, z].parent == shape.transform) {
                        gameArea[x, y, z] = null;
                    }
                }
            }
        }
        foreach (Transform cell in shape.transform) {
            Vector3 vPos = RoundPosition(cell.position);
            gameArea[(int)vPos.x, (int)vPos.y, (int)vPos.z] = cell;
        }
    }


    /*
     * Below are methods to allow the check, deletion, and drop of individual rows. Rather than a whole level. 
     * Not needed for this implementation so commented out. 
     * 
     */
    //public static bool CheckRowX(int yPos, int zPos) {
    //    for (int xPos = 0; xPos < gridWidth; ++xPos) {
    //        if (gameArea[xPos, yPos, zPos] == null) {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
    //public static bool CheckRowZ(int yPos, int xPos) {
    //    for (int zPos = 0; zPos < gridWidth; ++zPos) {
    //        if (gameArea[xPos, yPos, zPos] == null) {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
    //public static void DeleteRowX(int yPos, int zPos) {
    //    for (int xPos = 0; xPos < gridWidth; ++xPos) {
    //        Destroy(gameArea[xPos, yPos, zPos].gameObject);
    //        gameArea[xPos, yPos, zPos] = null;
    //    }
    //}
    //public static void DeleteRowZ(int yPos, int xPos) {
    //    for (int zPos = 0; zPos < gridWidth; ++zPos) {
    //        Destroy(gameArea[xPos, yPos, zPos].gameObject);
    //        gameArea[xPos, yPos, zPos] = null;
    //    }
    //} 
    //public static void DeleteFullX(){
    //    for (int yPos = 0; yPos < gridHeight; ++yPos){
    //        for (int zPos = 0; zPos < gridWidth; ++zPos){
    //            if (CheckRowX(yPos, zPos)){
    //                DeleteRowX(yPos, zPos);
    //                DropAllRows(yPos + 1);
    //                --yPos;
    //            }
    //        }
    //    }
    //}
    //public static void DeleteFullZ(){
    //    for (int yPos = 0; yPos < gridHeight; ++yPos){
    //        for (int xPos = 0; xPos < gridWidth; ++xPos){
    //            if (CheckRowZ(yPos, xPos)){
    //                DeleteRowZ(yPos, xPos);
    //                DropAllRows(yPos + 1);
    //                --yPos;
    //            }
    //        }
    //    }
    //}
    //public static void DropRowX(int yPos, int zPos){
    //    for (int xPos = 0; xPos < gridWidth; ++xPos){
    //        if (gameArea[xPos, yPos, zPos] != null){
    //            gameArea[xPos, yPos - 1, zPos] = gameArea[xPos, yPos, zPos];
    //            gameArea[xPos, yPos, zPos] = null;
    //            gameArea[xPos, yPos - 1, zPos].position += new Vector3(0, -1, 0);
    //        }
    //    }
    //}
    //public static void DropRowZ(int yPos, int xPos) {
    //    for (int zPos = 0; zPos < gridWidth; ++zPos){
    //        if (gameArea[xPos, yPos, zPos] != null){
    //            gameArea[xPos, yPos - 1, zPos] = gameArea[xPos, yPos, zPos];
    //            gameArea[xPos, yPos, zPos] = null;
    //            gameArea[xPos, yPos - 1, zPos].position += new Vector3(0, -1, 0);
    //        }
    //    }
    //}
    //public static void DropAllRowsX(int yPos, int zPos){
    //    for (int i = yPos; i < gridHeight; ++i){
    //        DropRowX(i, zPos);
    //    }
    //}
}