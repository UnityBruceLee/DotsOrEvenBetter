using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dots
{
    [System.Serializable]
    public class ProgressData
    {
        public int scores;

        public ProgressData(int currentScores)
        {
            scores = currentScores;
        }
    }
}
