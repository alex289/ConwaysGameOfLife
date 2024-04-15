# Conway's Game of Life

This repository contains an implementation of Conway's Game of Life in C#. Conway's Game of Life is a cellular automaton devised by the British mathematician John Horton Conway in 1970. The game is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input. One interacts with the Game of Life by creating an initial configuration and observing how it evolves.

## Rules

1. Any live cell with fewer than two live neighbors dies, as if by underpopulation.
2. Any live cell with two or three live neighbors lives on to the next generation.
3. Any live cell with more than three live neighbors dies, as if by overpopulation.
3. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

## Parameters

Parameters can be set in the Program.cs file by changing the values of the following variables:

- `rows` - The number of rows in the grid.
- `columns` - The number of columns in the grid.
- `generations` - The number of generations to simulate.
- `showGeneration` - A boolean value that determines whether to print the number of the current generation.