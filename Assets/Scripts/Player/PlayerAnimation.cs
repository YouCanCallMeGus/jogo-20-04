using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = PlayerMovement.movement;
        anim.SetFloat("Velx", direction.x);
        anim.SetFloat("Vely", direction.y);
    }
}
