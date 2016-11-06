using UnityEngine;
using System.Collections;

namespace KeyframeSystem
{
    public interface IRecordable
    {

        Transform GetTransform();
        void ApplyNode(AnimNode frame);
    }

}
