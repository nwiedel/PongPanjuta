using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;
    public Text soundVolumeText;
    public Toggle soundMuteToggle;
    public Slider soundSlider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("isSoundMuted"))
        {
            if(PlayerPrefs.GetString("isSoundMuted") == "true")
            {
                if(soundMuteToggle != null)
                {
                    soundMuteToggle.isOn = false;
                }
            }
        }

        if (PlayerPrefs.HasKey("soundVolume"))
        {
            wallSound.volume = PlayerPrefs.GetFloat("soundVolume") / 100f;
            racketSound.volume = PlayerPrefs.GetFloat("racketVolume") / 100f;

            if(soundSlider != null)
            {
                soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
            }

            if(soundVolumeText != null)
            {
                soundVolumeText.text = PlayerPrefs.GetFloat("soundVolume").ToString();
            }
        }
    }

    public void ChangeVolume(float f)
    {
        PlayerPrefs.SetFloat("soundVolume", f);
        wallSound.volume = f / 100f;
        racketSound.volume = f / 100f;
        soundVolumeText.text = f.ToString();
    }

    public void ToggleMute()
    {
        if (soundMuteToggle.isOn)
        {
            wallSound.mute = false;
            racketSound.mute = false;
            PlayerPrefs.SetString("isSoundMuted", "false");
        }
        else
        {
            wallSound.mute = true;
            racketSound.mute = true;
            PlayerPrefs.SetString("isSoundMuted", "true");
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
