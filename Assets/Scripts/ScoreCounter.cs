using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int EnemiesKilled;
    public static int CollectablesEarned;
    
    public static int FinalScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemiesKilled = 0;
        CollectablesEarned = 0;

        FinalScore = 0;
    }
    
    
    public static void CalculateFinalScore(float time)
    {
        FinalScore = EnemiesKilled * 5;
        FinalScore += CollectablesEarned * 10;
        FinalScore += Mathf.FloorToInt(time);
    }
}
