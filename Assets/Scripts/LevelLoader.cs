using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float timeTransition;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }

    }

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

}
