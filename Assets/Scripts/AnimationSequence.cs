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

public enum SplineAlignAxisSetting
{
    NoChange,
    PosX,
    NegX,
    PosY,
    NegY,
    PosZ,
    NegZ
}




[System.Serializable]
public struct SequencePart
{
    public AnimationType AnimationTypes;

    public int animationState;

    //Spline To Follow
    public SplineAnimate.AlignmentMode alignmentMode;
    public SplineAlignAxisSetting objectForwardAxis;
    public SplineAlignAxisSetting objectUpAxis;
    public float Duration;
    public SplineAnimate.EasingMode easingMode;
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


                switch (Sequence[CurrentStep].objectUpAxis)
                {
                    case SplineAlignAxisSetting.PosX:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.XAxis;
                        break;
                    case SplineAlignAxisSetting.NegX:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeXAxis;
                        break;
                    case SplineAlignAxisSetting.PosY:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.YAxis;
                        break;
                    case SplineAlignAxisSetting.NegY:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeYAxis;
                        break;
                    case SplineAlignAxisSetting.PosZ:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.ZAxis;
                        break;
                    case SplineAlignAxisSetting.NegZ:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeZAxis;
                        break;
                    default:
                        break;
                }
                switch (Sequence[CurrentStep].objectUpAxis)
                {
                    case SplineAlignAxisSetting.PosX:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.XAxis;
                        break;
                    case SplineAlignAxisSetting.NegX:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.NegativeXAxis;
                        break;
                    case SplineAlignAxisSetting.PosY:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.YAxis;
                        break;
                    case SplineAlignAxisSetting.NegY:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.NegativeYAxis;
                        break;
                    case SplineAlignAxisSetting.PosZ:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.ZAxis;
                        break;
                    case SplineAlignAxisSetting.NegZ:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.NegativeZAxis;
                        break;
                    default:
                        break;
                }


                SplineAnimator.duration = Sequence[CurrentStep].Duration;
                SplineAnimator.easingMode = Sequence[CurrentStep].easingMode;
                //SplineAnimator.maxSpeed = Sequence[CurrentStep].maxSpeed;
                SplineAnimator.elapsedTime = 0;
                SplineAnimator.splineContainer = Sequence[CurrentStep].spline;
                SplineAnimator.Restart(true);

                break;
            case AnimationType.SpriteAndSpline:
                this.GetComponent<Animator>().SetInteger("AnimationState", Sequence[CurrentStep].animationState);

                
                SplineAnimator.alignmentMode = Sequence[CurrentStep].alignmentMode;

                switch (Sequence[CurrentStep].objectUpAxis)
                {
                    case SplineAlignAxisSetting.PosX:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.XAxis;
                        break;
                    case SplineAlignAxisSetting.NegX:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeXAxis;
                        break;
                    case SplineAlignAxisSetting.PosY:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.YAxis;
                        break;
                    case SplineAlignAxisSetting.NegY:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeYAxis;
                        break;
                    case SplineAlignAxisSetting.PosZ:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.ZAxis;
                        break;
                    case SplineAlignAxisSetting.NegZ:
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeZAxis;
                        break;
                    default:
                        break;
                }
                switch (Sequence[CurrentStep].objectUpAxis)
                {
                    case SplineAlignAxisSetting.PosX:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.XAxis;
                        break;
                    case SplineAlignAxisSetting.NegX:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.NegativeXAxis;
                        break;
                    case SplineAlignAxisSetting.PosY:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.YAxis;
                        break;
                    case SplineAlignAxisSetting.NegY:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.NegativeYAxis;
                        break;
                    case SplineAlignAxisSetting.PosZ:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.ZAxis;
                        break;
                    case SplineAlignAxisSetting.NegZ:
                        SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.NegativeZAxis;
                        break;
                    default:
                        break;
                }

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
