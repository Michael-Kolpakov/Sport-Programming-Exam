// Exercise 3: Implement the Game of Life
Console.Write("Enter the height of the board: ");
var height = int.Parse(Console.ReadLine()!);

Console.Write("Enter the width of the board: ");
var width = int.Parse(Console.ReadLine()!);

var board = new bool[height, width];
var rand = new Random();

for (int y = 0; y < height; y++)
    for (int x = 0; x < width; x++)
        board[y, x] = rand.Next(2) == 0;
        
var iterationsCount = 0;
var stable = false;

while (!stable)
{
    Console.Clear();
    PrintBoard(board, width, height);
    
    var newBoard = new bool[height, width];
    
    stable = true;
    
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            var liveNeighbors = CountLiveNeighbors(board, x, y, width, height);
            
            if (board[y, x])
                newBoard[y, x] = liveNeighbors is 2 or 3;
            else
                newBoard[y, x] = liveNeighbors == 3;

            if (board[y, x] != newBoard[y, x])
                stable = false;
        }
    }

    board = newBoard;
    iterationsCount++;
    Thread.Sleep(500);
}

Console.WriteLine($"The process stabilized after {iterationsCount} iterations");

return;

void PrintBoard(bool[,] board, int width, int height)
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
            Console.Write(board[y, x] ? "\u2588" : "·");
        
        Console.WriteLine();
    }
}

int CountLiveNeighbors(bool[,] board, int x, int y, int width, int height)
{
    var count = 0;

    for (int j = -1; j <= 1; j++)
    {
        for (int i = -1; i <= 1; i++)
        {
            if (i == 0 && j == 0) 
                continue;

            var newX = x + i;
            var newY = y + j;

            if (newX < 0 || newX >= width || newY < 0 || newY >= height) 
                continue;
            
            if (board[newY, newX])
                count++;
        }
    }

    return count;
}