using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace Sources
{
    public class ChatView : MonoBehaviour, IChatView
    {
        [SerializeField] private TMP_InputField _userInput;
        [SerializeField] private Button _sendButton;
        [SerializeField] private Scrollbar _chatScrollbar;

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

            _userInput.text = string.Empty;
            _userInput.ActivateInputField();
        }

        private void CreateMessage(string sender, string content, Color messageColor)
        {
            Instantiate(_messagePrefab, transform).UpdateContent(sender, content, messageColor);
            _chatScrollbar.value = 0;
        }

        private void OnDisable()
        {
            _userInput.onSubmit.RemoveListener(SendUserMessage);
            _sendButton.onClick.RemoveListener(SendUserMessage);
        }
    }
}
