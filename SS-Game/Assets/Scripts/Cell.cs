using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    // Variables
    private string cellID;
    private Vector3 cellPosition;
    private float positionX;
    private float positionY;
    private float positionZ;
    // Constructor
    public Cell() {

      //  cellPosition = transform.position;
       
    }


    // Set methods
    public void setPositionX(int x)
    {
        positionX = x;
    }
    public void setPositionY(int y)
    {
        positionY = y;
    }
    public void setPositionZ(int z)
    {
        positionZ = z;
    }
    // Get methods
    public int getPositionX() 
    {
        return (int)positionX;
    }
    public int getPositionY()
    {
        return (int)positionY;
    }
    public int getPositionZ()
    {
        return (int)positionZ;
    }
    public Vector3 GetCellVector() 
    {
        return cellPosition;
    }




    // Use this for initialization
    void Start()
    {
        cellPosition = transform.position;
        positionX = cellPosition.x;
        positionY = cellPosition.y;
        positionZ = cellPosition.z;

    }

    // Update is called once per frame
    void Update()
    {
        positionX = cellPosition.x;
        positionY = cellPosition.y;
        positionZ = cellPosition.z;
       // Debug.Log(positionX);
    }

}