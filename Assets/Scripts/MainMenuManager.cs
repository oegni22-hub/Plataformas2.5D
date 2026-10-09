using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] AudioClip music;
    private void Start()
    {
        Time.timeScale = 1;
        AudioManager.instance.PlayMusic(music);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void PlayLvl1()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayLvl2()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayLvl3()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayLvl4()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayLvl5()
    {
        SceneManager.LoadScene(6);
    }
}
