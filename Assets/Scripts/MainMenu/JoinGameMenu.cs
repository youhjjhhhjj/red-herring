﻿using System;
using APIClient;
using TMPro;
using UnityEngine;

namespace MainMenu
{
    public class JoinGameMenu : MonoBehaviour
    {
        private bool ready;

        private void Awake()
        {
            EventManager.AddListener<GameCreatedEvent>(onGameCreated);
        }

        private void Start()
        {
            if (GameController.Instance.gameInstance != null)
            {
                PopulateGameInfo(GameController.Instance.gameInstance);
            }
        }

        private void Update()
        {
            if (!ready && GameController.Instance.gameInstance != null)
            {
                PopulateGameInfo(GameController.Instance.gameInstance);
                ready = true;
            }
        }

        private void OnDestroy()
        {
            EventManager.RemoveListener<GameCreatedEvent>(onGameCreated);
        }

        private void onGameCreated(GameCreatedEvent e)
        {
            PopulateGameInfo(e.gameInstance);
        }

        private void PopulateGameInfo(GameInstance gameInstance)
        {
            transform.Find("GameId").GetComponent<TMP_Text>().text = gameInstance.id;
            transform.Find("JoinCode").GetComponent<TMP_Text>().text = gameInstance.joinCode;
            transform.Find("QRCode").GetComponent<QRCodeObject>().QRCodeContent = $"https://rh.tongkun.io/join?joinCode={gameInstance.joinCode}";
            ready = true;
        }
    }
}