using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// EL CODIGO GUARADA Y ACTUALIZA EL TEXTO DE LAS SALVADAS
public class paradas : MonoBehaviour
{
    public GameObject saves; // este es el texto que se va a actualizar
   
    public int salvadas = 0; // contador de salvadas

    // Cuando se empieza nuevamente el juego se reinciia el texto con 0 salvadas
    public void reiniciarContador()
    {
        saves.GetComponent<Text>().text = "Saves: " + salvadas;
    }
   
    // al salvar se agrega al contador y se actualiza el texto
    public void save()
    {
        salvadas++;
        saves.GetComponent<Text>().text = "Saves: " + salvadas;
    }

    // si el balon toca el guante se cuenta como salvada
    // OJO aqui un bug que no he arreglado, si salvas el balon con ambos guantes al mismo tiempo se cuenta la salvada como x2
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Terreno"))
        {
            save();
        }
    }

}



