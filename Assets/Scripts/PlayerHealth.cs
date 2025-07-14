using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int _health;


    public int _currentHealth;


    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if(_currentHealth == 0)
        {
            // Game Over Screen Activate
            Time.timeScale = 0;
        }
    }

    public int TakeDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
        }
        Debug.Log(gameObject.name + "'s health: " + _currentHealth);
        return _currentHealth;
    }
}
