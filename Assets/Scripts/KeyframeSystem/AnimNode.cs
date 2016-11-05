using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace KeyframeSystem
{
    public class AnimNode
    {

        //Relative to parent
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
        public AnimNode Parent;
        public List<AnimNode> Children;

        public AnimNode()
        {
            Children = new List<AnimNode>();
            Position = Vector3.zero;
            Rotation = Quaternion.identity;
            Parent = null;
        }

        public static AnimNode GenerateFromTransform(Transform root)
        {
            AnimNode _root = new AnimNode(root.localPosition, root.localRotation, root.localScale);
            _genTreeRecur(root, _root);
            return _root;
        }


        public static void _genTreeRecur(Transform src, AnimNode dest)
        {
            foreach(Transform child in src)
            {
                AnimNode _copy = new AnimNode(child.localPosition, child.localRotation, child.localScale);
                dest.AddChild(_copy);
                _genTreeRecur(child, _copy);
            }
        }

        public  static AnimNode CopyTree(AnimNode node)
        {
            AnimNode _copy = new AnimNode(node.Position, node.Rotation, node.Scale);
            _copyTreeRecur(node, _copy);
            return _copy;
        }

        private static void _copyTreeRecur(AnimNode src, AnimNode dest)
        {
            foreach(AnimNode child in src.Children)
            {
                AnimNode _copy = new AnimNode(child.Position, child.Rotation, child.Scale);
                dest.AddChild(_copy);
                _copyTreeRecur(child, _copy);
            }
        }

        public AnimNode(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Children = new List<AnimNode>();
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Parent = null;
        }

        public void AddChild(AnimNode child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public void AddChild(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            AnimNode node = new AnimNode(position, rotation, scale);
            this.AddChild(node);
        }

        public override string ToString()
        {
            string res = "";
            res += "{ Position: " + Position + ",\n";
            res += " Rotation: " + Rotation + ",\n";
            res += " Children: [ \n";
            foreach(AnimNode _node in Children)
            {
                res += _node.ToString() + ",\n";
            }
            res += "] }";
            return res;
        }
    }

}

