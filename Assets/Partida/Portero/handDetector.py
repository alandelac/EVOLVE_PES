# estas dos librerias son para la deteccion de manos
import cv2
import mediapipe as mp

# esta es para la comunicacion por la red local
import socket

#cosas para conectarse a la red local
host, port = "127.0.0.1", 24999
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))
print("socket connected")

#posicion inicial de las manos
startPos = [11.6, 19.2, 37.6, "N"]

cap = cv2.VideoCapture(0) # se enciende la camara, es 0 porque la webcam integrada por default siempre es la camara 0, probar 1 o 2 si usas otras camaras

# parametros para le deteccion de manos
mpHands = mp.solutions.hands
hands = mpHands.Hands(static_image_mode=False,
                      max_num_hands=2,
                      min_detection_confidence=0.5,
                      min_tracking_confidence=0.5)
mpDraw = mp.solutions.drawing_utils

# loop infinito para la deteccion de manos en el video
while True:
    success, img = cap.read() # captura un frame del video
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    results = hands.process(imgRGB) # procesa la imagen y analiza si hay manos

    # si hubo manos corre esto
    if results.multi_hand_landmarks and results.multi_handedness:
        #por cada mano detectada haz lo siguiente
        for idx, hand_handedness in enumerate(results.multi_handedness):
            
            # si la clasificacion del resultado es derecho asignale R si no asignale L arreglo
            if(hand_handedness.classification[0].label =="Right"):
                startPos[3] = "R"
            else:
                startPos[3] = "L"

            # saca las coordenadas de cada punto de la mano
            handLms = results.multi_hand_landmarks[idx]
            lista = list(enumerate(handLms.landmark)) # guarda estas coordenadas en una lista 

            # nos interesa la marca 8 de la mano (la mas centrica), lm es la coordenada como tal en un numero del 0 al 1
            lm = lista[8][1]
            
            cx, cy = int(34.4+lm.x *(-68.8)), int(36+lm.y*(-32)) # se multiplica las coordenadas por el rango de movimiento dentro del juego
            # se añaden al vector
            startPos[0]= cx
            startPos[1] = cy

            mpDraw.draw_landmarks(img, handLms, mpHands.HAND_CONNECTIONS)    # esto es para unir los puntos dentro de la imagen de la camara
            posString = ','.join(map(str, startPos)) # Converting el arreglo a un string separado por comas
            # print(posString)
                
            sock.sendall(posString.encode("UTF-8")) #se convierte el string a bytes y se manda al archivo de C# 
          
    
    cv2.imshow("Test", img) # se imprime la imagen (es decir lo que ves en la camara)
    cv2.waitKey(1) # esto no se que sea y no se si afecte el codigo


