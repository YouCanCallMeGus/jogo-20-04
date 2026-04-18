using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI TotalTime_txt;
    public TextMeshProUGUI TotalScore_txt;

    void Update()
    {
        TotalTime_txt.text = Timer.finalTime.ToString("Total time: 00.00");
        TotalScore_txt.text = ScoreCounter.FinalScore.ToString("Score: 0");
    }
}
