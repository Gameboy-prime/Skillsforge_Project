using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System;
using UnityEngine.UI;
//using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio Parameter")]
    public AudioMixer audioMixer;

    public Image masterAudioImage;
    public Image soundAudioImage;
    public Image musicAudioImage;


    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;


    public Slider masterSlider;
    public Slider soundSlider;
    public Slider musicSlider;
    
    List<string> qualityOptions= new List<string> { "VERY LOW", "LOW", "MEDIUM", "HIGH", "VERY HIGH", "ULTRA" };
    
    private int QualityIndex=2;
    private float masterVolumeMain;
    private float musicVolumeMain;
    private float soundVolumeMain;

    //Default Values

    private int defaultQualityIndex = 4;
    
    private float defaultMasterVolumeMain=0;
    private float defaultMusicVolumeMain=0;
    private float defaultSoundVolumeMain=0;
    
 



    private void Start()
    {
        
        
        LoadSettings();
        Debug.Log("The number of quality level is" + QualitySettings.count);

        
      

    }



    //This is the function to set the volume level


    //This is for the master volume Group
    public void SetMasterVolume(float volume)
    {
        masterVolumeMain= volume;
        audioMixer.SetFloat("masterVolume", volume);
        if(volume== -80)
        {
            masterAudioImage.sprite = soundOff;
        }
        else
        {
            masterAudioImage.sprite = soundOn;
        }

    }

    //this is for the music volume group
    public void SetMusicVolume(float musicVolume)
    {
        musicVolumeMain= musicVolume;
        audioMixer.SetFloat("musicVolume", musicVolume);
        if (musicVolume == -80)
        {
            musicAudioImage.sprite = soundOff;
        }
        else
        {
            musicAudioImage.sprite = soundOn;
        }


    }


    //THis is for the sound volume group
    public void SetSoundVolume(float soundVolume)
    {
        soundVolumeMain= soundVolume;
        audioMixer.SetFloat("soundVolume", soundVolume);
        if (soundVolume == -80)
        {
            soundAudioImage.sprite = soundOff;
        }
        else
        {
            soundAudioImage.sprite = soundOn;
        }


    }


    //This is the function to set the quality level

    public void ChooseLowQuality()
    {

        QualityIndex=0;

        
        SetQualityLevel(QualityIndex);
        Debug.Log("The Current Quality of the graphics is " + QualitySettings.GetQualityLevel());
       
    }

    public void ChooseMediumQuality()
    {
        QualityIndex=1;
        
        SetQualityLevel(QualityIndex);
        Debug.Log("The Current Quality of the graphics is " + QualitySettings.GetQualityLevel());

    }

    public void ChooseHighQuality()
    {
        QualityIndex = 2;

        SetQualityLevel(QualityIndex);
        Debug.Log("The Current Quality of the graphics is " + QualitySettings.GetQualityLevel());

    }

    public void SetQualityLevel(int quality)
    {
        QualitySettings.SetQualityLevel(quality);

    }



    //This is to save the settings that was changed
    public void SaveSettings()
    {
        
        PlayerPrefs.SetInt("qualityIndex", QualityIndex);
        PlayerPrefs.SetFloat("masterVolume", masterVolumeMain);
        PlayerPrefs.SetFloat("soundVolume", soundVolumeMain);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeMain);
       
    }

    private void GetLoadSettings()
    {
        /*currentResolutionIndex=PlayerPrefs.GetInt("resolutionIndex");
        QualityIndex=PlayerPrefs.GetInt("qualityIndex");
        masterVolumeMain=PlayerPrefs.GetFloat("masterVolume");
        soundVolumeMain=PlayerPrefs.GetFloat("soundVolume");
        musicVolumeMain = PlayerPrefs.GetFloat("musicVolume");
        mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity");*/

        
        QualityIndex = PlayerPrefs.GetInt("qualityIndex", defaultQualityIndex);
        masterVolumeMain = PlayerPrefs.GetFloat("masterVolume", defaultMasterVolumeMain);
        soundVolumeMain = PlayerPrefs.GetFloat("soundVolume", defaultSoundVolumeMain);
        musicVolumeMain = PlayerPrefs.GetFloat("musicVolume", defaultMusicVolumeMain);
    
        masterSlider.value= masterVolumeMain;
        musicSlider.value= musicVolumeMain;
        soundSlider.value= soundVolumeMain;


        audioMixer.SetFloat("masterVolume", masterVolumeMain);
        audioMixer.SetFloat("musicVolume", musicVolumeMain);
        audioMixer.SetFloat("soundVolume", soundVolumeMain);

        Debug.Log($" THe master is {masterVolumeMain} The MUsic is {musicVolumeMain} the Sound is {soundVolumeMain}");



    }

  

    private void LoadSettings()
    {
        GetLoadSettings();

        //Checking to see if the settings have a saved value else the default values is set

        //QUALITY LEVELS
        SetQualityLevel(QualityIndex);

        //MASTER VOLUME
        SetMasterVolume(masterVolumeMain);

        //SOUND VOLUME
        SetSoundVolume(soundVolumeMain);

        //MUSIC
        SetMusicVolume(musicVolumeMain);



    }



   

    //This is the function to set the full screen
    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }


    //This is the function to mute the audio



    
}
