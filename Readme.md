# Journeys

A while back, a friend of mine applied for a software development job. They gave him a little take home test that he also shared with me.
I really enjoyed the challenge. This repo contains my attempt at meeting it.

### The Challenge

You are given a file, something like this:
```
1 1 E
RFRFRFRF
1 1 E

3 2 N
FRRFLLFFRRFLL
3 3 N

0 3 W
LLFFFLFLFL
2 4 S
```
It contains zero to many (in this case 3) journeys. 
Here's the first one:
```
1 1 E
RFRFRFRF
1 1 E
```
Each one starts with the initial coordinates of the robot (1 1 in this case) and the direction it is pointing in. In this case E = East.
The directions are as follows:
```
N = North
E = East
S = South
W = West
```
Following the starting conditions are a list of commands:
```
RFRFRFRF
```
Each character is a command, either to turn (L = left, R = right) or to move forwards (F).

Finally the journey ends with another set of coordinates and a direction. This is the expected position and orientation of your robot at the 
end of the journey. Your program should check that it ends at the specified coordinates and facing in the given direction.

The challenge is to parse the input file, set the start position of your robot, then have it execute the instructions and check its final postion with 
the expected position.

### My Implementation

My solution to this challenge is implemented as a simple dotnet core 3.0 console application. To run it, simply clone this repository,
open the solution in Visual Studio and hit F5. You can also build it and run it with the dotnet SDK.

### Other solutions

[A Haskell solution](https://blog.ploeh.dk/2019/10/28/a-basic-haskell-solution-to-the-robot-journeys-coding-exercise/)
by @ploeh

[Another .NET solution](https://github.com/djhmateer/Journeys)
by @djhmateer

[A Clojure solution](https://gist.github.com/devirr/4b38992d858f98d5617998ac012928c6)
by @devirr

[An F# solution](https://gist.github.com/xdaDaveShaw/faad35ccd89e72a221e2a1d428e6b321)
by @xdaDaveShaw

[A Javascript solution](https://gist.github.com/jenko3000/1193c3a6824be336940060c6f3f81490)
by @willyjenkins

[Another F# solution](https://github.com/ZaymonFC/ToyRobot)
by @@ZedamonTheWise


