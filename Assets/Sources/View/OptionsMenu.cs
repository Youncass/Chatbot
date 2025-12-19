using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Sources
{
    public class OptionsMenu : MonoBehaviour, IPersonalityMenu
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Toggle[] _personalityToggles;
        [SerializeField] private Vector2 _openedClosedY;
        [SerializeField] private float _switchTime;

        public event Action<Personality> ChangedPersonality;

        private bool _isOpened = false;

        private void Start()
        {
            for (int i = 0; i < _personalityToggles.Length; i++)
            {
                int j = i; // <- Не удалять эту строчку

                _personalityToggles[i].onValueChanged.AddListener(_ => ChangePersonality(j));
            }

            _openButton.onClick.AddListener(SwitchMenu);

            void SwitchMenu()
            {
                if (_isOpened)
                    CloseMenu();
                else
                    OpenMenu();
            }
        }

        private void ChangePersonality(int index)
        {
            ChangedPersonality?.Invoke((Personality)index);
            CloseMenu();
        }

        private void OpenMenu()
        {
            (transform as RectTransform).DOAnchorPosY(_openedClosedY.x, _switchTime);
            _isOpened = true;
        }

        private void CloseMenu()
        {
            (transform as RectTransform).DOAnchorPosY(_openedClosedY.y, _switchTime);
            _isOpened = false;
        }
    }
}
