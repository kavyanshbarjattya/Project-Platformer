using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject _bomb;
    [SerializeField] Transform _playerTrans;
    public int _bombSpawnLimitation;
    public int _currentLimit;

    private void Start()
    {
        _currentLimit = _bombSpawnLimitation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlantBomb(_bomb);

        }
    }

    void PlantBomb(GameObject g)
    {
        if (_currentLimit > 0)
        {
            Instantiate(g, _playerTrans.position, Quaternion.identity);
            _currentLimit--;
        }

    }
}
