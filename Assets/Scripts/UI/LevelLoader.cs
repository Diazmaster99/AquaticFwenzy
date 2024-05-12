using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float timeTransition;

    public Slider sliderMaster;
    public Slider sliderMusica;
    public Slider sliderSFX;



    private void Start()
    {
        if (PlayerPrefs.HasKey("Master") || PlayerPrefs.HasKey("Musica") || PlayerPrefs.HasKey("SFX"))
        {
            sliderMaster.value = PlayerPrefs.GetFloat("Master");
            sliderMusica.value = PlayerPrefs.GetFloat("Musica");
            sliderSFX.value = PlayerPrefs.GetFloat("SFX");
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
