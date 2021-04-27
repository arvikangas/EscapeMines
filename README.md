# Escape mines game

## Notes  
- Start app. Enter path to file. App should print results per sequence of moves
- Made assumption on input file coordinates based on example. That Board Size 5 6 means X = 6 and Y = 5, same for starting point and exit. But for mines
1,2 means X = 1, Y = 2. 
- Did not use any 3rd party library except in unit tests. Because of that, no DI or logging.
- Unit tests done with xunit, NSubstitute, Shouldly
- I added folder to app project "examplefiles" with two examples. Build copies that folder to build output folder, if theres some issue with input file path.
