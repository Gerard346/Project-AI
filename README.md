﻿# Grocery Store AI

Grocery Store AI is an Artificial Intelligence based game made with Unity developed for a university project in CITM UPC (Terrasa, Spain) in our degree in Videogame Developement and Design.

## Information

Grocery Store AI has 3 entities; cashier, client and cleaner that complete their function in a usual grocery store by our own programmed Steering Behaviours and with their own Behaviour Trees to move across, in and out of the store with its corresponding day/night cycle.

### Cashier

Spawn, Paths to his cash and waits till his turn is finished. Then goes home around 10 o'clock at night.

### Client

Spawns when the shop is open, goes to inside the shop, picks an area to pick an object, then wait his turn in the queue to buy the thing he picked, when a spot is clear, he goes in and buys. He stays there a bit with the cashier, waiting his change. After he got the change, he goes home.

### Cleaner

At 12::00 at night he comes to clean the shop, after he cleaned all the shop he goes home.

## Controls

* WASD: Camera Movement
* R: Return camera to initial position
* 2 & Right Click: Will create a parking with cars on the outside of the store increasing the client limit.

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

![Client BT](https://github.com/manavld/AIProjectPics/blob/master/Client%20BT.jpg)

* **Cashier**: The cashier will go to work when the store is open, start working when its his turn, attend the clients when client is buying and go home when his turn ended.

* **Cleaner**: The cleaner will walk to work when its his turn to work, grab the mob and start working until his time is done, leaves the mob back and goes back home.

## License

We use the MIT License this is a permissive free software license originating at the Massachusetts Institute of Technology.

MIT License

Copyright (c) 2019 Gerard Gil & Manav Lakhwani

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
