using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

// ESTE SCRIPT RECIBE LOS DATOS DEL ARCHIVO DE PYTHON DE LA DETECCION DE MANOS
public class recibirDatos : MonoBehaviour
{
    // cosas para conectarse con python y la red local
    Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001; // este numero no importa porque lo actualizo desde el inspector
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;

    public GameObject manoIzq; // para mover la mano izquierda

    // posiciones iniciales de las manos
    Vector3 posDer = new Vector3(11.6f, 19.6f, 37.6f);
    Vector3 posIzq = new Vector3(-11.6f, 19.6f, 37.6f);

    bool running; 

    // metodo que actualiza una poscion con respecto a lo que se manda
    private void Update()
    {
        // cada update se mueven las manos con lo ultimo que recibio el socket
        transform.position = posDer; 
        manoIzq.GetComponent<Transform>().position = posIzq;
    }


    private void Start()
    {
        // se incializa el socket
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }

    // este metodo obtiene la inforamcion recibida del socket
    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        while (running) // aqui podria hacerse algo para salir del loop al terminar el juego para desconectarse correctamente del socket. No lo he hecho
        {
            SendAndReceiveData();
        }
        listener.Stop();
    }

    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //--se recibe un dato y lo adaptamos a un string----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); 
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); 

        if (dataReceived != null)
        {
            // si el dato tiene L es para la mano izquierda (L y R por alguna razon estan volteados, o sea L en verdad es R y viceversa)
            if (dataReceived.Contains("L"))
            {
                posDer = StringToVector3(dataReceived); //<-- assigning posDer value from Python
            }
            else
            {
               posIzq = StringToVector3(dataReceived); //<-- assigning posDer value from Python 
            }

            
        }
        else // este else creo que nunca se usara pero ahi dejenlo si quieren
        {
            posDer = new Vector3(11.6f, 19.6f, 37.6f);
            posIzq = new Vector3(-11.6f, 19.6f, 37.6f);
        }
    }

    // convertir el string en vector
    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(float.Parse(sArray[0]), float.Parse(sArray[1]), 37.6f);

        return result;
    }
    
}
