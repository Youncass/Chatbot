using System;

namespace Sources
{
    public class AI : IDisposable
    {
        private readonly PythonDll _bot;
        private readonly IChatView _view;
        private readonly IPersonalityMenu _personality;

        public AI(IChatView view, IPersonalityMenu personality, PythonDll bot)
        {
            _view = view;
            _view.UserSentMessage += GenerateReply;
            _personality = personality;
            _personality.ChangedPersonality += ChangePersonality;

            _bot = bot;
        }

        private void ChangePersonality(Personality personality)
        {
            _bot.GetVariable("change_personality")(personality.ToString().ToLower());
        }

        private void GenerateReply(string message)
        {
            string reply = _bot.GetVariable("chat")(message);
            _view.SendAIMessage(reply);
        }

        public void Dispose()
        {
            _view.UserSentMessage -= GenerateReply;
            _personality.ChangedPersonality -= ChangePersonality;
        }
    }
}
