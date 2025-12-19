using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Sources
{
    public class StatsView : MonoBehaviour, IStatsView
    {
        [SerializeField] private TMP_Text _moodDescription, _memoryFacts, _conversationCount;
        [SerializeField] private Image _energy, _mood;
        [SerializeField] private Gradient _lowToHighColors;
        [SerializeField] private float _updateTime;

        public void UpdateStats(AIReplyInfo stats)
        {
            _moodDescription.text = stats.mood_description;
            _memoryFacts.text = stats.memory_facts.ToString();
            _conversationCount.text = stats.conversation_count.ToString();

            _energy.DOFillAmount(stats.energy, _updateTime);
            _energy.DOColor(_lowToHighColors.Evaluate(stats.energy), _updateTime);

            _mood.DOFillAmount(stats.mood, _updateTime);
            DOVirtual.Color(_mood.color, _lowToHighColors.Evaluate(stats.mood), _updateTime, v => _mood.color = _moodDescription.color = v);
        }
    }
}
