# Grocery Store AI

Grocery Store AI is an Artificial Intelligence based game made with Unity developed for a university project in CITM UPC (Terrasa, Spain) in our degree in Videogame Developement and Design.

## Information

Grocery Store AI has 4 entities; cashier, client, cleaner and dependent that complete their function in a usual grocery store by our own programmed Steering Behaviours and with their own Behaviour Trees to move across, in and out of the store with its corresponding day/night cycle.

## Innovation Website

Go to our website for full information and visuals: https://manavld.github.io/GroceryStoreAI/

### Cashier

Spawn, Paths to his cash and waits till his turn is finished. Then goes home around 10 o'clock at night.

### Client

Spawns when the shop is open, goes to inside the shop, picks an area to pick an object, then wait his turn in the queue to buy the thing he picked, when a spot is clear, he goes in and buys. He stays there a bit with the cashier, waiting his change. After he got the change, he goes home.

### Cleaner

At 12::00 at night he comes to clean the shop, after he cleaned all the shop he goes home.

### Dependent

Goes to the store when his shift starts, waits and observes clients if they need help, helps the clients when they do, goes home when shift ends. For dependent movements, when a client needs your help to decide wich product will buy, you have to click the dependent, and then click the client. Afterwards the dependent will talk with the client and help him decide, so he goes home happy.

## Controls

* WASD: Camera Movement
* R: Return camera to initial position
* With the mouse you can tell the dependent to help a client.
* Car Botton: Click and put the car around the outside of the store to spawn car
* Cashier Botton: Click to automatically create a cashier machine inside the store (maximum of 3 active)
* Pause Botton: Click to pause game
* Lvl up cashier so they sell faster.
* Marketing Campaign button: Does a marketing campeign to increase a star.

## Win/Loss Condition

* **Win**: The player will win if he/she successfuly completed 3 days without upseting more than 4 clients by leaving them unattending when they ask for help.
* **Loss**: The player will lose if the store review has 0 stars.

## Authors

* Gerard Gil: https://github.com/Gerard346
* Manav Lakhwani: https://github.com/manavld

## Instructions

Download the .zip in the last release in https://github.com/Gerard346/Project-AI/releases and open the file .exe to play the game.

## Github Repository

https://github.com/Gerard346/Project-AI

## Link to the Wiki

You will find information about the game and the Behaviour Trees in the wiki: https://github.com/Gerard346/Project-AI/wiki

## Behaviour Trees

* **Client**: The client will decide to go to the store if open, go to the object he need and pick it up or ask for help, when picked the client will go to the queue, buy his items, and go home when bought.

![Client BT](https://github.com/manavld/AIProjectPics/blob/master/Client%20BT2.jpg)

* **Cashier**: The cashier will go to work when the store is open, start working when its his turn, attend the clients when client is buying and go home when his turn ended.

![Cashier BT](https://github.com/manavld/AIProjectPics/blob/master/Cashier%20BT.jpg)

* **Cleaner**: The cleaner will walk to work when its his turn to work, grab the mob and start working until his time is done, leaves the mob back and goes back home.

![Cleaner BT](https://github.com/manavld/AIProjectPics/blob/master/Cleaner%20BT.jpg)

* **Dependent**: The dependent will go to work when his shift starts, will observe the clients in case they need help, when client is in need of help the dependent will go there and help the client and when his shift ends he will leave the shop and go home.

![Dependent BT](https://github.com/manavld/AIProjectPics/blob/master/Dependent%20BT.jpg)

## License

We use the MIT License this is a permissive free software license originating at the Massachusetts Institute of Technology.

MIT License

Copyright (c) 2019 Gerard Gil & Manav Lakhwani

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
