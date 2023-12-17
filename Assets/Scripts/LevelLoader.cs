using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float timeTransition;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(timeTransition);
        SceneManager.LoadScene(LevelIndex);
    }

    //IEnumerator LoadWin(int LevelIndex)
    //{
    //    transition.SetTrigger("Win");
    //    yield return new WaitForSeconds(timeTransition);
    //    SceneManager.LoadScene(LevelIndex);
    //}

    //IEnumerator LoadGameOver(int LevelIndex)
    //{
    //    transition.SetTrigger("Game Over");
    //    yield return new WaitForSeconds(timeTransition);
    //    SceneManager.LoadScene(LevelIndex);
    //}

}
