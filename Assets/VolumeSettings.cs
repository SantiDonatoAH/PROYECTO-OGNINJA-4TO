using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{

    public  Slider musicSlider;

    public float volume = 0;
    public AudioSource AudioSource;

    private void Start()
    {
        
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    private void Update()
    {
        volume = musicSlider.value;
        AudioSource.volume = volume;
    }
    public void SetMusicVolume(){
       

      
    }

    private void LoadVolume(){
        AudioSource.volume=volume;

        SetMusicVolume();
    }

}
