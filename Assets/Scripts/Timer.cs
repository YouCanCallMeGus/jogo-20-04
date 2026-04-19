using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timelevel_txt;
    public static float timelevel;
    public static float finalTime;
    
    void Start()
    {
        timelevel = 0;
    }
  

    void Update()
    {

        timelevel += Time.deltaTime;
        timelevel_txt.text = timelevel.ToString("00.00");
        
    }
}
