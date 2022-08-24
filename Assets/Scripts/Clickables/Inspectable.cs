using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour, Clickable
{
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
