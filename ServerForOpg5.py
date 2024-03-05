import socket
import json
import random
import threading

Header = 1024
ServerPort = 4545
ServerName = socket.gethostbyname(socket.gethostname())
Address = (ServerName, ServerPort)

serversocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
serversocket.bind(Address)
serversocket.listen()
print(f"Listening on {ServerName}")

def Handle_client(conn):
    while True:
        msg = conn.recv(Header).decode("utf-8")
        if not msg:
            break
        
        try:
            json_message = json.loads(msg)
        except json.JSONDecodeError:
            print("incorrect json format received.")
            continue

        if json_message["method"] == "Random":
            conn.send(json.dumps({"prompt": "insert numbers"}).encode())

            numbers_json = conn.recv(Header).decode("utf-8")
            numbers = json.loads(numbers_json)

            if len(numbers) == 2:
                num1, num2 = map(int, numbers)
                result = random.randint(num1, num2)
                conn.send(json.dumps({"result": result}).encode())
        elif json_message["method"] in ["Add", "Subtract"]:
            conn.send(json.dumps({"prompt": "insert numbers"}).encode())

            numbers_json = conn.recv(Header).decode("utf-8")
            numbers = json.loads(numbers_json)

            if len(numbers) == 2:
                num1, num2 = map(int, numbers)
                if json_message["method"] == "Add":
                    result = num1 + num2
                else:
                    result = num1 - num2
                conn.send(json.dumps({"result": result}).encode())

    conn.close()

while True:
    conn, adr = serversocket.accept()
    print(f"connection established with {adr}")
    client_handler = threading.Thread(target=Handle_client, args=(conn,))
    client_handler.start()