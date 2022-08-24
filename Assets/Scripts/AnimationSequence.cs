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
public class AnimationSequence
{
    //Array of animations, the animations are seperate assets, either A Sprite to cycle through and/or a spline animation

    public SequencePart[] Sequence;

    public int CurrentStep = 0;


    // Start is called before the first frame update
    // Update is called once per frame
   //void Update()
   //{
   //    
   //}

   

}
