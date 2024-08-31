using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider musicSlider;
    public Slider Slider;

    private void Start()
    {
        Slider = musicSlider.GetComponent<Slider>();
    }

    private void Update()
    {
        audio.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {

       musicSlider.value = audio.volume;
    }
}
