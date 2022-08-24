using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public enum AnimationType { 
    None,
    SpriteOnly,
    SplineOnly,
    SpriteAndSpline
}



[System.Serializable]
public struct SequencePart
{
    public AnimationType AnimationTypes;
    //public SpriteAnimationStart;
    //SpriteParts to animate between
    //...

    //?   ---------AnimationState???------=--===
    public int animationState;
    //SplineAnimate To Follow
    //public  SplineAnimation;

    public SplineAnimate.AlignmentMode alignmentMode;
   // public SplineComponent.AlignAxis objectForwardAxis;
   // public SplineComponent.AlignAxis objectUpAxis;
    public float Duration;
    public SplineAnimate.EasingMode easingMode;
   // public SplineAnimate.LoopMode loopMode;
    //public float maxSpeed;
    public SplineContainer spline;
}



[System.Serializable]
public class AnimationSequence : MonoBehaviour
{
    //Array of animations, the animations are seperate assets, either A Sprite to cycle through and/or a spline animation

    public SequencePart[] Sequence;
    public bool StartOnSpawn = true;
    public bool Playing = false;
    private int CurrentStep = 0;
    private SplineAnimate SplineAnimator;



    // Start is called before the first frame update
    void Start()
    {
        CurrentStep = 0;
        SplineAnimator = GetComponent<SplineAnimate>();
        //SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.ZAxis;
        //SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.NegativeXAxis;
        //SplineAnimator.alignmentMode = SplineAnimate.AlignmentMode.SplineElement;
        SplineAnimator.playOnAwake = false;
        SplineAnimator.method = SplineAnimate.Method.Time;
        SplineAnimator.easingMode = SplineAnimate.EasingMode.None;
        //SplineAnimator.loopMode = SplineAnimate.LoopMode.Once;


        if (StartOnSpawn)
        {
            StartCoroutine(Animate());
        }
    }

    public void Play()
    {
        StartCoroutine(Animate());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Animate()
    {
        Playing = true;

        //play here
        switch (Sequence[CurrentStep].AnimationTypes)
        {
            case AnimationType.SpriteOnly:
                this.GetComponent<Animator>().SetInteger("AnimationState", Sequence[CurrentStep].animationState);
                break;
            case AnimationType.SplineOnly:

                SplineAnimator.alignmentMode = Sequence[CurrentStep].alignmentMode;
                SplineAnimator.duration = Sequence[CurrentStep].Duration;
                SplineAnimator.easingMode = Sequence[CurrentStep].easingMode;
                //SplineAnimator.maxSpeed = Sequence[CurrentStep].maxSpeed;
                SplineAnimator.elapsedTime = 0;
                SplineAnimator.splineContainer = Sequence[CurrentStep].spline;
                SplineAnimator.Restart(true);

                break;
            case AnimationType.SpriteAndSpline:
               // this.GetComponent<Animator>().SetTrigger(Sequence[CurrentStep].SpriteAnimationTrigger);
                this.GetComponent<Animator>().SetInteger("AnimationState", Sequence[CurrentStep].animationState);

                
                SplineAnimator.alignmentMode = Sequence[CurrentStep].alignmentMode;
                SplineAnimator.duration = Sequence[CurrentStep].Duration;
                SplineAnimator.easingMode = Sequence[CurrentStep].easingMode;
                //SplineAnimator.maxSpeed = Sequence[CurrentStep].maxSpeed;
                SplineAnimator.elapsedTime = 0;
                SplineAnimator.splineContainer = Sequence[CurrentStep].spline;

                SplineAnimator.Restart(true);
                break;
            default:
                break;

        }

        //wait for Duration
        yield return new WaitForSeconds(Sequence[CurrentStep].Duration);


        //call new coroutine for next step
        CurrentStep++;
        if (CurrentStep < Sequence.Length)
        {
            
            StartCoroutine(Animate());
        }
        else
        {
            Playing = false;
            StopCoroutine(Animate());
        }
    }

}
