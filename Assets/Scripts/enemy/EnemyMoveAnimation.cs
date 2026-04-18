using UnityEngine;

public class EnemyMoveAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = EnemyMovement.direction;
        anim.SetFloat("Velx", direction.x);
        anim.SetFloat("Vely", direction.y);
    }
}
