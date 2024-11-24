// See https://aka.ms/new-console-template for more information

using ExtensionMethods;

Console.WriteLine("Hello, World!");


var product = new Product
{
    Id = 10,
    Name = "kalem 1"
};

Console.WriteLine(product.GetFullName());


int i = 10;

string name = "asp.net core";


Console.WriteLine(name.GetFirstCharacter());


var firstLetter = Helper.GetFirstCharacter(name);
Console.WriteLine(firstLetter);