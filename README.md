# "Kanji Mixer" the game

"Kanji Mixer" is an educational game created for an engineering thesis. The main aim is to improve the process of learning kanji. The game engine used in this project is Unity.

## Game manual

The objective is to help non-playable characters by giving them previously crafted items. The best level to explain the mechanics on is the tutorial, since there is only one NPC requiring help. First – the movement. Player can walk left and right by pressing “A” or “D” respectively (or use arrow keys, which was added after the testing phase). The other input device needed is a computer mouse, which allows for interactions with the game’s world. After starting the level, the player has to move around and look for two kinds of objects – collectable kanji items and non-playable characters. Depending on which type, different actions happen when being in the close radius of theirs. If it’s a collectible – a kanji sign pops up next to the object (usually above it). Alternatively, on the approach a non-playable character starts to talk, giving hints what they need. To continue the text, press “OK” in the dialog box.

To collect an item, it has to be clicked with left mouse button on the object’s image (not the sign, as noticed confusion during the testing phase). Then it gets automatically added to inventory, and the original object is deleted from the scene. To show detailed information about collected kanji, hover the pointer above  it.

The next step is to create a new kanji from gathered items. To do so, select 2 inventory items with left mouse button. The slot’s color should become red when selected. Press again to unselect. Then, press “MIX KANJI” button in the bottom right of the game’s window. If a destined kanji exists (the selection order does not matter), a new item will be added and the used ones will be disabled. The detailed information can be accessed no matter what state the slot is. 

To give an item to a NPC, first select desired kanji with right mouse button. An information box about what kanji is held should be displayed. Then, press the desired non-playable character with left mouse button to give them the item. If the kanji is correctly given, there will be a new dialog triggered and the animal will change its display image. Sometimes, a new object will be added to the scenery. If the kanji cannot be give, nothing happens. To try again, put down held item by pressing it again with right mouse button and repeat last steps. 

When all puzzles are solved in current level, a new information box appears in the bottom right of the screen. As written on it – to go to next level, press “N”. If there is no more levels, the credits scene is loaded. To exit, press “ESC” key. It can be done at any point of the game. 
