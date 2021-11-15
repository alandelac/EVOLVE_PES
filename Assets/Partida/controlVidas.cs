using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using System.IO;


// ESTE SCRIPT MANEJA BASICAMENTE EL JUEGO, LO CARGA Y LO REINICIA CADA VEZ
public class controlVidas : MonoBehaviour
{
    // se cargan todos los elementos dentro del juego
    public GameObject vida3;
    public GameObject vida2;
    public GameObject vida1;
    public GameObject generarTiros;
    public GameObject SPB;
    public GameObject saves;
    public GameObject nombre;
    public GameObject menu;
    public GameObject scoreboard;
    int vidas = 3; // las vidas osi osi osi

    void reiniciarJuego() 
    {
        // se reinicia el juego al guardar un nombre
        generarTiros.SetActive(true);
        saves.SetActive(true);
        saves.GetComponent<paradas>().salvadas = 0;
        saves.GetComponent<paradas>().reiniciarContador();
        nombre.SetActive(false);
        menu.SetActive(true);
        scoreboard.GetComponent<score>().actualizarMarcador();
        vidas = 3;
    }

    // el gol resta una tu vida y elimina un balon. Si pierdes todo acomoda l ainterfaz para poner el nombre
    public void gol()
    {
        if (vidas == 3)
        {
            vida1.SetActive(false);
            vidas--;
        }
        else if (vidas == 2)
        {
            vida2.SetActive(false);
            vidas--;
        }
        else
        {
            // si pierdes todas las vidas se para el juego y pide ingresar tu nombre
            vida3.SetActive(false);
            generarTiros.GetComponent<generarTiros>().time = -1;
            generarTiros.SetActive(false);
            SPB.SetActive(false);
            nombre.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Terreno"))
        {
            gol(); // si el balon toca la porteria se hace un gol
        }
    }

    // aqui se lee el archivo, se escribe de nuevo y se agrega el nuevo registro al final
    public void registrarNombre(string name)
    {
        string helper = Directory.GetCurrentDirectory();
        string pathToFile = helper + "/Assets/Menu/score.txt"; // la direccion del archivo


        List<string> dato = new List<string>(); // los datos del archivo se guardaran aqui

        if (File.Exists(pathToFile))
        {
            // Se recorre cada linea
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {  
                    dato.Add(line); // se agrega la linea al vector
                }
            }
        }
        else
        {
            //create the file test.txt 
            File.Create(pathToFile);
            Console.WriteLine("File 'test' created");

        }

        // crea el string para la nueva entrada
        name = name+",";
        name = name+saves.GetComponent<paradas>().salvadas;

        try
        {
            // escribimos el archivo ya con la nueva entrada
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(pathToFile))
            {
                for (int i = 0; i < dato.Count(); i++)
                {
                    file.WriteLine(dato[i]);
                }
                file.WriteLine(name); // aqui va la nueva entrada
            }
            // Debug.Log("Las lineas se escribieron con exito");
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
        reiniciarJuego(); // ya que se guarda el nombre se vuelve a cargar el menu y se reinicia las vidas y todo ese rollo
    }
   
}



