using UnityEngine;
using System.Collections;
using KeyframeSystem;
public class AnimationManager : MonoBehaviour {


    VRAnimation _anim;

    public bool HotkeyDebug;
    float debugTime;

	// Use this for initialization
	void Start () {
        _anim = new VRAnimation(this.gameObject);
        _anim.Loop = true;
        debugTime = 0;
    }
	
	public void AddKeyframe(float time)
    {
        _anim.AddFrame(time);
    }

    public void DeleteKeyFrame(float time)
    {
        _anim.Anim.Remove(time);
    }

    public void Play()
    {
        _anim.Play();
    }

    public void Pause()
    {
        _anim.Pause();
    }


    public void Toggle()
    {
        if (_anim.IsPlaying)
            Pause();
        else
            Play();
    }

    public void Reset()
    {
        _anim.Reset();
    }

    void Update()
    {

        _anim.Update();
        if(HotkeyDebug)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddKeyframe(debugTime);
                debugTime += 1;
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                Toggle();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reset();
            }
            
        }
    }
}
