# How 2 Use

## Setting up environment

Download the project

![image](https://user-images.githubusercontent.com/36308052/66402944-1eb7db80-e9bc-11e9-854d-f81589a02a71.png)

Unzip the files into any directory - I unzipped into Desktop for this tutorial

![image](https://user-images.githubusercontent.com/36308052/66403276-aef62080-e9bc-11e9-9594-ad537b24638b.png)

## Server

Open the Server dotnet project into vs code or visual studio

![image](https://user-images.githubusercontent.com/36308052/66409538-216bfe00-e9c7-11e9-9bf8-27bee6f2034b.png)

Run the project to run local server (127.0.0.1)

![image](https://user-images.githubusercontent.com/36308052/66410506-92f87c00-e9c8-11e9-96be-d92acff658e0.png)

You can run into a server instead, but for sake of simplicity we will run it locally

## Client

Open the project in Unity

![image](https://user-images.githubusercontent.com/36308052/66410043-d43c5c00-e9c7-11e9-9067-14e7c3ac5c70.png)

![image](https://user-images.githubusercontent.com/36308052/66410086-e918ef80-e9c7-11e9-929f-98994c7971bf.png)

Wait until the Unity open the project, it may take a while

Open the scene "Chat" inside the Assets/Scenes folder

![image](https://user-images.githubusercontent.com/36308052/66410270-38f7b680-e9c8-11e9-97c3-1c43dc161c77.png)

Set up the Game Resolution to 800x600 by clicking the Game tab and selecting it in the top left of the tab

![image](https://user-images.githubusercontent.com/36308052/66410389-6b091880-e9c8-11e9-84d2-29bb682884a6.png)

With the server openned, run the project

![image](https://user-images.githubusercontent.com/36308052/66410704-f2568c00-e9c8-11e9-9bd4-e3daba6ea1b1.png)

If everything is running, you will receive a message in the chat ("[SERVER] CONECTADO.")

Server side the message is multicasted to everyone but you

![image](https://user-images.githubusercontent.com/36308052/66410967-5ed18b00-e9c9-11e9-9735-4a1cb60a6249.png)
