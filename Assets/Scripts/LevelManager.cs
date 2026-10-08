using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text coinsText, livesText;
    [SerializeField] private GameObject panelGameOver, panelWin;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinsText();
        UpdateLivesText();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinsText()
    {
        if (GameManager.instance.gameData.totalCoins >= 10)
        {
            coinsText.text = "0";
            GameManager.instance.gameData.totalCoins = 0;
            GameManager.instance.gameData.totalLives++;
            UpdateLivesText();
        }
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
        //SceneManager.LoadScene(NextLevelName); //Si los niveles no tienen un orden
    }
    
    public void ActivatePanelGameOver()
    {
        panelGameOver.SetActive(true);
    }
    
    public void FinishLevel()
    {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }
}
