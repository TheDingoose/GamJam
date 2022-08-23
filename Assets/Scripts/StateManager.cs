using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactable {
    public string name {public get; private set;}
    public GameObject obj {public get; private set;}
    public string[] states;

    int currentStateIndex;

    public string GetCurrentState() {
        return states[currentStateIndex];
    }

    public void SetCurrentState(string newState) {
        int  i = 0;
        foreach (string state in states) {
            if (state == newState) {
                currentStateIndex = i;
            }   
            i++;
        }
    }
}

public class StateManager : MonoBehaviour
{
    public Interactable[] interactables;

    public bool CheckState(string obj, string state) {
        foreach (Interactable interactable in interactables) {
            if (interactable.name == obj) {
                return interactable.GetCurrentState();
            }
        }
    }
}