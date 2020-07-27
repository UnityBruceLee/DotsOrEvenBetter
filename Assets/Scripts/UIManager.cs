using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Dots.Utils;



namespace Dots
{
    /// <summary>
    ///     Class responsible for showing scores.
    /// </summary>
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] Text scoreText;

        int scores;
        public int Scores
        {
            get { return scores; }
            set
            {
                scores = value;
                scoreText.text = scores.ToString();
            }
        }

        void Start()
        {
            if (!MoveManager.HasInstance)
            {
                return;
            }
            if (SaveManager.LoadProgress() != null)
            {
                Scores = SaveManager.LoadProgress().scores;
            } 
            else
            {
                Scores = 0;
            }

            MoveManager.Instance.MoveEnded += MoveManager_OnMoveEnded;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (!MoveManager.HasInstance)
            {
                return;
            }
            MoveManager.Instance.MoveEnded -= MoveManager_OnMoveEnded;
        }

        void MoveManager_OnMoveEnded(object sender, EventArgs eventArgs)
        {
            ScoresCounter();
        }

        void ScoresCounter()
        {
            var isSquare = MoveManager.Instance.IsSquare();

            if (MoveManager.Instance._selectedDots.Count <= 1)
            {
                return;
            }
            else
            {
                scoreText.color = MoveManager.Instance.StartedColor;
                if (isSquare)
                {
                    Scores += GlobalConstants.SquareScores;
                    return;
                }
                Scores += GlobalConstants.DotScores * MoveManager.Instance._selectedDots.Count;
            }
        }
    }
}

