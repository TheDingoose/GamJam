using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputScript : MonoBehaviour
{
    PlayerMove playerMove;

    void Start() {
        playerMove = FindObjectOfType<PlayerMove>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject obj = GetObjectUnderMouse();
            if (obj != null && obj.GetComponent<Clickable>() != null) {
                Task t = new Task(playerMove.MoveTo(obj.transform.position));
                t.Finished += delegate { obj.GetComponent<Clickable>().Click();};
            }
        }
    }

    public GameObject GetObjectUnderMouse() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null) {
            return hit.collider.gameObject;
        }

        return null;
    }
}
