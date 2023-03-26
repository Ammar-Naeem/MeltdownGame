using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meltdown
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject restartSceen;
        
        private void OnEnable()
        {
            GameManager.OnGameEnd += GameEndListener;
        }

        private void OnDisable()
        {
            GameManager.OnGameEnd -= GameEndListener;
        }

        private void GameEndListener()
        {
            restartSceen.SetActive(true);
        }

        public void OnRestartPress()
        {
            SceneManager.LoadScene(0);
        }
    }
}
