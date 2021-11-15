using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comOtraMano : MonoBehaviour
{
    // ESTE SCRIPT SOLO SIRVE PARA LLAMAR A LA SALVADA QUE ESTE EN EL OTRO GUANTE SI EL BALON TOCA ESTE GUANTE POR ESO SE HACE EL BUG DE LA SALVADA DOBLE
    public GameObject otraMano;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Terreno"))
        {

            otraMano.GetComponent<paradas>().save();


        }
    }
}
