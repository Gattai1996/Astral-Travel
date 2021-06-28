using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Animator transitionAnimator;
    private float transitionTime = 1f;

    private void Awake()
    {
        transitionAnimator = transform.Find("Crossfade").GetComponent<Animator>();
    }

    public void RestartGame()
    {
        StartCoroutine(RestartGameCoroutine());
    }

    IEnumerator RestartGameCoroutine()
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Game Scene");
    }
}
