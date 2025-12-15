using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources
{
    public class StatsView : MonoBehaviour, IStatsView
    {
        [SerializeField] private TMP_Text _moodDescription, _memoryFacts, _conversationCount;
        [SerializeField] private Image _energy, _mood;
        [SerializeField] private Gradient _lowToHighColors;

        public void UpdateStats(AIReplyInfo stats)
        {
            _moodDescription.text = stats.mood_description;
            _memoryFacts.text = stats.memory_facts.ToString();
            _conversationCount.text = stats.conversation_count.ToString();

            _energy.fillAmount = stats.energy;
            _energy.color = _lowToHighColors.Evaluate(stats.energy);

            _mood.fillAmount = stats.mood;
            _mood.color = _moodDescription.color = _lowToHighColors.Evaluate(stats.mood);
        }
    }
}
