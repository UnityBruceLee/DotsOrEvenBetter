﻿using UnityEngine;

namespace Dots.Utils
{
    public class GameExit : MonoBehaviour
    {
        protected virtual void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }

        private void OnApplicationQuit()
        {
            SaveManager.SaveProgress(UIManager.Instance.Scores);
        }
    }
}
