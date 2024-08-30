using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider musicSlider;
    public AudioSource audioSource;
    private float volume = 1.0f;

    private static VolumeSettings instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // No destruir al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject);  // Destruir esta instancia si ya existe otra
            return;
        }
    }

    private void Start()
    {
        // Cargar el volumen guardado
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            volume = PlayerPrefs.GetFloat("musicVolume");
            musicSlider.value = volume;
        }
        else
        {
            volume = musicSlider.value;
        }

        audioSource.volume = volume;

        // Añadir listener para el slider
        musicSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
    }

    public void OnVolumeChange()
    {
        // Actualizar el volumen en base al slider
        volume = musicSlider.value;
        audioSource.volume = volume;

        // Guardar el valor del volumen
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
}
