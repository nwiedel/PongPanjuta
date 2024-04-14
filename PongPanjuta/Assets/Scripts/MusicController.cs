using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource music;
    public Text musicVolumeText;
    public Toggle musicMuteToggle;
    public Slider musicSlider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("isMusicMuted"))
        {
            if (PlayerPrefs.GetString("isMusicMuted") == "true")
            {
                if (musicMuteToggle != null)
                {
                    musicMuteToggle.isOn = false;
                }
            }
        }

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            music.volume = PlayerPrefs.GetFloat("musicVolume") / 100f;

            if (musicSlider != null)
            {
                musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            }

            if (musicVolumeText != null)
            {
                musicVolumeText.text = PlayerPrefs.GetFloat("musicVolume").ToString();
            }
        }
    }

    public void ChangeVolume(float f)
    {
        PlayerPrefs.SetFloat("musicVolume", f);
        music.volume = f / 100f;
        musicVolumeText.text = f.ToString();
    }

    public void ToggleMute()
    {
        if (musicMuteToggle.isOn)
        {
            music.mute = false;
            PlayerPrefs.SetString("isMusicMuted", "false");
        }
        else
        {
            music.mute = true;
            PlayerPrefs.SetString("isMusicMuted", "true");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
