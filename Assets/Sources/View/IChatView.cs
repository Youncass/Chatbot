using System;

namespace Sources
{
    public interface IChatView
    {
        event Action<string> UserSentMessage;

        void SendAIMessage(string content);
    }
}
