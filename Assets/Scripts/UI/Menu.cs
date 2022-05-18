using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isOpened = false;
    public float volume = 0;
    public int quality = 0;
    public bool isFullScreen = false;
    public Dropdown resolutionDropdown;
    public AudioMixer audioMixer;

    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;

    public void ShowOurMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;
    }

    public void ChangeVolume(float amout)
    {
        volume = amout;
    }

    public void ChangeResolution(int index)
    {
        currentResolutionIndex = index;
    }

    public void ChangeQuality(int index)
    {
        quality = index;
    }

    public void ChangeFullScrMode(bool val)
    {
        isFullScreen = val;
    }

    public void SaveChanges()
    {
        audioMixer.SetFloat("MasterVolume", volume);
        QualitySettings.SetQualityLevel(quality);
        Screen.fullScreen = isFullScreen;
        Screen.SetResolution(Screen.resolutions[currentResolutionIndex].width,
            Screen.resolutions[currentResolutionIndex].height, isFullScreen);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game End");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowOurMenu();
        }
    }

    private void Start()
    {
        FillResolutions();
    }

    private void FillResolutions()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution))
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}