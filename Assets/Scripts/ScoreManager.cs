using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField scoreIf;
    [SerializeField] private Button saveScoreButton;

    private void OnEnable()
    {
        saveScoreButton.onClick.AddListener( () => AddScore());
    }

    // 랭킹 저장할 리스트
    public List<LeaderboardEntry> entries = new();

    private async void AddScore()
    {
        var response = await LeaderboardsService.Instance.AddPlayerScoreAsync("Ranking", int.Parse(scoreIf.text));
        Debug.Log(JsonConvert.SerializeObject(response));

        var ranking = await LeaderboardsService.Instance.GetScoresAsync("Ranking");
        entries = ranking.Results;

        string rank = "";
        foreach (var entry in entries)
        {
            rank += $"[{entry.Rank}] {entry.PlayerName} : {entry.Score}\n";
            // ScrollView의 Contents 하위에 프리팹 생성
        }

        Debug.Log(rank);
    }
}
