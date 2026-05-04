using System;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField scoreIf;
    [SerializeField] private Button saveScoreButton;

    private void OnEnable()
    {
        saveScoreButton.onClick.AddListener( () => AddScore());
    }

    private async void AddScore()
    {
        var response = await LeaderboardsService.Instance.AddPlayerScoreAsync("Ranking", int.Parse(scoreIf.text));
        Debug.Log(JsonConvert.SerializeObject(response));
    }
}
