using System;

namespace Day012_Project_Sudoku
{
	class Program
	{


		public static void DisplayBoard(int[,] Board, int rows, int column)
		{
			//to Display the initial Board
			Console.Write("    [0] [1] [2] [3] [4] [5] [6] [7] [8]\n");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("\n[{0}]", i);

				for (int j = 0; j < column; j++)
				{

					Console.Write("| {0} ", Board[i, j]);
				}

				Console.WriteLine("|");
			}
		}
		public static bool CheckUserInput(int[,] board, int row, int col, int num)
		{
			//row clash, hint try another row	
			//column clash error, hint try another row	
			for (int i = 0; i < 9; i++)
			{
				if (board[row, i]== num )
				{
					return  false;
					
				}
                else
                {
					return true;
                }
			}

			for (int i = 0; i < 9; i++)
			{
				if (board[col, i] == num)
				{
					return false;
				}
                else
                {
					return true;
                }
			}



		return true;	
		}

		public static int[,] GetUserInput(int numInput, int[,] newBoard)
		{

			//[number,row,col]
			int UserNumber = 0;
			int row = 0;
			int col = 0;

			for (int i = 0; i < numInput; i++)
			{
				Console.Write("\n Enter the Number {0} :", i + 1);
				UserNumber = Convert.ToInt32(Console.ReadLine());

				while (UserNumber <= 0)
                {
					Console.WriteLine("\n!!ERROR: NUMBER MUST BE GREATER THAN 0  **\n");
					Console.Write("\n Enter the Number {0} :", i + 1);
					UserNumber = Convert.ToInt32(Console.ReadLine());
				}

				Console.Write("\n Enter the ROW number : ");
				row = Convert.ToInt32(Console.ReadLine());

				Console.Write("\n Enter the COLUMN number : ");
				col = Convert.ToInt32(Console.ReadLine());

				while (!ValidPlacement(newBoard, row, col, UserNumber))
				{
					Console.WriteLine("\n!!ERROR: CONFLICT!!**\n");
					Console.Write("\n Enter the ROW number : ");
					row = Convert.ToInt32(Console.ReadLine());

					Console.Write("\n Enter the COLUMN number : ");
					col = Convert.ToInt32(Console.ReadLine());
				}

				newBoard[row, col] = UserNumber;

				//while (!CheckUserInput(newBoard, row, col, UserNumber))
				//{
				//    Console.WriteLine("\n!!ERROR: Row Conflict\n**");
				//    Console.Write("\n Enter the ROW number : ");
				//    row = Convert.ToInt32(Console.ReadLine());

				//    Console.Write("\n Enter the COLUMN number : ");
				//    col = Convert.ToInt32(Console.ReadLine());
				//    newBoard[row, col] = UserNumber;
				//}


			}

			return newBoard;
		}

		public static bool SolveBoard(int[,] board, int n)
		{
			//check if the row = 8 and the columnn is out of index
			//this means we finished the searching

			int currRow = -1;
			int currCol = -1;
			bool allEmpty = true;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (board[i, j] == 0)// missing value needs to be found
					{
						currRow = i;
						currCol = j;

						allEmpty = false;//
						break;
					}
					
				}

