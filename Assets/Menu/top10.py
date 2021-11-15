def partition(arr, low, high):
    i = (low-1)         # index of smaller element
    pivot = arr[high]     # pivot
  
    for j in range(low, high):
  
        # If current element is smaller than or
        # equal to pivot
        if arr[j] <= pivot:
  
            # increment index of smaller element
            i = i+1
            arr[i], arr[j] = arr[j], arr[i]
  
    arr[i+1], arr[high] = arr[high], arr[i+1]
    return (i+1)
  
# esto es un quicksort que soortea un arreglo. Empieza en low (inclusivo y termino en high)
def quickSort(arr, low, high):
    if len(arr) == 1:
        return arr
    if low < high:
  
        # pi is partitioning index, arr[p] is now
        # at right place
        pi = partition(arr, low, high)
  
        # Separately sort elements before
        # partition and after partition
        quickSort(arr, low, pi-1)
        quickSort(arr, pi+1, high)

lines = [] # esto pone cada linea en un dato del arreglo

file = open("score.txt") # abrimos el archivo con el score
lines = file.readlines() # se guardan las lineas del arreglo

ordered = [] # aqui se guardaran los marcadores ordenados
score = [] # se guardan los datos del marcador sin ordenar
score2 = [] # este es una copia del score pero este no se va a modificar
nombre = [] # este va de la mano con score2, los indices son los mismos

# aqui se empieza a guardar la informacion en cada uno de los arreglos
for line in lines:
    words = line.split(',')
    nombre.append(words[0])
    ordered.append(int(words[1]))
    score.append(int(words[1]))
    score2.append(int(words[1]))

# ordenamos el arreglo de ordered
quickSort(ordered, 0 , len(score)-1)

index = [] # este nos servira para sacar los indices del arreglo de nombres

# se añaden los indices del top
for i in range(len(ordered)-1, len(ordered)-144,-1):
    ind = score.index(ordered[i]) # se busca el indice en el arreglo de score de el top de marcadores sacado en ordered
    index.append(ind) # el indice se agrega el arreglo de indices
    score[ind] = -1 # ponemos menos 1 para no repetir este indice en caso de que haya marcadores repetidos.
    
# se imprime el nombre y score de todos los participantes de mayor a menor
for i in index:
    print(nombre[i], end=' ')
    print(score2[i])

# importante cerrar tus archivos siempre :D
file.close()

