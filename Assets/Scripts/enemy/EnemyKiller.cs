using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyKiller : MonoBehaviour
{
    public Transform aim;
    public AudioSource enemyBoopSound;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            enemyBoopSound.Play();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.tag == "enemy")
            {
                Destroy(hit.collider.gameObject);
                ScoreCounter.EnemiesKilled++;
            }
        }
        
        if (Gamepad.current != null && Gamepad.current.rightShoulder.wasPressedThisFrame)
        {
            enemyBoopSound.Play();
            RaycastHit2D hit = Physics2D.Raycast(aim.position, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("enemy"))
            {
                Destroy(hit.collider.gameObject);
                ScoreCounter.EnemiesKilled++;
            }
        }
    }
}
