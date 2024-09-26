using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamaraControl : MonoBehaviour
{
    [Header("Camaras")]
    public Cinemachine.CinemachineVirtualCamera camera1;
    public Cinemachine.CinemachineVirtualCamera camera2;
    public Cinemachine.CinemachineVirtualCamera camera3;
    [Header("Volumen")]
    public GameObject settingsVolumen;
    public AudioClip botonSound;
    private AudioSource audioSource;
    [Header("Sliders y Botones")]
    public Slider slider;
    public Slider slider2;
    public Button play;
    public Button settings;   
    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = botonSound;
    }
    void Start()
    {
        camera1.Priority = 1; 
        camera2.Priority = 0;
        camera3.Priority = 0;

        play.onClick.AddListener(BotonPlay);
        settings.onClick.AddListener(BotonSettings);
        slider.value = 1;
        settingsVolumen.SetActive(false);
        slider.onValueChanged.AddListener(VolumeMusic);
        slider2.value = 1; 
        slider2.onValueChanged.AddListener(VolumeSounds);
        audioSource.volume = slider2.value;
    }
    void VolumeMusic(float volume)
    {
        AudioListener.volume = volume;
    }
    void VolumeSounds(float volume)
    {
        audioSource.volume = volume;
    }

    void BotonPlay()
    {
        audioSource.Play();
        if (camera1.Priority > camera2.Priority)
        {
            camera1.Priority = 0;
            camera2.Priority = 1;
        }
        else
        {
            camera1.Priority = 1;
            camera2.Priority = 0;
        }
        camera3.Priority = 0;
        settingsVolumen.SetActive(false);
    }

    void BotonSettings()
    {
        audioSource.Play();
        camera1.Priority = 0; 
        camera2.Priority = 0; 
        if (camera3.Priority == 1)
        {
            camera3.Priority = 0; 
            camera1.Priority = 1; 
        }
        else
        {
            camera3.Priority = 1; 
        }
        settingsVolumen.SetActive(!settingsVolumen.activeSelf);
    }
}
