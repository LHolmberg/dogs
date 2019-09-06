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
            input = Console.ReadLine().ToLower();

            if (input == "add")
                AddDog();
            else if (input == "print")
                Print();
            else if (input == "search")
                Search();
            else if (input == "help")
                Help();
            else
                Console.WriteLine("error");
        }
    }

    void AddDog()
    {
        string name = "", gender = "", breed = "";
        int age = 0;
        double length = 0, withers = 0, weight = 0;
        bool incorrect = false;

        Console.Write("Name: ");
        name = Console.ReadLine().ToLower();

        Console.Write("Gender: ");
        gender = Console.ReadLine().ToLower();

        while(!incorrect)
        {
            Console.Write("Age: ");
            incorrect = int.TryParse(Console.ReadLine(), out age);
            if(!incorrect)
                Console.WriteLine("Please, enter an integer number!");
        }
        incorrect = false;

        while(!incorrect)
        {
            Console.Write("Length: ");
            incorrect = double.TryParse(Console.ReadLine(), out length);
            if(!incorrect)
                Console.WriteLine("Please, enter a number!");
        }
        incorrect = false;

        while(!incorrect)
        {
            Console.Write("Withers: ");
            incorrect = double.TryParse(Console.ReadLine(), out withers);
            if(!incorrect)
                Console.WriteLine("Please, enter a number!");
        }
        incorrect = false;

        while(!incorrect)
        {
            Console.Write("Weight: ");
            incorrect = double.TryParse(Console.ReadLine(), out weight);
            if(!incorrect)
                Console.WriteLine("Please, enter a number!");
        }
        
        Console.Write("Breed: ");
        breed = Console.ReadLine().ToLower();

        switch(breed)
        {
        case "tax":
            if(CheckIfContains(name, gender, age, length, withers, weight, breed))
            {
                Console.WriteLine("A {0} named {1} was added", breed, name);
                dogs.Add(new Tax(name, gender, age, length, withers, weight, breed));
            }
            else 
                Console.WriteLine("Error adding dog: already exists");
            break;
        case "pudel":
            if(CheckIfContains(name, gender, age, length, withers, weight, breed))
            {
                Console.WriteLine("A {0} named {1} was added", breed, name);
                dogs.Add(new Pudel(name, gender, age, length, withers, weight, breed));
            }
            else 
                Console.WriteLine("Error adding dog: already exists");
            break;
        case "labrador":
            if(CheckIfContains(name, gender, age, length, withers, weight, breed))
            {
                Console.WriteLine("A {0} named {1} was added", breed, name);
                dogs.Add(new Labrador(name, gender, age, length, withers, weight, breed));
            }
            else 
                Console.WriteLine("Error adding dog: already exists");
            break;
        default:
            Console.WriteLine("There are currently no info about the breed {0}", breed);
            break;
        }
    }

    bool CheckIfContains(string name, string gender, int age, double length, double withers, double weight, string breed)
    {
        int count = 0;
        for(int i = 0; i < dogs.Count; i++)
        {
            if(dogs[i].Name == name && dogs[i].Gender == gender && dogs[i].Age == age && dogs[i].Length == length &&
            dogs[i].Withers == withers && dogs[i].Weigth == weight && dogs[i].Breed == breed)
            {
                count++;
            }
        }
        if(count == 1)
            return false;
        else
            return true;
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
        Console.WriteLine("####################");
        Console.WriteLine("The existing commands are:");
        Console.WriteLine("add");
        Console.WriteLine("print");
        Console.WriteLine("remove");
        Console.WriteLine("search");
        Console.WriteLine("help");
        Console.WriteLine("####################");
    }

    void Search()
    {
        Console.Write("What is the name of the dog?: ");
        string name = Console.ReadLine().ToLower();
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
            Console.WriteLine("There are no dogs with the name {0}", name);

        else
        { 
            count = 0;
            Console.Write("There are multiple dogs with that name, please specify by entering it's breed: ");
            string breed = Console.ReadLine().ToLower();
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
            else if(count == 0)
                Console.WriteLine("There are no dogs with the breed {0} named {1}", breed, name);
            else 
            {
                count = 0;
                Console.Write("There are multiple dogs with that breed, please specify by entering it's gender: ");
                string gender = Console.ReadLine().ToLower();
                for(int i = 0; i < dogs.Count; i++)
                {
                    if(dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender)
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
                else if(count == 0)
                    Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2}", breed, name, gender);
                else 
                {
                    count = 0;
                    bool incorrect = false;
                    int age = 0;
                    while(!incorrect)
                    {
                        Console.Write("There are multiple dogs with that gender, please specify by entering it's age: ");
                        incorrect = int.TryParse(Console.ReadLine(), out age);
                        if(!incorrect)
                            Console.WriteLine("Please, enter an integer number!");
                    }

                    for(int i = 0; i < dogs.Count; i++)
                    {
                        if(dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender && dogs[i].Age == age)
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
                    else if(count == 0)
                        Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3}", breed, name, gender, age);
                    else 
                    {
                        count = 0;
                        incorrect = false;
                        double withers = 0;
                        while(!incorrect)
                        {
                            Console.Write("There are multiple dogs with that age, please specify by entering it's withers: ");
                            incorrect = double.TryParse(Console.ReadLine(), out withers);
                            if(!incorrect)
                                Console.WriteLine("Please, enter an number!");
                        }

                        for(int i = 0; i < dogs.Count; i++)
                        {
                            if(dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender && dogs[i].Withers == withers)
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
                        else if(count == 0)
                            Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3} & and it's wither is {4}", breed, name, gender, age, withers);
                        else 
                        {
                            count = 0;
                            incorrect = false;
                            double weight = 0;
                            while(!incorrect)
                            {
                                Console.Write("There are multiple dogs with that withers, please specify by entering it's weight: ");
                                incorrect = double.TryParse(Console.ReadLine(), out weight);
                                if(!incorrect)
                                    Console.WriteLine("Please, enter an number!");
                            }

                            for(int i = 0; i < dogs.Count; i++)
                            {
                                if(dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender &&
                                 dogs[i].Withers == withers && dogs[i].Weigth == weight)
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
                            else if(count == 0)
                                Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3}, weight of {4} & and it's wither is {5}", breed, name, gender, age, weight, withers);
                            else 
                            {
                                count = 0;
                                incorrect = false;
                                double length = 0;
                                while(!incorrect)
                                {
                                    Console.Write("There are multiple dogs with that weight, please specify by entering it's length: ");
                                    incorrect = double.TryParse(Console.ReadLine(), out length);
                                    if(!incorrect)
                                        Console.WriteLine("Please, enter an number!");
                                }

                                for(int i = 0; i < dogs.Count; i++)
                                {
                                    if(dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender && dogs[i].Withers == withers)
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
                                else if(count == 0)
                                    Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3}, weight of {4}, length of {5} & and it's wither is {6}", breed, name, gender, age, weight, length, withers);
                            }
                        }
                    }
                }
            }
        }
    }
}
