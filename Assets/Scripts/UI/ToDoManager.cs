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

public class ToDoManager : MonoBehaviour
{
    public ToDoItem[] toDoItems;
    public List<GameObject> emptySlots = new List<GameObject>();

    public void CompleteItem(string ID) {
        foreach (ToDoItem item in toDoItems) {
            if (item.ID == ID) {
                item.done = true;
                if (!item.hidden) {
                    item.textMeshObj.GetComponent<TextMeshProUGUI>().text = "<s>" + item.itemDescription + "</s>";
                } else {
                    emptySlots[0].GetComponent<TextMeshProUGUI>().text = "<s>" + item.itemDescription + "</s>";
                    emptySlots.Remove(emptySlots[0]);
                }
            }
        }
    }
}
