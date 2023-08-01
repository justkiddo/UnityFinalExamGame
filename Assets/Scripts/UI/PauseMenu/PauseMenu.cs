using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace root
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private TextMeshProUGUI continueButtonText;
        [SerializeField] private TextMeshProUGUI menuButtonText;
        [SerializeField] private TextMeshProUGUI quitText;
        [SerializeField] private GameObject pauseMenu;
        private IUnityLocalization _localization;
        private bool _paused;

        [Inject]
        private void Construct(IUnityLocalization localization)
        {
            _localization = localization;
        }

        private void Awake()
        {
            AddListeners();
            pauseButton.onClick.AddListener(OnPauseClick);
        }

        private void Update()
        {
            if (!pauseMenu.activeInHierarchy)
            {
                _paused = false;
            }
        }

        private void OnPauseClick()
        {
            if (!_paused)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                _paused = true;
            }
            else if(_paused)
            {
                _paused = false;
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
            }
        }

        private void AddListeners()
        {
            quitText.text = _localization.Translate("quit.button");
            continueButtonText.text = _localization.Translate("pause.continue");
            menuButtonText.text = _localization.Translate("tab.menu");
        }
    }
}