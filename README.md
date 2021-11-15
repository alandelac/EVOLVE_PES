# Evolve_PES
Goalkeeper game with hand detection

# cosas a tener en cuenta
- I made this game on the version 202.3 of unity. Try this one is something fails
- for python i used python 3.9 and installed via pip opencv and mediapipe
- feel free to modify and use the project as you want, please just credit me if you use the project please
- feel free to make pull request in order to improve the project. I will look forward to them

# thanks to:
- Marcus Cazzola for teaching how to use the sockets: https://github.com/CanYouCatchMe01/CSharp-and-Python-continuous-communication
- OMES for teching me how to use media pipe for hand tracking: https://www.youtube.com/watch?v=ipHKQVtwRas

# for running the game
1- load the scene "juego1"
2- start the game playing the play button (if pressed it turns blue)
3- Run the handDetector.py script
4- wait for the socket to connect and the camera to turn on
5- You now can press the "jugar" button and start playing

# troubleshooting
- if the socket is not conencting try changing the port on the handdetector.py and in the inspector panel from the manoDer Gameobject (both ports must be the same)
- After playing for many time in one session, the detector start failing around the hour of playing. Just restart the game and continue playing.


