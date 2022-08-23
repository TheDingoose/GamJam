using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClickableObject : MonoBehaviour, Clickable
{
    public void Click() {
        StateManager stateManager = FindObjectOfType<StateManager>(); 
        Debug.Log(stateManager.GetInteractableByObj(this.gameObject).GetCurrentState());
        stateManager.GetInteractableByObj(this.gameObject).SetCurrentState("CLICKED");
    }
}
