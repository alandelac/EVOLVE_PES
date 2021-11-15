import cv2
import mediapipe as mp
import time

# ESTE CODIGO NO SE USA EN EL PROYECTO ASI QUE NO LO COMENTARE :D

#posicion inicial de las manos
startPos = [0, 0, 0, "N"] #Vector3   x = 0, y = 0, z = 0

cap = cv2.VideoCapture(0)
print("1")
mpHands = mp.solutions.hands
hands = mpHands.Hands(static_image_mode=False,
                      max_num_hands=2,
                      min_detection_confidence=0.5,
                      min_tracking_confidence=0.5)
mpDraw = mp.solutions.drawing_utils
print("2")
while True:
    success, img = cap.read()
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    results = hands.process(imgRGB)

    
    if results.multi_hand_landmarks and results.multi_handedness:
        
        for idx, hand_handedness in enumerate(results.multi_handedness): #ciclo depende de cantidad de manos
            print(idx)
            if(hand_handedness.classification[0].label =="Right"):
                startPos[3] = "R"
            else:
                startPos[3] = "L"

            handLms = results.multi_hand_landmarks[idx]
            lista = list(enumerate(handLms.landmark))

            id = lista[8][0]
            lm = lista[8][1]
            
            cx, cy = int(34.4+lm.x *(-68.8)), int(15.2+lm.y*(-32.6))
            startPos[0]= cx
            startPos[1] = cy

            mpDraw.draw_landmarks(img, handLms, mpHands.HAND_CONNECTIONS)    # esto es para unir los puntos
            posString = ','.join(map(str, startPos)) #Converting Vector3 to a string, example "0,0,0"
            print(posString)


    cv2.imshow("Test", img)
    cv2.waitKey(1)


