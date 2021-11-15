using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

// ESTE CODIGO LO QUE HACE ES PONER EL MARCADOR MAS ALTO EN EL MENU
// lee el archivo de score y saca el resutado mas alto y lo pone en el MENU

public class score : MonoBehaviour
{
    // la estrucutra es como un arreglo que permite guardar diferentes valores
    // En este caso un string (nombre) y un int (marcador)
    struct datos
    {
        public string nombre;
        public int marcador;
    }

    private void Start() // al arrancar el juego se actualiza el marcador
    {
        actualizarMarcador();
    }

    // este metodo basicamente actualiza el marcador en base al score.txt cada vez que lo llamas
    public void actualizarMarcador() 
    {

        // aqui obtenemos el path y lo guardamos
        string helper = Directory.GetCurrentDirectory();
        string pathToFile = helper + "/Assets/Menu/score.txt";

        List<datos> dato = new List<datos>(); // creamos un vector con la struct

        // si existe el archivo, lo leemos y lo guardamos en el vector
        if (File.Exists(pathToFile))
        {
            // Se lee cada linea del archivo
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(','); // separamos la linea por comas
                    datos data = new datos();
                    data.nombre = words[0]; // al data le ponemos el nombre
                    data.marcador = int.Parse(words[1]); // al data le ponemos el numero
                    dato.Add(data); // agregamos el data al vector de datos
                }
            }
        }
        else
        {
            //create the file test.txt 
            File.Create(pathToFile);
            Debug.Log("File 'score' created");
        }

        // es esto se guardara el indice del nombre y el mayor valor de la lista
        int indice = -1;
        int valor = -1;

        // aqui se saca el mayor valor comparando todo el arreglo
        for (int i = 0; i < dato.Count(); i++)
        {
            if (dato[i].marcador > valor)
            {
                valor = dato[i].marcador;
                indice = i;
            }
        }

        // se actualiza el marcador en la interfaz del menu
        this.gameObject.GetComponent<Text>().text = "Highest Score:\n\n" + dato[indice].nombre + ": " + valor;
    }
}
