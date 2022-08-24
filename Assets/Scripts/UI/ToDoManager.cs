using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ToDoItem {
    public string ID;
    
    public bool done;
    public bool hidden;

    [TextArea] public string itemDescription;
    public GameObject textMeshObj;
}

public class ToDoManager : MonoBehaviour, Clickable
{
    public bool walkToObj {get; set;} = false;
    public bool extended = true;
    public float extendedY;
    public float hiddenY;

    public ToDoItem[] toDoItems;
    public List<GameObject> emptySlots = new List<GameObject>();

    public void Click() {
        StopAllCoroutines();
        if (extended) {
            StartCoroutine(MoveTo(hiddenY, 0.1f));
            extended = false;
        } else {
            StartCoroutine(MoveTo(extendedY, 0.1f));
            extended = true;
        }
    }

    IEnumerator MoveTo(float y, float speed) {
        float timeElapsed = 0;
        Vector2 startPos = transform.localPosition;
        while (timeElapsed < speed) {
            timeElapsed += Time.deltaTime;

            transform.localPosition = Vector2.Lerp(startPos, new Vector2(startPos.x, y), timeElapsed/speed);

            yield return null;
        }
    }

    public void CompleteItem(string ID) {
        foreach (ToDoItem item in toDoItems) {
            if (item.ID == ID) {
                item.done = true;
                if (!item.hidden) {
                    item.textMeshObj.GetComponent<TextMeshPro>().text = "<s>" + item.itemDescription + "</s>";
                } else {
                    emptySlots[0].GetComponent<TextMeshPro>().text = "<s>" + item.itemDescription + "</s>";
                    emptySlots.Remove(emptySlots[0]);
                }
            }
        }
    }
}
