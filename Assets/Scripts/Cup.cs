using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

[System.Serializable]
public class Cup : MonoBehaviour, Clickable
{
    public bool walkToObj {get; set;} = true;
    public GameObject TestAnimation;
    public bool walkToObj { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        GetComponent<AnimationManager>().Play(0);
        yield return new WaitForSeconds(this.GetComponent<SplineAnimate>().duration);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().PlaySound("CupFall");
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().PlaySound("DoorOpen");
        
        TestAnimation.SetActive(true);
        TestAnimation.GetComponent<AnimationManager>().Play(0);
        yield return new WaitForSeconds(TestAnimation.GetComponent<AnimationManager>().GetDurationFromTo(0, 0, 1));

        this.transform.position = new Vector3(-0.536f, -0.396f, 0);
        this.transform.rotation = Quaternion.identity;

        yield return new WaitForSeconds(TestAnimation.GetComponent<AnimationManager>().GetDurationFromTo(0, 2, 3));
        GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().PlaySound("DoorClose");
        TestAnimation.SetActive(false);
        StopCoroutine(Fall());

    }
}
