using UnityEngine;

using UnityEngine.UI;

public class generarTiros : MonoBehaviour
{
    public GameObject balon; // el prefab del balon
    public GameObject SPB; // el texto que marca la velocidad

    int rep;
    public float time;

    // cuando se pica jugar se corre este metodo para empezar a lanzar los balones
    public void empezar()
    {
        rep = 4; // cada cuantos balones se debe de cambiar la velocidad
        time = 4f; // velocidad incial de lanzamiento de valones
        Invoke("spamea", 2f); // se empezaran a lanzar lso balones 2s despues de iniciado el juego
        SPB.GetComponent<Text>().text = "Sec per ball: " + time + "s"; // se pone la velocidad actual en el HUD
    }

    // Update is called once per frame
   
    void spamea()
    {
        if(time == -1)
        {
            // si el tiempo es -1 (se termina el juego) ya no se vuelve a invocar al metodo
        }
        else
        {
            Instantiate(balon, this.transform.position, Quaternion.identity); // se genera el nuevo balon

            // si se terminan las repeteciones reiniciarlas y cambiar la velocidad a mas rapido
            if (rep == 0 && time > 1f)
            {
                rep = 4; 
                time--;
                SPB.GetComponent<Text>().text = "Sec per ball: " + time + "s"; // se pone la velocidad actual en el HUD
            }
            Invoke("spamea", time); // se llama al metodo nuevamente con el tiempo actual
            rep--;
        }
        
    }

}
