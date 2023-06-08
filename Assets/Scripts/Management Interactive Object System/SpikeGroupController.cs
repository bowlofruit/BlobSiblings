using System.Collections;
using UnityEngine;

public class SpikeGroupController : MonoBehaviour
{
    [SerializeField] private float _setActiveDelay;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(ActivateAfterDelay());
    }

    private IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(_setActiveDelay);
        _animator.enabled = true;
    }
}