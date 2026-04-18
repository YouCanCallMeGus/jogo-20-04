using UnityEngine;
using UnityEngine.InputSystem;

public class RightStick : MonoBehaviour
{
    public Transform player;
    private float radius = 1.2f;
    private float deadzone = 0.2f;

    private void Update()
    {
        if (player == null || Gamepad.current == null)
        {
            transform.position = new Vector3(-10,-10);
            return;
        }

        Vector2 stick = Gamepad.current.rightStick.ReadValue();

        if (stick.magnitude < deadzone)
        {
            transform.position = player.position;
            return;
        }   

        Vector2 direction = stick.normalized;
        transform.position = player.position + (Vector3)(direction * radius);
        
    }
}