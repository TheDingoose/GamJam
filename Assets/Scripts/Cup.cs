using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Cup : MonoBehaviour, Clickable
{
    public GameObject TestAnimation;

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
        this.GetComponent<SplineAnimate>().Play();
        yield return new WaitForSeconds(this.GetComponent<SplineAnimate>().duration);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().PlaySound("CupFall");
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().PlaySound("DoorOpen");
        TestAnimation.SetActive(true);
        yield return new WaitForSeconds(
            TestAnimation.GetComponent<AnimationSequence>().Sequence[0].Duration +
            TestAnimation.GetComponent<AnimationSequence>().Sequence[1].Duration);

        this.transform.position = new Vector3(-0.536f, -0.396f, 0);
        this.transform.rotation = Quaternion.identity;

        yield return new WaitForSeconds(
    TestAnimation.GetComponent<AnimationSequence>().Sequence[2].Duration +
    TestAnimation.GetComponent<AnimationSequence>().Sequence[3].Duration);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().PlaySound("DoorClose");
        TestAnimation.SetActive(false);
    }
}
