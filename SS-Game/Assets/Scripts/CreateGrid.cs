using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {

    public Transform gridCellPrefab;

    public Vector3 gridSize;

	// Use this for initialization
	void Start () {
        GridCreation();
	}

    void GridCreation () {
        for (int x = 0; x < gridSize.x; x++) {
            for (int z = 0; z < gridSize.z; z++) {
                Instantiate(gridCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }

}
