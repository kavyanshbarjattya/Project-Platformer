using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _bombLimitationTxt;
    [SerializeField] TextMeshProUGUI _playerLivesTxt;
    [SerializeField] BombSpawner _spawner;
    [SerializeField] PlayerHealth _ph;

    private void Start()
    {
        _bombLimitationTxt.text = _spawner._currentLimit.ToString();
        _playerLivesTxt.text = _ph._currentHealth.ToString();
    }

    private void Update()
    {
        _bombLimitationTxt.text = _spawner._currentLimit.ToString();
        _playerLivesTxt.text = _ph._currentHealth.ToString();
    }

    public void ReturnToMenu()
    {
        // Return to menu
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        // Activate the pause menu Ui
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void WinScreen()
    {
        Time.timeScale = 0;
        //WinScreen Activate
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
