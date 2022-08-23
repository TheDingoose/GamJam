using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactable {
    public string name;
    public GameObject obj;
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

    public string CheckState(string obj) {
        foreach (Interactable interactable in interactables) {
            if (interactable.name == obj) {
                return interactable.GetCurrentState();
            }
        }
        return null;
    }

    public Interactable GetInteractable(string name) {
        foreach(Interactable interactable in interactables) {
            if (interactable.name == name) {
                return interactable;
            }
        }
        return null;
    }

    public Interactable GetInteractableByObj(GameObject obj) {
        foreach (Interactable interactable in interactables) {
            if (interactable.obj == obj) {
                return interactable;
            }
        }
        return null;
    }
}