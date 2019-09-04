using System;
using System.Collections.Generic;

class Program
{
    private List<Dog> dogs = new List<Dog>();

    static void Main(string[] args)
    {
        Program program = new Program();
        program.ProgramLoop();
    }

    void ProgramLoop()
    {
        string input;
        while(true)
        {
            Console.Write("enter: add / print: ");
            input = Console.ReadLine();

            if (input == "add")
                AddDog();
            else if (input == "print")
                Print();
            else 
                Console.WriteLine("error");
        }
    }

    void AddDog()
    {
        Console.Write("Name: ");
        string n = Console.ReadLine();
        Console.Write("Gender: ");
        string g = Console.ReadLine();
        Console.Write("Age: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Length: ");
        double l = Convert.ToDouble(Console.ReadLine());
        Console.Write("Withers: ");
        double w = Convert.ToDouble(Console.ReadLine());
        Console.Write("Weight: ");
        double we = Convert.ToDouble(Console.ReadLine());
        Console.Write("Breed: ");
        string b = Console.ReadLine();
        
        dogs.Add(new Dog(n, g, a, l, w, we, b));
    }

    void Print()
    {
        if(dogs.Count >= 1)
        {
            Console.WriteLine("Currently " + dogs.Count + " dogs added");
            foreach (Dog dog in dogs)
            {
                Console.WriteLine(dog.GetAsString());
            }
        }
        else
            Console.WriteLine("You have 0 dogs added");
    }
}

