using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timelevel_txt;
    public static float timelevel;
    public static float finalTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timelevel = 0;
    }

    // Update is called once per frame
  

    void Update()
    {

        timelevel += Time.deltaTime;
        timelevel_txt.text = timelevel.ToString("00.00");
        
    }
}
