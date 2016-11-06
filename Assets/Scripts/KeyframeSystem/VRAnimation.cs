using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace KeyframeSystem
{
    public class VRAnimation
    {

        public SortedList<float,Keyframe> Anim;
        public bool Loop { get;  set; }
        public float SeekPoint { get; private set; }
        public int CurrFrameIndex { get; private set; }
        public bool IsPlaying { get; private set; }
        public GameObject GO;
        public float Length { get
            {
                
                return Anim.Keys[Anim.Count - 1];
            }
        }

        public VRAnimation(GameObject go)
        {
            Anim = new SortedList<float,Keyframe>();
            Loop = true;
            SeekPoint = 0;
            CurrFrameIndex = 0;
            IsPlaying = false; 
            GO = go;
            AddFrame(0);
            AddFrame(5);
        }

        public void AddFrame(float time, Keyframe frame)
        {
            Debug.Log("Frame Added at time " + time);
            if (Anim.ContainsKey(time)) Anim.Remove(time);
            Anim.Add(time,frame);
        }

        public void AddFrame(float time)
        {
            Keyframe frame = new Keyframe(GO, time);
            AddFrame(time, frame);
        }

        public void Play()
        {
            IsPlaying = true;
        }

        public void Pause()
        {
            IsPlaying = false;
        }

        public void Reset()
        {
            SeekPoint = 0;
            CurrFrameIndex = 0;
            IsPlaying = false;
        }

        public void Update()
        {
            if( IsPlaying)
            {
                IList<float> times = Anim.Keys;
                SeekPoint += Time.deltaTime;
                if (SeekPoint > Length)
                {
                    if (Loop)
                    {
                        SeekPoint = 0;
                        CurrFrameIndex = 0;
                    }
                    else
                    {
                        Reset();
                    }
                }
                if( times[CurrFrameIndex + 1] < SeekPoint)
                {
                    CurrFrameIndex++;
                    Anim[times[CurrFrameIndex]].Apply(GO);
                }
            }
            
        }

        Keyframe findNearestFrame(float time)
        {
            IList<float> times = Anim.Keys;
            Keyframe ret = Anim[times[0]];
            for (int i=0; i < times.Count; i++)
            {
                if (times[i] > time)
                {
                    ret = Anim[times[i - 1]];
                    break;
                }
            }

            return ret;
        }
    }

}
