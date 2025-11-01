using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float speed = 6f;
    Rigidbody2D rb;
    Vector2 input;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;
        input = Vector2.zero;
        if (k.aKey.isPressed || k.leftArrowKey.isPressed) input.x -= 1;
        if (k.dKey.isPressed || k.rightArrowKey.isPressed) input.x += 1;
        if (k.wKey.isPressed || k.upArrowKey.isPressed) input.y += 1;
        if (k.sKey.isPressed || k.downArrowKey.isPressed) input.y -= 1;
        input = input.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}
