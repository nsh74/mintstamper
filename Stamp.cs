namespace mintstamper;

public enum StampTypeEnum
{
    Regular,
    Control,
    Note,
    Stacked,
    Adjust
}

public record Stamp
(
    string Text,
    List<string>? HighlightedWords,
    StampTypeEnum StampType,
    bool IsBirthday,
    int TimestampSeconds
);

