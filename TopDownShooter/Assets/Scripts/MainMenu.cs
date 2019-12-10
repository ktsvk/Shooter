using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown resolutionDropdown;
    [SerializeField]
    private Transform[] spawns;
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Player player;
    [SerializeField]
    private AudioMixer audioMixer;

    Resolution[] resolutions;
    void Start()
    {
        Time.timeScale = 0.5f;
        var _player = Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
        _player.OnMainMenu = true;
        for (int i = 0; i < spawns.Length; i++)
        {
            var _enemy = Instantiate(enemy, spawns[i].transform.position, Quaternion.identity);
            _enemy.GetComponentInChildren<Canvas>().enabled = false;
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
    }
    public void OnStartPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnOptions()
    {
        
    }
    public void OnExit()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; 
    }
}
