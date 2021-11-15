using UnityEngine;

public class tiros : MonoBehaviour
{
    public GameObject efecto; // el efectito cool cuando el balon desaparece
    void Start()
    {
        Vector3 actual = this.transform.position; // se carga la posicion de donde saldra el balon

        // se agarra una coordenada destino (coordenada de la porteria en X y Y)
        System.Random r = new System.Random();
        int goalX = r.Next(-33, 33);
        int goalY = r.Next(5, 65);

        // se genera un vector con una posicion de la porteria
        Vector3 goal = new Vector3(goalX, goalY, 33);

        // se traza la direccion del origen a la porteria
        Vector3 trayectoria = (goal - actual).normalized;
        
        // se lanza la pelota agrefandoe una fuerza de impulso en la direccion de trayectoria
        // la fuerza es de 50.6f calculada a prueba y error xd
        this.GetComponent<Rigidbody>().AddForce(trayectoria*50.6f, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision) // si el balon toca algo
    {
        // si toca algo que no es la cancha desaparece y genera el efecto en el lugar donde desaparecio
        if (!collision.gameObject.name.Equals("Terreno"))
        {
            Instantiate(efecto, this.transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
        }
    }
}
    