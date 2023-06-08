using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private enum Side
    {
        Down = -1,
        Up = 1
    }

    [SerializeField] private GameObject[] _buttons;
    private Vector3 _activePos;
    private Vector3 _originPos;
    private Vector3 _currentPos;
    [SerializeField] private Side _side;
    [SerializeField] private float _height;

    private Coroutine _movementCoroutine;
    private float _movementDuration;

    private void Awake()
    {
        foreach (var button in _buttons)
        {
            button.GetComponent<ButtonController>().OnPressedButton.AddListener(ChangePlatformPosition);
        }
        _originPos = transform.position;
        _currentPos = _originPos;
        _activePos = new Vector3(0f, (float)_side * _height, 0f) + transform.position;
        _movementDuration = _height + 0.5f;
    }

    private void ChangePlatformPosition(bool isActive)
    {
        if (_movementCoroutine != null)
        {
            StopCoroutine(_movementCoroutine);
        }

        if (isActive)
        {
            _movementCoroutine = StartCoroutine(MoveObject(_currentPos, _activePos, _movementDuration));
        }
        else
        {
            _movementCoroutine = StartCoroutine(MoveObject(_currentPos, _originPos, _movementDuration));
        }
    }

    private IEnumerator MoveObject(Vector3 startPoint, Vector3 endPoint, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _currentPos = Vector3.Lerp(startPoint, endPoint, elapsedTime / duration);

            transform.position = _currentPos;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPoint;
    }
}