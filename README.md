# UnderlordsTester
Simple GUI for Underlords memory editing and build testing. Requires Windows 64 bit.

# WARNING
This program includes things that modify Underlords' memory. This MAY be able to trigger a VAC ban if/when they add VAC. Use at your own risk.

### Basic information

This program may require administrator if it's unable to load underlords' memory. The program also needs file read/write in the folder its in.

You MUST force a client refresh before combat starts if you make any hero changes to your board in the tester by making a change to your board in game and switching to and from a bot's view. You can make a change to your board by moving/buying a unit or by attempting to reroll the shop.

The board/items work in Underlords click/drag fashion. Clicking a square containing a unit or clicking any item square will change the panel below the unit boards to allow for unit edits.

Create Hero buttons: Create a hero. This button makes use of a small code injection into the server's main loop to create heroes. If that sounds too scary, setting the bot's gold high enough and letting them buy their own heroes can be done instead.

Lock Board button: Prevents all hero/item movements, stops the bot from wanting to move units (hopefully), and stops the bot from wanting to buy anything. Board should be locked before combat ends to stop any board changes by the bot. If the game freezes after combat ends, try unlocking the board. Also report the freeze here if you feel like it.

Kill Bots button: Sets the 6 uninteresting bots life to 0.

Pause button: Forces the server to pause. Can allow for untested pausing in developer mode.

Translation.txt located in the TextFiles folder after the program has been run can be replaced with any localization file from \Underlords\game\dac\panorama\localization if a different language for heroes/items/alliance is preferred. Copy the language file into the TextFiles folder and rename it to Translation.txt.


### To do list
1. Integrate new game functionality
2. Force client graphic update
3. Self Updater
4. Alliance icons and information
5. Hero Delete
6. Board Templates
