# Evolve_PES
Goalkeeper game with hand detection

# cosas a tener en cuenta
- I made this game on the version 202.3 of unity. Try this one is something fails
- for python i used python 3.9 and installed via pip opencv and mediapipe
- this git has only the assets, all the content of the assets folder put in into your corresponding asset folder on yor project

# for running the game
1- load the scene "juego1"
2- start the game playing the play button (if pressed it turns blue)
3- Run the handDetector.py script
4- wait for the socket to connect and the camera to turn on
5- You now can press the "jugar" button and start playing

# troubleshooting
- if the socket is not conencting try changing the port on the handdetector.py and in the inspector panel from the manoDer Gameobject (both ports must be the same)
- After playing for many time in one session, the detector start failing around the hour of playing. Just restart the game and continue playing.


