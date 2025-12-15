using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources
{
    public class OptionsMenu : MonoBehaviour, IPersonalityMenu
    {
        [SerializeField] private CanvasGroup _cg;
        [SerializeField] private Button _openButton;
        [SerializeField] private Toggle[] _personalityToggles;

        public event Action<Personality> ChangedPersonality;

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
                if (_cg.interactable)
                    CloseMenu();
                else
                    OpenMenu();
            }
        }

        private void ChangePersonality(int index)
        {
            ChangedPersonality.Invoke((Personality)index);
            CloseMenu();
        }

        private void OpenMenu()
        {
            _cg.alpha = 1;
            _cg.interactable = true;
            _cg.blocksRaycasts = true;
        }

        private void CloseMenu()
        {
            _cg.alpha = 0;
            _cg.interactable = false;
            _cg.blocksRaycasts = false;
        }
    }
}
