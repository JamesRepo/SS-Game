using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour {

    private const int gridHeight = 15;
    private const int gridWidth = 5;

    public static Transform [,,] gameArea = new Transform [gridWidth, gridHeight, gridWidth];


	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {

	}

    // method used to round the float point values to a whole number
    public static Vector3 RoundPosition(Vector3 vPos) {
        return new Vector3(Mathf.Round(vPos.x), Mathf.Round(vPos.y), Mathf.Round(vPos.z));
    }
    // Method to check if the block is within the grid 
    public static bool CheckGridLimits(Vector3 pos) {
        bool check = ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.z >= 0 && (int)pos.z < gridWidth && (int)pos.y >= 0 && (int)pos.y < gridHeight);
        return check;
    }



    // Check row to delete whole bottom 
    public static bool CheckRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                if (gameArea[xPos, yPos, zPos] == null) {
                    return false;
                }
            }
        }
        return true;
    }

    // Check row to delete one row
    public static bool CheckRowX(int yPos, int zPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
          //  Debug.Log("Posx:" + xPos + ", Posy:" + yPos + ", Posz:" + zPos);
            if (gameArea[xPos, yPos, zPos] == null) {
                return false;
            } 
        }
        return true;
    }

    // Check row to delete one row
    public static bool CheckRowZ(int yPos, int xPos) {
        for (int zPos = 0; zPos < gridWidth; ++zPos) {
            if (gameArea[xPos, yPos, zPos] == null) {
                return false;
            }
        }
        return true;
    }


    // Delete a row 
    public static void DeleteRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                // Deletes from scene
                Destroy(gameArea[xPos, yPos, zPos].gameObject);
                // Deletes from array
                gameArea[xPos, yPos, zPos] = null;  
            }
        } 
    }

    public static void DeleteRowX(int yPos, int zPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            Destroy(gameArea[xPos, yPos, zPos].gameObject);
            gameArea[xPos, yPos, zPos] = null;
        }
    }

    public static void DeleteRowZ(int yPos, int xPos) {
        for (int zPos = 0; zPos < gridWidth; ++zPos) {
            Destroy(gameArea[xPos, yPos, zPos].gameObject);
            gameArea[xPos, yPos, zPos] = null;
        }
    }



    public static void DeleteFullRows() {
        for (int yPos = 0; yPos < gridHeight; ++yPos) {
            if (CheckRow(yPos)) {
                DeleteRow(yPos);
                DropAllRows(yPos + 1);
                --yPos;
            }
        }
    }


    public static void DeleteFullX() {
        for (int yPos = 0; yPos < gridHeight; ++yPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                if (CheckRowX(yPos, zPos)) {
                    DeleteRowX(yPos, zPos);
                    DropAllRows(yPos + 1);
                    if (yPos > 0) {
                        --yPos;
                    }
                }
            }
        }
    }

    public static void DeleteFullZ() {
        for (int yPos = 0; yPos < gridHeight; ++yPos) {
            for (int xPos = 0; xPos < gridWidth; ++xPos) {
                if (CheckRowZ(yPos, xPos)) {
                    DeleteRowZ(yPos, xPos);
                    DropAllRows(yPos + 1);
                    --yPos;
                }
            }
        }
    }

    public static void DropRow(int yPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
            for (int zPos = 0; zPos < gridWidth; ++zPos) {
                // check if there is a cell there
                if (gameArea[xPos, yPos, zPos] != null) {
                    // move it down
                    gameArea[xPos, yPos - 1, zPos] = gameArea[xPos, yPos, zPos];
                    // delete old array spot
                    gameArea[xPos, yPos, zPos] = null;
                    // move the cube in the game
                    gameArea[xPos, yPos - 1, zPos].position += new Vector3(0, -1, 0);
                }
            }
        }
    }



    public static void DropRowX(int yPos, int zPos) {
        for (int xPos = 0; xPos < gridWidth; ++xPos) {
                if (gameArea[xPos, yPos, zPos] != null) {
                    gameArea[xPos, yPos - 1, zPos] = gameArea[xPos, yPos, zPos];
                    gameArea[xPos, yPos, zPos] = null;
                    gameArea[xPos, yPos - 1, zPos].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void DropRowZ(int yPos, int xPos) {
        for (int zPos = 0; zPos < gridWidth; ++zPos) {
            if (gameArea[xPos, yPos, zPos] != null) {
                gameArea[xPos, yPos - 1, zPos] = gameArea[xPos, yPos, zPos];
                gameArea[xPos, yPos, zPos] = null;
                gameArea[xPos, yPos - 1, zPos].position += new Vector3(0, -1, 0);
            }
        }
    }



    public static void DropAllRows(int yPos) {
        for (int i = yPos; i < gridHeight; ++i) {
            DropRow(i);
        }
    }

    public static void DropAllRowsX(int yPos, int zPos) {
        for (int i = yPos; i < gridHeight; ++i) {
            DropRowX(i, zPos);
        }
    }

}