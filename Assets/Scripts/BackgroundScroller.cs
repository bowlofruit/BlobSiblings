using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    [SerializeField] private float _scrollSpeed;
    private float _offset;
    private Material _backgroundMaterial;

    private void Awake()
    {
        _backgroundMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _offset += (Time.deltaTime * _scrollSpeed);
        _backgroundMaterial.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }
}
