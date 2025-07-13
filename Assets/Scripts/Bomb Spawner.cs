using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject _bomb;
    [SerializeField] Transform _playerTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        Instantiate(g,_playerTrans.position,Quaternion.identity);
    }
}
