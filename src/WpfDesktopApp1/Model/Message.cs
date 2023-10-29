using System;

namespace WpfDesktopApp1.Model
{
    public sealed class Message
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = string.Empty;
    }
}
