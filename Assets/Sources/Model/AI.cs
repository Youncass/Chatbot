using System;

namespace Sources
{
    public class AI : IDisposable
    {
        private readonly PythonDll _bot;
        private readonly IChatView _view;

        public AI(IChatView view, PythonDll bot)
        {
            _view = view;
            _view.UserSentMessage += GenerateReply;

            _bot = bot;
        }

        private void GenerateReply(string message)
        {
            string reply = _bot.GetVariable("chat")(message);
            _view.SendAIMessage(reply);
        }

        public void Dispose()
        {
            _view.UserSentMessage -= GenerateReply;
        }
    }
}
