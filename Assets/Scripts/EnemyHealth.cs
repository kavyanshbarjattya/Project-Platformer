using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    AudioSource _source;

    int _currentHealth;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if(_currentHealth <= 0)
        {
            if (_source != null)
            {
                _source.Play();
            }

        }
    }

    public int TakeDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
           
        }
        return _currentHealth;
    }
}
