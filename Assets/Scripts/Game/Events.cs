using UnityEngine;

public static class Events
{
    public static GameOverEvent GameOverEvent = new GameOverEvent();
    public static DisplayMessageEvent DisplayMessageEvent = new DisplayMessageEvent();
    public static InteractEvent InteractEvent = new InteractEvent();
}


public class GameOverEvent : GameEvent
{
    public bool PuzzleSolved;
    public string EndGameMessage;
}

public class DisplayMessageEvent : GameEvent
{
    public string Message;
    public float DelayBeforeDisplay;
}

public class InteractEvent : GameEvent
{
    public string ObjectTag;
}