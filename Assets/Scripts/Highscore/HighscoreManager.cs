using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    private string keyToSave = "keyHighScore";

    [Header("References")]
    public TextMeshProUGUI uiTextHighScore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateTexte();
    }

    private void UpdateTexte()
    {
        uiTextHighScore.text = PlayerPrefs.GetString(keyToSave, "Sem High Score");
    }

    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateTexte();
    }
}
