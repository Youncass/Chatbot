using System;

namespace Sources
{
    [Serializable]
    public struct AIReplyInfo
    {
        public string response, personality, mood_description;
        public float energy, mood;
        public int memory_facts, conversation_count;
    }
}
