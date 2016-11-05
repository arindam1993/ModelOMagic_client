using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace KeyframeSystem
{
    public class Keyframe
    {

        public List<AnimNode> Roots;
        public float TimeOffset;

        public Keyframe(GameObject sceneRoot)
        {
            Roots = new List<AnimNode>();
            IRecordable[] _roots = sceneRoot.GetComponentsInChildren<IRecordable>();
            foreach(IRecordable _root in _roots)
            {
                AnimNode _animRoot = AnimNode.GenerateFromTransform(_root.GetTransform());
                Roots.Add(_animRoot);
            }
        }

        public override string ToString()
        {
            string res = "[ \n";
            foreach(AnimNode _root in Roots)
            {
                res += _root.ToString();
            }
            res += "\n]";
            return res;
        }
    }
}


