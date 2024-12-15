using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;

    [Header("Health UI")]
    [SerializeField] private TextMeshProUGUI healthText;

    private static CanvasManager instance;
    public static CanvasManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        InitializePauseMenu();
    }

    private void InitializePauseMenu()
    {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.SetText(currentHealth.ToString());
        }
    }

    public void ClickPause()
    {
        Time.timeScale = 0f;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);
    }

    public void ClickResume()
    {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void ClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}