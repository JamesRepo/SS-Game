using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public void MoveShape() {
        FindObjectOfType<Shape>().MoveRight();
    }
}
