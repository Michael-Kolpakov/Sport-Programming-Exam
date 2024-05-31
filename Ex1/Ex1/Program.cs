// Exercise 1: Write a program that swaps the values of two variables
var a = 5;
var b = 9;

Console.WriteLine($"Value of variable A: {a}");
Console.WriteLine($"Value of variable B: {b}\n");

a += b;
b = a - b;
a -= b;

Console.WriteLine($"Value of variable A after changing places: {a}");
Console.WriteLine($"Value of variable B after changing places: {b}");