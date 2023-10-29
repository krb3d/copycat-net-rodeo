namespace BlazorWebApplication2.Shared;

public sealed class Message
{
    public Guid Id { get; set; }

    public string Text { get; set; } = string.Empty;
}
