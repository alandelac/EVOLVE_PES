using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ESTE CLASE ES LITERALMENTE SOLO PARA BORRAR EL EFECTO QUE HACE EL BALON CUANDO DESAPARECE JAJAJA :(

public class borrarParticula : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("borrar", 3f); // el efecto desaperece despues de 3 segundos que spawnea
    }

    // Update is called once per frame
   void borrar()
    {
        Destroy(this.gameObject); // se destruye el efecto COOL
    }
}
