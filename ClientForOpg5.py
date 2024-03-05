import socket
import json

Header = 1024
ServerPort = 4545
ServerName = socket.gethostbyname(socket.gethostname())
Address = (ServerName, ServerPort)

Clientsocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
Clientsocket.connect(Address)

def send_cmd(cmd):
    json_object = json.dumps(cmd)
    Clientsocket.sendall(json_object.encode())
    servers_rsp = Clientsocket.recv(Header).decode('utf-8')
    if not servers_rsp:
        return {}
    decoded_rsp = json.loads(servers_rsp)
    return decoded_rsp

while True:
    user_input = input("enter either Random, Add or Subtract in json format: ")
    try:
        json_object = json.loads(user_input) 
    except json.JSONDecodeError:
        print("incorrect json format. Try again.")
        continue
    
    rsp = send_cmd(json_object)
    print(rsp)  

    if rsp.get("prompt") == "Insert numbers":
    
        print("enter two numbers in json format:")
        numbers_input = input()
        try:
            numbers = json.loads(numbers_input) 
            if isinstance(numbers, list) and len(numbers) == 2:
                
                rsp = send_cmd(numbers)
                print(rsp)  
            else:
                print("incorrect input. Please enter a list containing two numbers.")
        except json.JSONDecodeError:
            print("incorrect json format. Please try again.")