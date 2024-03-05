from socket import *

def user_input(command):
    num1 = input("Enter first number: ")
    num2 = input("Enter second number: ")
    return f"{command} {num1} {num2}"

def menu():
    print("\nChoose a command")
    print("1. Random")
    print("2. Add")
    print("3. Subtract")
    print("4. Exit")
    return input("Choose a number between 1 and 4): ")

serverName = "localhost"
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

while True:
    user_choice = menu()
    
    if user_choice == '4':
        print("The client is closing..")
        break  
    elif user_choice in ['1', '2', '3']:
        sentence = get_user_input(user_choice)
        clientSocket.send(sentence.encode())
        modifiedSentence = clientSocket.recv(1024)
        print('From server:', modifiedSentence.decode())
    else:
        print("Incorrect input, choose a number between 1 and 4")

clientSocket.close()
