using UnityEngine;

public class Game_Wining : MonoBehaviour
{
    [SerializeField] LevelTransition _levelTransition;
    [SerializeField] Timer _timer;
    [SerializeField] PlayerHealth _ph;
    [SerializeField] BombSpawner _bombSpawner;
    [SerializeField] Transform _playerTrans;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] GameObject _instructionUi;
    [SerializeField] AudioSource _levelComplete;
    [SerializeField] AudioClip _winClip;

    public LevelInfo[] levelInfo;



    public int _currentLevel;

    private void Start()
    {
        levelInfo[_currentLevel].level_number = _currentLevel;
        _playerTrans.position = _spawnPoints[_currentLevel].position;
        _instructionUi.SetActive(true);
    }

    private void Update()
    {
        if (levelInfo[_currentLevel]._total_enemies == 0 && _currentLevel < levelInfo.Length - 1)
        {
            Debug.Log("Level Completed");
            _levelComplete.clip = _winClip;
            _levelComplete.Play();
            _instructionUi.SetActive(false);
            _currentLevel++;
            levelInfo[_currentLevel].level_number = _currentLevel;
            _levelTransition.StartTransition();
            ResetValues();
        }
    }

    private void ResetValues()
    {
        _ph._currentHealth = _ph._health;
        _bombSpawner._currentLimit = _bombSpawner._bombSpawnLimitation;
        _playerTrans.position = _spawnPoints[_currentLevel].position;
        _playerMovement._currentSpeed = 0;
        _timer._currentTime = _timer.timeRemaining;
    }
}

[System.Serializable]
public class LevelInfo
{
    public int level_number;
    public int _total_enemies;
}
