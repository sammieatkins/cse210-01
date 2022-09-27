// Tic-Tac-Toe Assignment Unit 01
// Samantha Atkins

using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        welcomeMessage(); 
        var board = createBoard();
        int turn = 0;
        bool isWinner = false;
        string player = "";
        while (turn != 9 && !isWinner)
        {
            turn += 1;
             displayBoard(board);
            player = determineTurn(turn);
            int choice = getChoice(player);
            board = updateBoard(board, choice, player);
            isWinner = checkWin(board);            
        }
        endingMessage(isWinner, player);
    }
    static void welcomeMessage()
    {
        Console.WriteLine("Welcome to Tic Tac Toe :)");
    }
    static List<string> createBoard()
    {
        List<string> board = new List<string>{"1","2","3","4","5","6","7","8","9"};
        return board;
    }
    static void displayBoard(List<string> board)
    {
        Console.WriteLine("");
        Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        Console.WriteLine("");
    }
    static string determineTurn(int turn)
    {
        string player = "y";
        if (turn == 1 || turn == 3 || turn == 5 || turn == 7 || turn == 9)
        {
            player = "x";
        }
        if (turn == 2 || turn == 4 || turn == 6 || turn == 8)
        {
            player = "o";
        }
        return player;
    }
    static int getChoice(string player)
    {
        int choice = -1;
        while (choice > 9 || choice < 1){
            Console.Write($"{player}'s turn to choose a square (1-9): ");
            string before = Console.ReadLine();
            choice = int.Parse(before);
        }
        return choice;
    }
    static List<string> updateBoard(List<string> board, int choice, string player)
    {
        // search for the number in the list
        int index = choice - 1;
        board[index] = player;
        return board;
    }
    static bool checkWin(List<string> board)
    {
        if (board[0] == board[1] && board[1] == board[2]) return true;
        else if (board[3] == board[4] && board[4] == board[5]) return true;
        else if (board[6] == board[7] && board[7] == board[8]) return true;

        else if (board[0] == board[3] && board[3] == board[6]) return true;
        else if (board[1] == board[4] && board[4] == board[7]) return true;
        else if (board[2] == board[5] && board[5] == board[8]) return true;

        else if (board[0] == board[4] && board[4] == board[8]) return true;
        else if (board[2] == board[4] && board[4] == board[6]) return true;
        else return false;
    }
    static void endingMessage(bool isWinner, string player)
    {
        if (isWinner == false){
            Console.WriteLine("Tie game");
        }
        else if (isWinner){
            Console.WriteLine($"{player} won");
        }
        Console.WriteLine("Thanks for playing!!");
    }

}
