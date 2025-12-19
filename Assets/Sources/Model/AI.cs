using System;
using Newtonsoft.Json;

namespace Sources
{
    public class AI : IDisposable
    {
        private readonly PythonDll _bot;
        private readonly IChatView _view;
        private readonly IStatsView _statsView;
        private readonly IPersonalityMenu _personality;

        public AI(IChatView view, IPersonalityMenu personality, IStatsView statsView, PythonDll bot)
        {
            _view = view;
            _view.UserSentMessage += GenerateReply;
            _personality = personality;
            _personality.ChangedPersonality += ChangePersonality;
            _statsView = statsView;

            _bot = bot;
        }

        private void ChangePersonality(Personality personality)
        {
            _bot.GetVariable("change_personality")(personality.ToString().ToLower());
        }

        private void GenerateReply(string message)
        {
            string replyJson = _bot.GetVariable("chat")(message);
            var reply = JsonConvert.DeserializeObject<AIReplyInfo>(replyJson);

            _view.SendAIMessage(reply.response);
            _statsView.UpdateStats(reply);
        }

        public void Dispose()
        {
            _view.UserSentMessage -= GenerateReply;
            _personality.ChangedPersonality -= ChangePersonality;
        }
    }
}
