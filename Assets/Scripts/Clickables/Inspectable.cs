using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour, Clickable
{
    public bool walkToObj {get; set;}  = true;
    [SerializeField]Sprite inspectSprite;

    InspectManager inspectManager;

    void Start() {
        inspectManager = FindObjectOfType<InspectManager>();
    }

    public void Click() {
        inspectManager.SetInspectionImage(inspectSprite);
        inspectManager.ToggleInspection(true, true);
    }
}
