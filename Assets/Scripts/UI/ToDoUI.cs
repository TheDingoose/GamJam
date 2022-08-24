using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoUI : MonoBehaviour
{
    public GameObject hoverOver;

    void Update() {
        Debug.Log(FindObjectOfType<MouseInputScript>().GetObjectUnderMouse());
        if (FindObjectOfType<MouseInputScript>().GetObjectUnderMouse() == this.hoverOver) {
            Debug.Log("poggers");
        }       
    }
}
