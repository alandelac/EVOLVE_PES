using UnityEngine;

public class cargarJuego : MonoBehaviour
{
    public GameObject menu;
    public GameObject hud;
    public GameObject spb;
    public GameObject saves;
    public GameObject goal1;
    public GameObject goal2;
    public GameObject goal3;

    public void Restart()
    {
        // esto se activa al presionar jugar, toda la interfaz grafica del juego (vidas, marcador, etc se activan y se quita el MENU)
        menu.SetActive(false);
        hud.SetActive(true);
        spb.SetActive(true);
        saves.SetActive(true);
        goal1.SetActive(true);
        goal2.SetActive(true);
        goal3.SetActive(true);
    }
}
