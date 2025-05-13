using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int Score;
    public static GameManager myInstance;
public GameObject GameoverPanel;
    void Awake()
    {
        myInstance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
