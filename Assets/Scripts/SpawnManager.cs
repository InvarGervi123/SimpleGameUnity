using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private Vector2 currentSpawn;

    void Awake()
    {
        instance = this;
        currentSpawn = transform.position; // נקודת ההתחלה
    }

    public void SetSpawn(Vector2 point)
    {
        currentSpawn = point;
        Debug.Log("Spawn set to: " + point);
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = currentSpawn;

        // איפוס מהירות כדי למנוע "קפיצה" אחרי החזרה
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }
}
