using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rb;
    private Transform player;
    public static Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {
            direction = (player.position - transform.position).normalized;
        }
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        
    }
}
