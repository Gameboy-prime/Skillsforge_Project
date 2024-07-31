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
    public Slider mouseSensitivitySlider;


    
    

    [Header("Text Mesh")]
    
    [SerializeField] TextMeshProUGUI qualityText;

    
    List<string> qualityOptions= new List<string> { "VERY LOW", "LOW", "MEDIUM", "HIGH", "VERY HIGH", "ULTRA" };
    
    private int QualityIndex=4;
    private float masterVolumeMain;
    private float musicVolumeMain;
    private float soundVolumeMain;

    //Default Values

    private int defaultQualityIndex = 4;
    
    private float defaultMasterVolumeMain=0;
    private float defaultMusicVolumeMain=0;
    private float defaultSoundVolumeMain=0;
    private float defaultMouseSensitivity = 250f;


    public static float mouseSensitivity;

 



    private void Start()
    {
        
        
        LoadSettings();

        
      

    }


    //THIS IS THE FUNCTION TO DETERMINE THE SENSITITVITY OF THE MOUSE
    public void SetSensitivity(float sensitivityValue)
    {
        mouseSensitivity= sensitivityValue;
    }

    //THis is the function to set the resolution 








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

    public void ChooseQualityRight()
    {

        QualityIndex+=1;

        if(QualityIndex>= qualityOptions.Count)
        {
            QualityIndex = 0;
        }
        SetQualityLevel(QualityIndex);
    }

    public void ChooseQualityLeft()
    {
        QualityIndex-=1;
        if (QualityIndex < 0)
        {
            QualityIndex = qualityOptions.Count-1;
        }
        SetQualityLevel(QualityIndex);
    }

    public void SetQualityLevel(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
        qualityText.text= qualityOptions[quality];


    }



    //This is to save the settings that was changed
    public void SaveSettings()
    {
        
        PlayerPrefs.SetInt("qualityIndex", QualityIndex);
        PlayerPrefs.SetFloat("masterVolume", masterVolumeMain);
        PlayerPrefs.SetFloat("soundVolume", soundVolumeMain);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeMain);
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity);

        Debug.Log("The Mouse Sensitivity is " + mouseSensitivity);

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
        mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", defaultMouseSensitivity);


        masterSlider.value= masterVolumeMain;
        musicSlider.value= musicVolumeMain;
        soundSlider.value= soundVolumeMain;
        mouseSensitivitySlider.value= mouseSensitivity;


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
