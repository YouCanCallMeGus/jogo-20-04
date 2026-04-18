using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeRemaining : MonoBehaviour
{
    public TextMeshProUGUI timelevel_txt;
    public float TimeLeft;
  
    
    private int LastEnemmiesKilled;
    
    void Start()
    {
        LastEnemmiesKilled = 0;
        TimeLeft = 60;
    }
    
    void Update()
    {
     
        int currentKills = ScoreCounter.EnemiesKilled;
        if (currentKills > LastEnemmiesKilled)
        {
            int diff = currentKills - LastEnemmiesKilled;
            TimeLeft += diff;
            LastEnemmiesKilled = currentKills;
        }
        TimeLeft -= Time.deltaTime;
        timelevel_txt.text = TimeLeft.ToString("00.00");

        if (TimeLeft <= 0)
        {
            
            ScoreCounter.CalculateFinalScore(Timer.timelevel);
            Timer.finalTime = Timer.timelevel;
            SceneManager.LoadScene("GameOver");
        }
    }
}
