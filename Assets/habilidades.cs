using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class habilidades : MonoBehaviour
{


    public static Text habilidadesDropdown1;
    public static Text habilidadesDropdown2;
    public static habilidades instance;
    // Start is called before the first frame update
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
            return;  // Salir del Awake para evitar ejecutar el código en la instancia destruida
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
