using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpawnPoint : MonoBehaviour
{
    void Awake() { GetComponent<Collider2D>().isTrigger = true; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        SpawnManager.instance.SetSpawn(transform.position);
        Debug.Log("Checkpoint reached: " + transform.position);
    }
}
