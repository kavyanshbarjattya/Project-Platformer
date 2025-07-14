using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] Transform[] _levelTrans;
    [SerializeField] float _cameraMoveSpeed = 2f;
    [SerializeField] Vector3 _cameraOffset;

    int _levelIndex = 0;
    bool _isTransition = false;
    Vector3 _targetPosition;

    private void Start()
    {
        transform.position = _levelTrans[_levelIndex].position + _cameraOffset;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartTransition();
        }

        if (_isTransition)
        {
            MoveCamera();
        }
    }

    public void StartTransition()
    {
        if (_levelIndex < _levelTrans.Length - 1)
        {
            _levelIndex++;
            _targetPosition = _levelTrans[_levelIndex].position + _cameraOffset;
            _isTransition = true;
        }
        else
        {
            Debug.Log("No more levels!");
        }
    }

    void MoveCamera()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _cameraMoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.01f)
        {
            transform.position = _targetPosition;
            _isTransition = false;
        }
    }
}
