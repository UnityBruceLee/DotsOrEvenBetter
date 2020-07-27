using System;
using System.Collections.Generic;
using UnityEngine;
using Dots.Utils;



namespace Dots
{
    /// <summary>
    ///     Class responsible for showing any visual aid regarding moves made.
    /// </summary>
    public class EffectsManager : Singleton<EffectsManager>
    {
        [SerializeField] ParticleSystem[] effects;

        void Start()
        {
            if (!MoveManager.HasInstance)
            {
                return;
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
            EffectsLauncher();
        }

        void EffectsLauncher()
        {
            var isSquare = MoveManager.Instance.IsSquare();

            if (MoveManager.Instance._selectedDots.Count <= 1)
            { 
                return;
            }
            else
            {
                if (isSquare)
                {
                    GenerateEffect(effects[1]);
                    return;
                }
                GenerateEffect(effects[0]);
            }
        }

        void GenerateEffect(ParticleSystem effectPref)
        {
            foreach (Dot dot in MoveManager.Instance._selectedDots)
            {

                var effect = Instantiate(effectPref, dot.transform.position, Quaternion.identity);
                effect.startColor = MoveManager.Instance.StartedColor;
            }
        }
    }
}
