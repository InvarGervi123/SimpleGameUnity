using UnityEngine;

public class Goal : MonoBehaviour
{
    void Reset()
    {
        var col = GetComponent<Collider2D>();
        if (col) col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGER with: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("YOU WIN!");
            Time.timeScale = 0f; // לעצור משחק
        }
    }
}
