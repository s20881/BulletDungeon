using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyButton : MonoBehaviour
{
    private enum Difficulty
    {
        Easy, Normal, Hard
    }

    [SerializeField] private GameData gameData;
    private Difficulty selectedDifficulty = Difficulty.Normal;
    private TextMeshProUGUI button;

    private void Start()
    {
        button = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void NextDifficulty()
    {
        switch(selectedDifficulty)
        {
            case Difficulty.Easy:
                selectedDifficulty = Difficulty.Normal;
                gameData.level = 0.7f;
                gameData.levelenem = 1.2f;
                break;
            case Difficulty.Normal:
                selectedDifficulty = Difficulty.Hard;
                gameData.level = 1f;
                gameData.levelenem = 1f;
                break;
            case Difficulty.Hard:
                selectedDifficulty = Difficulty.Easy;
                gameData.level = 1.2f;
                gameData.levelenem = 0.8f;
                break;
        }
        button.text = selectedDifficulty.ToString();
    }
}
