using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace KeyframeSystem
{
    public class Keyframe
    {

        public List<AnimNode> Roots;


        public Keyframe(GameObject sceneRoot, float offset)
        {
            Roots = new List<AnimNode>();
            IRecordable[] _roots = sceneRoot.GetComponentsInChildren<IRecordable>();
            foreach(IRecordable _root in _roots)
            {
                AnimNode _animRoot = AnimNode.GenerateFromTransform(_root.GetTransform());
                Roots.Add(_animRoot);
            }

        }

        public void Apply(GameObject sceneRoot)
        {
            IRecordable[] _roots = sceneRoot.GetComponentsInChildren<IRecordable>();
            for ( int chI = 0; chI < _roots.Length; chI++)
            {
                _roots[chI].ApplyNode(Roots[chI]);
            }

        }

        public override string ToString()
        {
            string res = "[ \n";
            foreach(AnimNode _root in Roots)
            {
                res += _root.ToString() +",\n";
            }
            res += "\n]";
            return res;
        }
    }
}


