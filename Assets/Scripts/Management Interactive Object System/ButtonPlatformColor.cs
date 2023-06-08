using UnityEngine;

public class ButtonPlatformColor : MonoBehaviour
{
    [SerializeField] Color _currentColor;
    [SerializeField] SpriteRenderer[] _linkedPlatformsSprites;
    [SerializeField] SpriteRenderer _buttonColorSprite;

    private float brightnessFactor = 1.5f;

    private void Awake()
    {
        ColorInit(_currentColor);
        GetComponent<ButtonController>().OnPressedButton?.AddListener(SetColor);
    }

    public void SetColor(bool isActive)
    {
        if(isActive)
        {
            Color brighterColor = new Color(
            Mathf.Clamp01(_currentColor.r * brightnessFactor),
            Mathf.Clamp01(_currentColor.g * brightnessFactor),
            Mathf.Clamp01(_currentColor.b * brightnessFactor),
            _currentColor.a
            );

            ColorInit(brighterColor);
        }
        else
        {
            ColorInit(_currentColor);
        }
    }

    private void ColorInit(Color color)
    {
        foreach (var platform in _linkedPlatformsSprites)
        {
            platform.color = color;
        }
        _buttonColorSprite.color = color;
    }
}