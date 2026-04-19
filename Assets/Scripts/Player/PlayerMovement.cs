using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    Vector2 TargetPosition;
    private const int DashDistance = 3;
    public static float LastDashTime;
    private float DashCooldown;
	public AudioSource coinSound;
    public AudioSource dashSound;
    
    
    public static Vector2 movement;
    public float speed;
    void Start()
    {
        LastDashTime = 0f;
        DashCooldown = 3f;
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        player.MovePosition(player.position + movement * speed * Time.deltaTime);
        
        // dash - mouse
        if (Input.GetMouseButtonDown(1) && CanDash())
        {
            dashSound.Play();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = ((Vector2) mouseWorldPos - player.position).normalized;
            
            if (((Vector2)mouseWorldPos - player.position).magnitude < DashDistance)
            {
                player.position = mouseWorldPos;
            }
            else
            {
                player.position += direction * DashDistance;
            }
        }
        // dash - controller
        if (Gamepad.current != null && Gamepad.current.leftShoulder.wasPressedThisFrame && CanDash())
        {
            dashSound.Play();
            Vector2 stick = Gamepad.current.leftStick.ReadValue();

            if (stick.magnitude > 0.2f)
            {
                Vector2 direction = stick.normalized;
                player.position += direction * DashDistance;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            coinSound.Play();
            Destroy(other.gameObject);
            ScoreCounter.CollectablesEarned++;
        } else if  (other.tag == "enemy")
        {
            Destroy(player.gameObject);
            ScoreCounter.CalculateFinalScore(Timer.timelevel);
            Timer.finalTime = Timer.timelevel;
            SceneManager.LoadScene("GameOver");
        }
    }

    private bool CanDash()
    {
        if (Time.time - LastDashTime >= DashCooldown)
        {
            LastDashTime = Time.time;
            return true;
        }

        return false;
    }


}