				if (allEmpty == false)
				{
					break;
				}
			}

			//if no space left
			if (allEmpty)
			{
				return true;
			}

			//add potential placement from 1-9 and check is it valid
            //this is the recurssion 
			for (int number = 1; number <= n; number++) 
            {
				//validplacement check
				if (ValidPlacement(board, currRow, currCol, number))
				{
					board[currRow, currCol] = number;

					//Next, we do recurssion to check out placement and so on
					//n is number of rows.

					if (SolveBoard(board, n))
					{
						return true; //this means replacement is correct
					}
					else
					{
						board[currRow, currCol] = 0; //this means replacement is incorrect
					}
				}

			}
			return false;

		}

		public static bool ValidPlacement(int[,] board, int row, int col, int num)
		{

			//1. check if the number is duplicated in the row
			for (int i = 0; i < board.GetLength(0); i++)
			{
				if (board[row, i] == num)
				{
					return false;
				}
			}

			//2. check if the number is duplicate in the column
			for (int i = 0; i < board.GetLength(1); i++)
			{

				if (board[i, col] == num)
				{
					return false;
				}
			}

            //3.check if the number is unique in the block 3 * 3
            // Blocks/sub grid is a function to determine the starting
            // row and column of the position I'm placing in

            int[] boxStart = Blocks(row, col);
			for (int i = boxStart[0]; i <= boxStart[0]+2; i++)
            {
                for (int j = boxStart[1]; j <= boxStart[1]+2; j++)
                {
                    if (board[i,j]==num)
                    {
						return false;
                    }
                }
            }
			// if there is no clash, it's safe
			return true;

		}
		public static int[] Blocks(int row, int col)
		{
	
			int[] boxStart = new int[2];
			

			if (row >= 0 && row <= 2) //it is in b1 or b2 or b3 
			{
				boxStart[0] = 0;

				if (col >= 0 && col <= 2)
					boxStart[1] = 0;

				if (col >= 3 && col <= 5)
					boxStart[1] = 3;

				if (col >= 6 && col <= 9)
					boxStart[1] = 6;

			}
			if (row >= 3 && row <= 5)//it is in b4 or b5 or b6 
			{
				boxStart[0] = 3;

				if (col >= 0 && col <= 2)
					boxStart[1] = 0;

				if (col >= 3 && col <= 5)
					boxStart[1] = 3;

				if (col >= 6 && col <= 9)
					boxStart[1] = 6;
			}
			if (row >= 6 && row <= 8)//it is in b7 or b8 or b9 
			{
				boxStart[0] = 6;

				if (col >= 0 && col <= 2)
					boxStart[1] = 0;

				if (col >= 3 && col <= 5)
					boxStart[1] = 3;

				if (col >= 6 && col <= 9)
					boxStart[1] = 6;
			}

			return boxStart;
		} 
		// Driver Code



		public static void Main(String[] args)
		{
			
			//Welcom to the game

			Console.WriteLine("\nDo you want to play Sudoku: (y/n)\n");
			string userWantPlay = Console.ReadLine();

			while (userWantPlay == "y")
			{
				//Instructions to the user:
				/*1. ONLY USE NUMBERS FROM 1 TO 9
				  2. HOW MANY NUMBERS DO YOU WANT TO PLACE?
				  3. ENTER ROW NUMBER
				  4. ENTER COLUMN NUMBER*/

				int[,] OriginalBoard = new int[,] {
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }
				};

				int NumRows = OriginalBoard.GetLength(0);
				int NumColumns = OriginalBoard.GetLength(1);

				int[,]  newBoard = OriginalBoard;

				//user n inputs
				int nInput = 0;


				Console.WriteLine("\nInstrusions of the Game:\n 1. ONLY USE NUMBERS FROM 1 TO 9 \n 2. Row and Column Number should be from 0 to 8 Only");

				Console.WriteLine("\n------------------------------------------------");
				Console.WriteLine("\t This is the Board.\n------------------------------------------------");

				DisplayBoard(OriginalBoard, NumRows, NumColumns);

				Console.WriteLine("------------------------------------------------");

				Console.WriteLine("\n How many numbers do you want to place on the board?");
				Console.WriteLine("\n REMEBER: You can choose number from 0 -81 ONLY!!");
				Console.WriteLine("** HOW MANY NUMBER YOU WANT TO ENTER!!");
				nInput = Convert.ToInt32(Console.ReadLine());

				while (nInput == 0)
				{
					Console.WriteLine("\n!!ERROR: Number (0) is NOT ALLOWED ** \n");
					Console.Write("\n ** HOW MANY NUMBER YOU WANT TO ENTER!!");
					nInput = Convert.ToInt32(Console.ReadLine());
				}

				while (nInput > 81 || nInput < 0) //if nInput >81 || < 0 >> Print "Error, Try again"  
				{
					Console.WriteLine("!!!ERROR!!");
					Console.WriteLine("** REMEBER: You can choose number from 0 -81 ONLY!!");
					Console.WriteLine("** ENTER AGAIN!!");
					nInput = Convert.ToInt32(Console.ReadLine());

					
				}

				//HOW TO CREAT/PLUG IN  THE NEW BOARD
				
				newBoard = GetUserInput(nInput, newBoard);// Receive user inputs



				Console.WriteLine("\n-------------The Board Before Solving ?---------------");
				Console.WriteLine("\n---------------------------------------");
				DisplayBoard(newBoard, NumRows, NumColumns);
				Console.WriteLine("\n---------------------------------------");
				//solve
				//if solved, print it

				if (SolveBoard(newBoard, NumRows))
				{
					Console.WriteLine("\n******* YAY!! SOLVED ******** \n\n ----------------------------------------");
					DisplayBoard(newBoard, NumRows, NumColumns);
					Console.WriteLine("\n--------------------------------------------");
				}
				else
				{
					Console.WriteLine("\n--------------------------------------------");
					Console.WriteLine("\nOops!! No solution according to your input!!");
					Console.WriteLine("\n--------------------------------------------");
				}

				Console.WriteLine("Do you want to play again Sudoku: (y/n)");
				userWantPlay = Console.ReadLine();
				


			}



		}


	}
}

