using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using KeyframeSystem;
using System;

public class Recordable : MonoBehaviour, IRecordable {

    public void ApplyNode(AnimNode frame)
    {
        transform.localPosition = frame.Position;
        transform.localRotation = frame.Rotation;
        transform.localScale = frame.Scale;
        applyTransformRecur(frame, transform);
    }

    private void applyTransformRecur(AnimNode src, Transform dest)
    {
        List<AnimNode> _children = src.Children;
        for( int chI = 0; chI < _children.Count; chI++)
        {
            AnimNode _child = _children[chI];
            dest.GetChild(chI).localPosition = _child.Position;
            dest.GetChild(chI).localRotation = _child.Rotation;
            dest.GetChild(chI).localScale = _child.Scale;

            applyTransformRecur(_child, dest.GetChild(chI));
        }
    }

    public Transform GetTransform()
    {
        return this.transform;
    }
}
