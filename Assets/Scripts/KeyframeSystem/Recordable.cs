using UnityEngine;
using System.Collections;
using KeyframeSystem;
using System;

public class Recordable : MonoBehaviour, IRecordable {
    public Transform GetTransform()
    {
        return this.transform;
    }
}
