// Exercise 2: Write a program that checks the correctness of the parentheses in the entered string
Console.Write("Enter parenttheses string: ");

var input = Console.ReadLine();
var result = CheckBrackets(input!, out int errorIndex);

Console.WriteLine(result == string.Empty
    ? "The placement of the parentheses is correct"
    : $"An error in the placement of the parentheses in the position {errorIndex + 1}. Remainder: {result}");

return;

string CheckBrackets(string input, out int errorIndex)
{
    var stack = new Stack<char>();
    var brackets = new Dictionary<char, char>
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' }
    };
        
    for (int i = 0; i < input.Length; i++)
    {
        var c = input[i];
            
        if (brackets.ContainsValue(c))
            stack.Push(c);
        else if (brackets.TryGetValue(c, out char value))
        {
            if (stack.Count != 0 && stack.Pop() == value)
                continue;
            
            errorIndex = i;
            
            return input[i..];
        }
    }
        
    if (stack.Count == 0)
    {
        errorIndex = -1;
        return string.Empty;
    }

    errorIndex = input.Length - stack.Count;
    return new string(stack.ToArray());
}