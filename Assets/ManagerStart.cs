using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioManager>().PlaySound("BGMusic", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
