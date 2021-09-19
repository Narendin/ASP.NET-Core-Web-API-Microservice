using System;

namespace MetricsManager
{
    public class AgentInfo // Пока не менял, помню про то, что пользователь при регистрации не может задать себе id
    {
        public int AgentId { get; }

        public Uri AgentAddress { get; }
    }
}