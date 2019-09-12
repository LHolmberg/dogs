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
            else if (input == "exit")
                Environment.Exit(0);
            else
                Console.WriteLine("error");
        }
    }

    void AddDog()
    {

        Console.Write("Name: ");
        string name = Console.ReadLine().ToLower();

        Console.Write("Gender: ");
        string gender = Console.ReadLine().ToLower();

        TryInput("Age: ", out double age);

        TryInput("Length: ", out double length);

        TryInput("Withers: ", out double withers);

        TryInput("Weight: ", out double weight);

        Console.Write("Breed: ");
        string breed = Console.ReadLine().ToLower();

        SuccessfullyAdd(name, gender, Convert.ToInt32(age), length, withers, weight, breed);
    }

    private static void TryInput(string msg, out double age)
    {
        while(true)
        {
            try
            {
                Console.Write(msg);
                age = double.Parse(Console.ReadLine());
                break;
            } catch(Exception e) 
            {
                Console.WriteLine("{0} is not the right format", e.GetType().Name);
            }
        }
    }

    void SuccessfullyAdd(string name, string gender, int age, double length, double withers, double weight, string breed)
    {
        int count = 0;
        for (int i = 0; i < dogs.Count; i++)
        {
            if (dogs[i].Name == name && dogs[i].Gender == gender && dogs[i].Age == age && dogs[i].Length == length &&
            dogs[i].Withers == withers && dogs[i].Weigth == weight && dogs[i].Breed == breed)
            {
                count++;
            }
        }

        if (count == 1)
            Console.WriteLine("Error adding dog: already exists");
        else
        {
            switch (breed)
            {
                case "tax":
                    Console.WriteLine("A {0} named {1} was added", breed, name);
                    dogs.Add(new Tax(name, gender, age, length, withers, weight, breed));
                    break;
                case "pudel":
                    Console.WriteLine("A {0} named {1} was added", breed, name);
                    dogs.Add(new Pudel(name, gender, age, length, withers, weight, breed));
                    break;
                case "labrador":
                    Console.WriteLine("A {0} named {1} was added", breed, name);
                    dogs.Add(new Labrador(name, gender, age, length, withers, weight, breed));
                    break;
                default:
                    Console.WriteLine("There are currently no info about the breed {0}", breed);
                    break;
            }
        }
    }

    void Print()
    {
        if (dogs.Count >= 1)
        {
            Console.WriteLine("Currently " + dogs.Count + " dogs added");
            dogs.Sort();
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
        Console.WriteLine("search");
        Console.WriteLine("help");
        Console.WriteLine("####################");
    }

    void EditDog(int id)
    {
        bool running = true;
        while(running == true)
        {
            Console.Write("What do you want to edit about the dog?(use exit if you want to quit): ");
            string answer = Console.ReadLine();
            string msg = "What do you want to change it to?: ";
            switch(answer.ToLower())
            {
                case "age":
                TryInput(msg, out double age);
                dogs[id].Age = Convert.ToInt32(age);
                break;
                case "name":
                Console.Write(msg);
                string name = Console.ReadLine();
                dogs[id].Name = name;
                break;
                case "gender":
                Console.Write(msg);
                string gender = Console.ReadLine();
                dogs[id].Gender = gender;
                break;
                case "length":
                TryInput(msg, out double length);
                dogs[id].Age = Convert.ToInt32(length);
                break;
                case "withers":
                TryInput(msg, out double withers);
                dogs[id].Age = Convert.ToInt32(withers);
                break;
                case "weight":
                TryInput(msg, out double weight);
                dogs[id].Age = Convert.ToInt32(weight);
                break;
                case "breed":
                Console.Write(msg);
                string breed = Console.ReadLine();
                dogs[id].Breed = breed;
                break;
                case "exit":
                running = false;
                break;
                default:
                Console.WriteLine("You cannot change that attribute since it does not exist");
                break;
            }
        }
    }
    void FoundDog(int id)
    {
        Console.Write("What do you want to do with this dog? (use help for help): ");
        string input = Console.ReadLine();
        if(input.ToLower() == "help")
        {
            Help();
        }
        else if(input.ToLower() == "remove")
        {
            dogs.Remove(dogs[id]);
        }
        else if(input.ToLower() == "edit")
        {
            EditDog(id);
        } 
        else if(input.ToLower() == "exit")
        {
            ProgramLoop();
        }
        else {
            Console.WriteLine("Error");
        }
    }

    void Search()
    {
        Console.Write("What is the name of the dog?: ");
        string name = Console.ReadLine().ToLower();
        int count = 0, g_i = 0;

        for (int i = 0; i < dogs.Count; i++)
        {
            if (dogs[i].Name == name)
            {
                count++;
                g_i = i;
            }
        }
        if (count == 1)
        {
            Console.WriteLine("Dog named {0} was found at index {1}, here is a more detailed look: ", dogs[g_i].Name, g_i);
            Console.WriteLine(dogs[g_i].GetAsString());
            FoundDog(g_i);
        }
        else if (count == 0)
            Console.WriteLine("There are no dogs with the name {0}", name);

        else
        {
            count = 0;
            Console.Write("There are multiple dogs with that name, please specify by entering it's breed: ");
            string breed = Console.ReadLine().ToLower();
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs[i].Name == name && dogs[i].Breed == breed)
                {
                    count++;
                    g_i = i;
                }
            }
            if (count == 1)
            {
                Console.WriteLine("{0} named {1} was found at index {2}, here is a more detailed look: ", dogs[g_i].Breed, dogs[g_i].Name, g_i);
                Console.WriteLine(dogs[g_i].GetAsString());
            }
            else if (count == 0)
                Console.WriteLine("There are no dogs with the breed {0} named {1}", breed, name);
            else
            {
                count = 0;
                Console.Write("There are multiple dogs with that breed, please specify by entering it's gender: ");
                string gender = Console.ReadLine().ToLower();
                for (int i = 0; i < dogs.Count; i++)
                {
                    if (dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender)
                    {
                        count++;
                        g_i = i;
                    }
                }
                if (count == 1)
                {
                    Console.WriteLine("{0} named {1} was found at index {2}, here is a more detailed look: ", dogs[g_i].Breed, dogs[g_i].Name, g_i);
                    Console.WriteLine(dogs[g_i].GetAsString());
                    FoundDog(g_i);
                }
                else if (count == 0)
                    Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2}", breed, name, gender);
                else
                {
                    count = 0;
                    bool incorrect = false;
                    int age = 0;
                    while (!incorrect)
                    {
                        Console.Write("There are multiple dogs with that gender, please specify by entering it's age: ");
                        incorrect = int.TryParse(Console.ReadLine(), out age);
                        if (!incorrect)
                            Console.WriteLine("Please, enter an integer number!");
                    }

                    for (int i = 0; i < dogs.Count; i++)
                    {
                        if (dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender && dogs[i].Age == age)
                        {
                            count++;
                            g_i = i;
                        }
                    }
                    if (count == 1)
                    {
                        Console.WriteLine("{0} named {1} was found at index {2}, here is a more detailed look: ", dogs[g_i].Breed, dogs[g_i].Name, g_i);
                        Console.WriteLine(dogs[g_i].GetAsString());
                        FoundDog(g_i);
                    }
                    else if (count == 0)
                        Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3}", breed, name, gender, age);
                    else
                    {
                        count = 0;
                        incorrect = false;
                        double withers = 0;
                        while (!incorrect)
                        {
                            Console.Write("There are multiple dogs with that age, please specify by entering it's withers: ");
                            incorrect = double.TryParse(Console.ReadLine(), out withers);
                            if (!incorrect)
                                Console.WriteLine("Please, enter an number!");
                        }

                        for (int i = 0; i < dogs.Count; i++)
                        {
                            if (dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender && dogs[i].Withers == withers)
                            {
                                count++;
                                g_i = i;
                            }
                        }
                        if (count == 1)
                        {
                            Console.WriteLine("{0} named {1} was found at index {2}, here is a more detailed look: ", dogs[g_i].Breed, dogs[g_i].Name, g_i);
                            Console.WriteLine(dogs[g_i].GetAsString());
                            FoundDog(g_i);
                        }
                        else if (count == 0)
                            Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3} & and it's wither is {4}", breed, name, gender, age, withers);
                        else
                        {
                            count = 0;
                            incorrect = false;
                            double weight = 0;
                            while (!incorrect)
                            {
                                Console.Write("There are multiple dogs with that withers, please specify by entering it's weight: ");
                                incorrect = double.TryParse(Console.ReadLine(), out weight);
                                if (!incorrect)
                                    Console.WriteLine("Please, enter an number!");
                            }

                            for (int i = 0; i < dogs.Count; i++)
                            {
                                if (dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender &&
                                 dogs[i].Withers == withers && dogs[i].Weigth == weight)
                                {
                                    count++;
                                    g_i = i;
                                }
                            }
                            if (count == 1)
                            {
                                Console.WriteLine("{0} named {1} was found at index {2}, here is a more detailed look: ", dogs[g_i].Breed, dogs[g_i].Name, g_i);
                                Console.WriteLine(dogs[g_i].GetAsString());
                                FoundDog(g_i);
                            }
                            else if (count == 0)
                                Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3}, weight of {4} & and it's wither is {5}", breed, name, gender, age, weight, withers);
                            else
                            {
                                count = 0;
                                incorrect = false;
                                double length = 0;
                                while (!incorrect)
                                {
                                    Console.Write("There are multiple dogs with that weight, please specify by entering it's length: ");
                                    incorrect = double.TryParse(Console.ReadLine(), out length);
                                    if (!incorrect)
                                        Console.WriteLine("Please, enter an number!");
                                }

                                for (int i = 0; i < dogs.Count; i++)
                                {
                                    if (dogs[i].Name == name && dogs[i].Breed == breed && dogs[i].Gender == gender &&
                                      dogs[i].Withers == withers && dogs[i].Weigth == weight && dogs[i].Length == length)
                                    {
                                        count++;
                                        g_i = i;
                                    }
                                }
                                if (count == 1)
                                {
                                    Console.WriteLine("{0} named {1} was found at index {2}, here is a more detailed look: ", dogs[g_i].Breed, dogs[g_i].Name, g_i);
                                    Console.WriteLine(dogs[g_i].GetAsString());
                                    FoundDog(g_i);
                                }
                                else if (count == 0)
                                    Console.WriteLine("There are no dogs with the breed {0} named {1} and is a {2} with the age of {3}, weight of {4}, length of {5} & and it's wither is {6}", breed, name, gender, age, weight, length, withers);
                            }
                        }
                    }
                }
            }
        }
    }
}
