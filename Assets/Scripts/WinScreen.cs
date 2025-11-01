using UnityEngine;

public class WinScreen : MonoBehaviour
{
    static WinScreen instance;
    [SerializeField] GameObject panel;

    void Awake() => instance = this;

    public static void Show()
    {
        if (instance == null)
        {
            var go = new GameObject("WinText");
            var tm = go.AddComponent<TextMesh>();
            tm.text = "YOU WIN\nPress R to Restart";
            tm.fontSize = 64;
            go.transform.position = Camera.main.transform.position + new Vector3(0, 0, 5);
            instance = go.AddComponent<WinScreen>();
        }
        else if (instance.panel) instance.panel.SetActive(true);
    }

    void Update()
    {
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
