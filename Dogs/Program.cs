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
        while (true)
        {
            Console.Write("enter a command, (use help to show existing commands): ");
            input = Console.ReadLine();

            if (input.ToLower() == "add")
                AddDog();
            else if (input.ToLower() == "print")
                Print();
            else if (input.ToLower() == "remove")
                Remove();
            else if (input.ToLower() == "search")
                Search();
            else if (input.ToLower() == "help")
                Help();
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

        switch(b.ToLower())
        {
        case "tax":
            dogs.Add(new Tax(n, g, a, l, w, we, b));
            Console.WriteLine("A {0} named {1} was added", b, n);
            break;
        case "pudel":
            dogs.Add(new Pudel(n, g, a, l, w, we, b));
            Console.WriteLine("A {0} named {1} was added", b, n);
            break;
        case "labrador":
            dogs.Add(new Labrador(n, g, a, l, w, we, b));
            Console.WriteLine("A {0} named {1} was added", b, n);
            break;
        default:
            Console.WriteLine("There are currently no info about the breed {0}", b);
            break;
        }
    }

    void Print()
    {
        if (dogs.Count >= 1)
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

    void Help()
    {
        Console.WriteLine("The existing commands are:");
        Console.WriteLine("add");
        Console.WriteLine("print");
        Console.WriteLine("remove");
        Console.WriteLine("search");
        Console.WriteLine("help");
    }
    void Remove()
    {
        Console.Write("Whats the name of the dog you want to remove?: ");
        string input = Console.ReadLine();
        int nameCount = 0;
        for(int i = 0; i < dogs.Count; i++)
        {
            if(dogs[i].Name == input)
            {
                nameCount++;
            }
        }
        
        for(int i = 0; i < dogs.Count; i++)
        {
            if(dogs[i].Name == input && nameCount <= 1)
            {
                Console.WriteLine("Successfully removed the dog named {0}", dogs[i].Name);
                dogs.Remove(dogs[i]);
            }
        }
    }

    void Search()
    {
        Console.Write("What is the name of the dog?: ");
        string name = Console.ReadLine();
        int count = 0, g_i = 0; 
        for(int i = 0; i < dogs.Count; i++)
        {
            if(dogs[i].Name == name)
            {
                count++;
                g_i = i;  
            }
        }
        if(count == 1)
        {
            Console.WriteLine("Dog named {0} was found at index {1}, here is a more detailed look: ", dogs[g_i].Name, g_i);
            Console.WriteLine(dogs[g_i].GetAsString());
        }
        else if (count == 0)
        {
            Console.WriteLine("There are no dogs with the name {0}", dogs[g_i].Name);
        }
        else
        { 
            count = 0;
            Console.Write("There are multiple dogs with that name, please specify by entering it's breed: ");
            string breed = Console.ReadLine();
            for(int i = 0; i < dogs.Count; i++)
            {
                if(dogs[i].Name == name && dogs[i].Breed == breed)
                {
                    count++;
                    g_i = i;
                }
            }
            if(count == 1)
            {
                Console.WriteLine("{0} named {1} was found at index {2}, here is a more detailed look: ", dogs[g_i].Breed, dogs[g_i].Name, g_i);
                Console.WriteLine(dogs[g_i].GetAsString());
            }
            if(count == 0)
            {
                Console.WriteLine("There are no dogs with the breed {0} named {1}", dogs[g_i].Breed, dogs[g_i].Name);
            }
            else 
            {
                //Check more................
            }
        }
    }
}

