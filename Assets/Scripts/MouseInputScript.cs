using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputScript : MonoBehaviour
{

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject obj = GetObjectUnderMouse();
            if (obj != null) obj.GetComponent<Clickable>().Click();
        }
    }

    GameObject GetObjectUnderMouse() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null) {
            return hit.collider.gameObject;
        }

        return null;
    }
}
