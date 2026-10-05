using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text coinsText, livesText;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelWin;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinsText();
        UpdateLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinsText()
    {
        coinsText.text = "x" + GameManager.instance.gameData.totalCoins.ToString();
    }
    
    public void UpdateLivesText()
    {
        livesText.text = "x" + GameManager.instance.gameData.totalLives.ToString();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void RestartButton()
    {
        GameManager.instance.gameData.totalLives = 3;
        GameManager.instance.gameData.totalCoins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ActivatePanelGameOver()
    {
        panelGameOver.SetActive(true);
    }
    
    public void ActivatePanelWin()
    {
        panelWin.SetActive(true);
    }
}
