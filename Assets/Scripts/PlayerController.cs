using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float reductionSpeed; 
    private float rotationSpeed;

    private void Awake()
    {
        reductionSpeed = 0.5f;
        rotationSpeed = 200f;
        EventController.LevelComplete.AddListener(AnimationUdapter);
    }

    private void AnimationUdapter()
    {
        StartCoroutine(CompleteLevelAnimation());
    }

    private IEnumerator CompleteLevelAnimation()
    {
        EventController.SwitchInputSystemEvent.Invoke(false);
        while (gameObject.transform.localScale.x > 0.1f)
        {
            gameObject.transform.localScale -= reductionSpeed * Time.deltaTime * Vector3.one;
            gameObject.transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);

            rotationSpeed += 5f;

            yield return null;
        }

        Destroy(gameObject);
    }

    private void PlayerDeath()
    {
        Destroy(gameObject);
        EventController.LevelFailed.Invoke();
    }
}
