using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class AnimationManager : MonoBehaviour
{

    public AnimationSequence[] Sequences;
    private SplineAnimate SplineAnimator;
    public bool StartOnSpawn = false;
    public bool Playing = false;
    private int SequenceToPlay = 0;

    // Start is called before the first frame update
    void Start()
    {

        SplineAnimator = GetComponent<SplineAnimate>();

        //SplineAnimator.alignmentMode = SplineAnimate.AlignmentMode.SplineElement;
        //SplineAnimator.playOnAwake = false;
        //SplineAnimator.method = SplineAnimate.Method.Time;
        //SplineAnimator.easingMode = SplineAnimate.EasingMode.None;
        //SplineAnimator.loopMode = SplineAnimate.LoopMode.Once;


        if (StartOnSpawn)
        {
            StartCoroutine(Animate());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetDuration(int index)
    {
        float d = 0;
        for(int i = 0; i <  Sequences[index].Sequence.Length; i++)
        {
            d += Sequences[index].Sequence[i].Duration;
        }
        return d;
    }

    public float GetDurationFromTo(int index, int start, int end)
    {
        float d = 0;
        for (int i = start; i < Sequences[index].Sequence.Length && i <= end; i++)
        {
            d += Sequences[index].Sequence[i].Duration;
        }
        return d;
    }



    public void Play()
    {
        Sequences[SequenceToPlay].CurrentStep = 0;
        StartCoroutine(Animate());
    }
    public void Play(int index)
    {
        SequenceToPlay = index;
        Sequences[SequenceToPlay].CurrentStep = 0;
        StartCoroutine(Animate());
    }


    IEnumerator Animate()
    {
        Playing = true;

        //play here
        switch (Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].AnimationTypes)
        {
            case AnimationType.SpriteOnly:
                this.GetComponent<Animator>().SetInteger("AnimationState", Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].animationState);
                break;
            case AnimationType.SplineOnly:
               // SplineAnimator.Restart(false);
                SplineAnimator.alignmentMode = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].alignmentMode;
                SplineAnimator.loopMode = SplineAnimate.LoopMode.Once;

                switch (Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].objectUpAxis)
                {
                    case SplineAlignAxisSetting.PosX:
                        if(SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.XAxis ||
                           SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeXAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.YAxis;
                        }

                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.XAxis;
                        break;
                    case SplineAlignAxisSetting.NegX:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.XAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeXAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.YAxis;
                        }

                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeXAxis;
                        break;
                    case SplineAlignAxisSetting.PosY:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.YAxis ||
                        SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeYAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.ZAxis;
                        }

                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.YAxis;
                        break;
                    case SplineAlignAxisSetting.NegY:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.YAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeYAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.ZAxis;
                        }
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeYAxis;
                        break;
                    case SplineAlignAxisSetting.PosZ:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.ZAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeZAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.XAxis;
                        }
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.ZAxis;
                        break;
                    case SplineAlignAxisSetting.NegZ:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.ZAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeZAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.XAxis;
                        }
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeZAxis;
                        break;
                    case SplineAlignAxisSetting.NoChange:
                        break;
                    default:
                        break;
                }
                switch (Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].objectForwardAxis)
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
                    case SplineAlignAxisSetting.NoChange:
                        break;
                    default:
                        break;
                }


                SplineAnimator.duration = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].Duration;
                SplineAnimator.easingMode = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].easingMode;
                //SplineAnimator.maxSpeed = Sequence[CurrentStep].maxSpeed;
                SplineAnimator.elapsedTime = 0;
                SplineAnimator.splineContainer = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].spline;
                SplineAnimator.Restart(true);

                break;
            case AnimationType.SpriteAndSpline:
                this.GetComponent<Animator>().SetInteger("AnimationState", Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].animationState);

                //SplineAnimator.StopAllCoroutines();
                //SplineAnimator.Restart(false);
                SplineAnimator.alignmentMode = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].alignmentMode;
                SplineAnimator.loopMode = SplineAnimate.LoopMode.Once;
                switch (Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].objectUpAxis)
                {
                    case SplineAlignAxisSetting.PosX:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.XAxis ||
                           SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeXAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.YAxis;
                        }

                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.XAxis;
                        break;
                    case SplineAlignAxisSetting.NegX:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.XAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeXAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.YAxis;
                        }

                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeXAxis;
                        break;
                    case SplineAlignAxisSetting.PosY:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.YAxis ||
                        SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeYAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.ZAxis;
                        }

                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.YAxis;
                        break;
                    case SplineAlignAxisSetting.NegY:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.YAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeYAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.ZAxis;
                        }
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeYAxis;
                        break;
                    case SplineAlignAxisSetting.PosZ:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.ZAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeZAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.XAxis;
                        }
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.ZAxis;
                        break;
                    case SplineAlignAxisSetting.NegZ:
                        if (SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.ZAxis ||
                            SplineAnimator.objectForwardAxis == SplineComponent.AlignAxis.NegativeZAxis)
                        {
                            SplineAnimator.objectForwardAxis = SplineComponent.AlignAxis.XAxis;
                        }
                        SplineAnimator.objectUpAxis = SplineComponent.AlignAxis.NegativeZAxis;
                        break;
                    case SplineAlignAxisSetting.NoChange:
                        break;
                    default:
                        break;
                }
                switch (Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].objectForwardAxis)
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
                    case SplineAlignAxisSetting.NoChange:
                        break;
                    default:
                        break;
                }

                SplineAnimator.duration = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].Duration;
                SplineAnimator.easingMode = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].easingMode;
                //SplineAnimator.maxSpeed = Sequence[CurrentStep].maxSpeed;
                SplineAnimator.elapsedTime = 0;

                SplineAnimator.splineContainer = Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].spline;

                SplineAnimator.Restart(true);
                break;
            default:
                break;

        }

        //wait for Duration
        yield return new WaitForSeconds(Sequences[SequenceToPlay].Sequence[Sequences[SequenceToPlay].CurrentStep].Duration);


        //call new coroutine for next step
        Sequences[SequenceToPlay].CurrentStep++;
        if (Sequences[SequenceToPlay].CurrentStep < Sequences[SequenceToPlay].Sequence.Length)
        {
            StartCoroutine(Animate());
        }
        else
        {
            Sequences[SequenceToPlay].CurrentStep = 0;
            Playing = false;
            SequenceToPlay++;
            //StopCoroutine(Animate());
        }
    }

}
