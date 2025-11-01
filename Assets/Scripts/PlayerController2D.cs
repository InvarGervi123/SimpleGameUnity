using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerPlatformer : MonoBehaviour
{
    public float speed = 6f;
    public float jumpSpeed = 12f;
    public LayerMask groundLayer;     // בחר כאן Ground ב-Inspector

    Rigidbody2D rb;
    Collider2D col;
    float x;
    bool wantJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        x = (k.dKey.isPressed || k.rightArrowKey.isPressed ? 1f : 0f)
          - (k.aKey.isPressed || k.leftArrowKey.isPressed ? 1f : 0f);

        if (k.spaceKey.wasPressedThisFrame || k.wKey.wasPressedThisFrame || k.upArrowKey.wasPressedThisFrame)
            wantJump = true;

        // אם נופל מתחת למפה
        if (transform.position.y < -10f)
            SpawnManager.instance.Respawn(gameObject);
    }


    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);

        bool grounded = col.IsTouchingLayers(groundLayer);   // בדיקת קרקע יציבה
        if (wantJump && grounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);

        wantJump = false;
    }
}
