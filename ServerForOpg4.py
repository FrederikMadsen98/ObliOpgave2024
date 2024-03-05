from socket import *
import random

def process_command(sentence):
    parts = sentence.split(' ')
    command = parts[0]
    if command == "1":
        num1, num2 = int(parts[1]), int(parts[2])
        result = random.randint(min(num1, num2), max(num1, num2))
    elif command == "2":
        num1, num2 = int(parts[1]), int(parts[2])
        result = num1 + num2
    elif command == "3":
        num1, num2 = int(parts[1]), int(parts[2])
        result = num1 - num2
    else:
        result = "Incorrect command"
    return str(result)

serverPort = 12000
serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(('', serverPort))
serverSocket.listen(1)
print('The server is ready')

while True:
    connectionSocket, addr = serverSocket.accept()
    print(f"Connection from {addr} accepted")
    
    while True:
        sentence = connectionSocket.recv(1024).decode()
        if not sentence or sentence.lower() == "exit":
            print("Connection closed")
            break

        response = process_command(sentence)
        connectionSocket.send(response.encode())
    
    connectionSocket.close()