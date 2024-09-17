using UnityEngine;
using UnityEngine.UI;

public class Presionado : MonoBehaviour
{
    public Button vidaButton;
    public Button dañoButton;
    public Button saltoButton;
    public Button velocidadButton;
    public Button cooldownButton;

    public Color newColor = Color.green;

    private Color originalVidaColor;
    private Color originalDañoColor;
    private Color originalSaltoColor;
    private Color originalVelocidadColor;
    private Color originalCooldownColor;

    void Start()
    {

        originalVidaColor = vidaButton.image.color;
        originalDañoColor = dañoButton.image.color;
        originalSaltoColor = saltoButton.image.color;
        originalVelocidadColor = velocidadButton.image.color;
        originalCooldownColor = cooldownButton.image.color;


        vidaButton.onClick.AddListener(() => ChangeColor(vidaButton, originalVidaColor));
        dañoButton.onClick.AddListener(() => ChangeColor(dañoButton, originalDañoColor));
        saltoButton.onClick.AddListener(() => ChangeColor(saltoButton, originalSaltoColor));
        velocidadButton.onClick.AddListener(() => ChangeColor(velocidadButton, originalVelocidadColor));
        cooldownButton.onClick.AddListener(() => ChangeColor(cooldownButton, originalCooldownColor));
    }

    void ChangeColor(Button button, Color originalColor)
    {
        // Si el botón tiene el color original, lo cambia al nuevo color, de lo contrario lo restaura
        if (button.image.color == originalColor)
        {
            button.image.color = newColor;
        }
        else
        {
            button.image.color = originalColor;
        }
    }
}