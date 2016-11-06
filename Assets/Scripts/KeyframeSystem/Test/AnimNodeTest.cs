using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimNodeTest : MonoBehaviour {

    int currFrame;
    List<KeyframeSystem.Keyframe> testKeyframe;
	// Use this for initialization
	void Start () {
        testKeyframe = new List<KeyframeSystem.Keyframe>();
        currFrame = 0;
	}
	
    void addFrame()
    {
        KeyframeSystem.Keyframe frame = new KeyframeSystem.Keyframe(this.gameObject,0);
        testKeyframe.Add(frame);
        frame.Apply(this.gameObject);
        currFrame++;
        Debug.Log(frame);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            addFrame();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currFrame = (currFrame - 1) % testKeyframe.Count;
            testKeyframe[currFrame].Apply(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currFrame = (currFrame + 1) % testKeyframe.Count;
            testKeyframe[currFrame].Apply(this.gameObject);
        }

    }
}
