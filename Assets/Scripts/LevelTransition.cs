using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] Transform[] _levelTrans;
    [SerializeField] float _cameraMoveSpeed = 2f;
    [SerializeField] Vector3 _cameraOffset;
    [SerializeField] GameObject _winScreen;

    int _levelIndex = 0;
    bool _isTransition = false;
    Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = _levelTrans[_levelIndex].position + _cameraOffset;
        transform.position = _targetPosition;
    }

    private void Update()
    {


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
            _targetPosition = new Vector3(transform.position.x, _levelTrans[_levelIndex].position.y + _cameraOffset.y, transform.position.z);
            _isTransition = true;
        }
        else
        {
            Time.timeScale = 0;
            _winScreen.SetActive(true);
        }
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _cameraMoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.05f)
        {
            transform.position = _targetPosition;
            _isTransition = false;
        }
    }
}
