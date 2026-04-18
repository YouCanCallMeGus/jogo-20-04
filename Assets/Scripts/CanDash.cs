using UnityEngine;
using UnityEngine.UI;

public class CanDash : MonoBehaviour
{
    public Image image;
    
    void Update()
    {
        if (Time.time - PlayerMovement.LastDashTime > 3)
        {
            image.enabled = true;
          
        }
        else
        {
            image.enabled = false;
        }
    }
}
