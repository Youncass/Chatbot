using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources
{
    public class ChatView : MonoBehaviour, IChatView
    {
        [SerializeField] private TMP_InputField _userInput;
        [SerializeField] private Button _sendButton;

        [SerializeField] private MessageView _messagePrefab;
        [SerializeField] private Color _userColor, _aiColor;

        public event Action<string> UserSentMessage;

        public void SendAIMessage(string content)
        {
            CreateMessage("AI", content, _aiColor);
        }

        private void OnEnable()
        {
            _userInput.onSubmit.AddListener(SendUserMessage);
            _sendButton.onClick.AddListener(SendUserMessage);
        }

        private void SendUserMessage() => SendUserMessage(_userInput.text);

        private void SendUserMessage(string message)
        {
            CreateMessage("User", message, _userColor);
            UserSentMessage.Invoke(message);
        }

        private void CreateMessage(string sender, string content, Color messageColor)
        {
            Instantiate(_messagePrefab, transform).UpdateContent(sender, content, messageColor);
        }

        private void OnDisable()
        {
            _userInput.onSubmit.RemoveListener(SendUserMessage);
            _sendButton.onClick.RemoveListener(SendUserMessage);
        }
    }
}
