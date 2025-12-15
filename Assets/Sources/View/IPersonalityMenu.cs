using System;

namespace Sources
{
    public interface IPersonalityMenu
    {
        event Action<Personality> ChangedPersonality;
    }
}
