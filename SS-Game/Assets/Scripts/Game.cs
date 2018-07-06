using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject Prefab;

    private int height = 10;
    private int width = 10;

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

    public void SpawnNewCube() {
        GameObject nextCube = (GameObject)Instantiate(Prefab, new Vector3(5, 10, 5), Quaternion.identity);
    }
}
