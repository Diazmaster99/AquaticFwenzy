using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    //private bool fullscreen = false;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    List<Resolution> filteredResolutionList;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    public Toggle fullScreenToggle;

    [SerializeField]
    AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        //resolutions = Screen.resolutions;
        //resolutionDropdown.ClearOptions();

        //List<string> options = new List<string>();

        //for (int i = 0; i < resolutions.Length; i++)
        //{
        //    string option = resolutions[i] + " x " + " height";
        //    options.Add(option);
        //}

        //resolutionDropdown.AddOptions(options);

        resolutions = Screen.resolutions;
        filteredResolutionList = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutionList.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filteredResolutionList.Count; i++)
        {
            string resolutionOption = filteredResolutionList[i].width + "x" + filteredResolutionList[i].height + " " + filteredResolutionList[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if (filteredResolutionList[i].width == Screen.width && filteredResolutionList[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }


        resolutionDropdown.AddOptions(options);

        //for (int i = 0; i < options.Count; i++)
        //{
        //    resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(options[i]));
        //}

        resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.itemText.text = currentResolutionIndex.ToString();
        resolutionDropdown.RefreshShownValue();

    }

    public void FullScreen(bool fullscreen) {

        Debug.Log("Fullscreen es: "+fullscreen);
        Screen.fullScreen = fullscreen;

    }

    public void ChangeResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,true);

        fullScreenToggle.isOn = true;

        Debug.Log("resolution es: " + filteredResolutionList[resolutionIndex]);
        //int numero = 1;
        //switch (resolutionIndex)
        //{
        //    case 0:
        //        Screen.SetResolution(1920, 1080, true);
        //        break;
        //    case 1:
        //        Screen.SetResolution(1420, 960, true);
        //        break;
        //    case 2:
        //        //Screen.SetResolution(800, 600, false);
        //        break;
        //    default:
        //        break;
        //}
        
    }

    public void changeVolumenMaster(float slidervalue)
    {
        Debug.Log("Valor es: "+slidervalue);
        audioMixer.SetFloat("Master",Mathf.Log10(slidervalue)*20); 
    }

    public void changeVolumenMusica(float slidervalue)
    {
        audioMixer.SetFloat("Musica", Mathf.Log10(slidervalue) * 20);
    }

    public void changeVolumenFX(float slidervalue)
    {
        audioMixer.SetFloat("FX", Mathf.Log10(slidervalue) * 20);
    }

}
