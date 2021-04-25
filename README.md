# Sudoku Puzzle
##  1. Introduction
The objective of this puzzle is to fill 9x9 grid with digits so that each column, each row and each of the nine 3x3 subgrids contains all of the digits from 1 to 9.

This project is designed to write a program in C# language to solve Sudoku puzzle in a way that the users can enter the amount of numbers (1 to 9) and their positions (row and column).

## 2. Approaches to solve Sudoku
The team conducted initial research to solve sudoku and explore the applied algorithms in solving such puzzles.

We found the common approaches are Brute Force approach and Backtracking algorithm. Simple backtracking algorithm differs from brute-force because it verifies the possible assignments—placements for each empty cell. When the cell has no feasible placement, the algorithm backtracks and changes the assignment of an already filled cell [1].

## 3. Method
There are three key steps in order to solve the puzzle.

1. The choice: place 1 to 9 in an empty cell

2. The constraints: placement cannot break the board—grid.

3. The goal: fill the board.

Each time placing a number in an empty cell, the program does recursion to check if assignment is valid or not. Validation is done by checking the constraints: the assignment cannot appear in the same row or column or the subgrid it belongs to. If the assignment is valid, it will be assigned to that cell. Otherwise, it will be replaced by zero.

## Reference
[1] Coelho, L., & Laporte, G. (2014). A comparison of several enumerative algorithms for Sudoku. _The Journal of the Operational Research Society,_  _65_(10), 1602-1610. Retrieved April 24, 2021, from http://www.jstor.org/stable/24505021

# (فريق ابطال الديجتال)Team Members:
## Arwa Wan La (اروى وان لا)
## Rahaf AlQhtani( رهف القحطاني)
## Nada AlOtaibi(ندى العتيبي)
