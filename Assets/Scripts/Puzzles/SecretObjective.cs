﻿using UnityEngine;

public enum SecretObjectiveID
{
  LookThroughWindow,
  InvertTypewriter,
  DropCorrect,
  SpinGlobeThrice,
  SkullOffShelf,
  SolveWithThreeOnTimer,
  SetClockTo545,
  StationaryGramophone,
  SolveQuickly,
  Blackout,
  Librarian,
  OpenDeskDrawers,
  PenArson,
  CarefulBookInspection,
  _PLACEHOLDER
}

public class SecretObjective
{
  public string clue;
  public bool completed;
  public string description;
  public SecretObjectiveID id;
  public PlayerController player;

  public SecretObjective(PlayerController player, string desc, string clue, SecretObjectiveID id)
  {
    this.id = id;
    this.player = player;
    completed = false;
    description = desc;
    this.clue = clue;
    EventManager.AddListener<SecretObjectiveEvent>(updateStatus);
  }

  public void Deconstruct()
  {
    EventManager.RemoveListener<SecretObjectiveEvent>(updateStatus);
  }

  public void updateStatus(SecretObjectiveEvent evt)
  {
    if (evt.id == id)
    {
      completed = evt.status;
    }
  }
}