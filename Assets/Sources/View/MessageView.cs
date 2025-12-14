using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources
{
    public class MessageView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _sender, _message;
        [SerializeField] private Image _background;

        public void UpdateContent(string sender, string message, Color color)
        {
            _sender.text = sender;
            _message.text = message;
            _background.color = color;
        }
    }
}
