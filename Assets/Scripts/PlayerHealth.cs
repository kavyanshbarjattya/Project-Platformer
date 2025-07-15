using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] AudioSource _playerAudioSource , m_AudioSource;
    [SerializeField] AudioClip _hurtClip , _deathAudio;
    [SerializeField] GameObject _gameOverPanel;

    public int _health;


    public int _currentHealth;


    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if(_currentHealth <= 0)
        {
            m_AudioSource.clip = _deathAudio;
            m_AudioSource.Play();
            _gameOverPanel.SetActive(true);
            Destroy(gameObject);
        }
    }

    public int TakeDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            _playerAudioSource.clip = _hurtClip;
            _playerAudioSource.Play();
        }
        return _currentHealth;
    }
}
