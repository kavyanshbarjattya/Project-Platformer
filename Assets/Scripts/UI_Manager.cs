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
        if (_bombLimitationTxt != null)
        {
            _bombLimitationTxt.text = _spawner._currentLimit.ToString();
        }
        if (_playerLivesTxt != null)
        {
            _playerLivesTxt.text = _ph._currentHealth.ToString();
        }
    }

    private void Update()
    {
        if (_bombLimitationTxt != null)
        {
            _bombLimitationTxt.text = _spawner._currentLimit.ToString();
        }
        if (_playerLivesTxt != null)
        {
            _playerLivesTxt.text = _ph._currentHealth.ToString();
        }
    }

    public void PlayBtn(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToMenu(string SceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }

    public void RetryBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
