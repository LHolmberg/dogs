using System;
using System.Collections.Generic;

class Program
{
    private List<Dog> dogList = new List<Dog>();

    static void Main(string[] args)
    {
        Program program = new Program();
        program.ProgramLoop();
    }

    private void ProgramLoop()
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

    private void TryInput(string msg, out double age)
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
                Console.WriteLine("{0} : Wrong format", e.GetType().Name);
            }
        }
    }

    private string FirstCharToUpper(string str)
    {
        if (str == null)
        return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }

    private void AddDog()
    {
        Console.Write("Breed: ");
        string breed = Console.ReadLine().ToLower();

        if(breed == "dachshund" || breed == "poodle" || breed == "labrador")
        {
            Console.Write("Name: ");
            string name = FirstCharToUpper(Console.ReadLine());

            Console.Write("Gender: ");
            string gender = Console.ReadLine().ToLower();

            TryInput("Age: ", out double age);
            
            TryInput("Length: ", out double length);

            TryInput("Withers: ", out double withers);

            TryInput("Weight: ", out double weight);


            SuccessfullyAdd(name, gender, Convert.ToInt32(age), length, withers, weight, breed);
        }
        else
        {
            Console.WriteLine("Please, enter a valid breed.");
            ProgramLoop();
        }
    }

    private void SuccessfullyAdd(string name, string gender, int age, double length, double withers, double weight, string breed)
    {
        int count = 0;
        for (int i = 0; i < dogList.Count; i++)
        {
            if (dogList[i].Name == name && dogList[i].Gender == gender && dogList[i].Age == age && dogList[i].Length == length &&
            dogList[i].Withers == withers && dogList[i].Weight == weight && dogList[i].Breed == breed)
            {
                count++; /* Om det redan finns en identisk hund så adderas denna variabeln,
                             är den 1 så betyder det att den redan finns och då kan man ej lägga till den!*/
            }
        }

        if (count == 1)
            Console.WriteLine("Error adding dog: already exists");
        else
        {
            switch (breed)
            {
                case "dachshund":
                    Console.WriteLine("A {0} named {1} was added", breed, name);
                    dogList.Add(new Dachshund(name, gender, age, length, withers, weight, breed));
                    break;
                case "poodle":
                    Console.WriteLine("A {0} named {1} was added", breed, name);
                    dogList.Add(new Poodle(name, gender, age, length, withers, weight, breed));
                    break;
                case "labrador":
                    Console.WriteLine("A {0} named {1} was added", breed, name);
                    dogList.Add(new Labrador(name, gender, age, length, withers, weight, breed));
                    break;
                default:
                    Console.WriteLine("There are currently no info about the breed {0}", breed);
                    break;
            }
        }
    }

    private void Print()
    {
        if (dogList.Count >= 1)
        {
            Console.WriteLine("\nCurrently " + dogList.Count + " dogs added");
            dogList.Sort();
            foreach (Dog dog in dogList)
            {
                Console.WriteLine(dog.GetAsString());
            }
        }
        else
            Console.WriteLine("You have 0 dogs added");
    }

    private void Help()
    {
        Console.WriteLine("####################");
        Console.WriteLine("The existing commands are:");
        Console.WriteLine("add");
        Console.WriteLine("print");
        Console.WriteLine("search");
        Console.WriteLine("help");
        Console.WriteLine("####################");
    }

    private void EditDog(int id)
    {
        bool running = true;
        while(running == true)
        {
            Console.Write("What do you want to edit about the dog?(use exit if you want to exit): ");
            string answer = Console.ReadLine();
            string msg = "What do you want to change it to?: ";
            switch(answer.ToLower())
            {
                case "age":
                    TryInput(msg, out double age);
                    dogList[id].Age = Convert.ToInt32(age);
                    break;
                case "name":
                    Console.Write(msg);
                    string name = Console.ReadLine();
                    dogList[id].Name = FirstCharToUpper(name);
                    break;
                case "gender":
                    Console.Write(msg);
                    string gender = Console.ReadLine();
                    dogList[id].Gender = gender;
                    break;
                case "length":
                    TryInput(msg, out double length);
                    dogList[id].Age = Convert.ToInt32(length);
                    break;
                case "withers":
                    TryInput(msg, out double withers);
                    dogList[id].Age = Convert.ToInt32(withers);
                    break;
                case "weight":
                    TryInput(msg, out double weight);
                    dogList[id].Age = Convert.ToInt32(weight);
                    break;
                case "breed":
                    Console.Write(msg);
                    string breed = Console.ReadLine();
                    dogList[id].Breed = breed;
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

    private void FoundDog(int id) /* Om hunden har hittats i sökfunktionen */
    {
        string input; 
        bool running = true;

        while(running == true)
        {
            Console.Write("What do you want to do with this dog? (use help for help, exit to exit): ");
            input = Console.ReadLine().ToLower();

            if(input == "help")
            {
                Console.WriteLine("###############");
                Console.WriteLine("edit");
                Console.WriteLine("remove");
                Console.WriteLine("exit");
                Console.WriteLine("###############");
            }

            else if(input == "remove")
            {
                dogList.Remove(dogList[id]);
                ProgramLoop();
            }

            else if(input == "edit")
                EditDog(id);

            else if(input == "exit")
            {
                running = false;
                ProgramLoop();
            }

            else
                Console.WriteLine("Error");
        }
    }


    private void Search()
    {
        int count = 0, g_i = 0;

        /* CHECK NAME */
        Console.Write("Name: ");
        string name = FirstCharToUpper(Console.ReadLine());

        for(int i = 0; i < dogList.Count; i++)
        {
            if(name == dogList[i].Name)
            {
                count++;
                g_i = i;
            }
        }
        if(count == 0)
        {
            Console.WriteLine("That dog does not exist");
            return;
        }
        if(count == 1)
            FoundDog(g_i);
        else
        {
            /* CHECK BREED */
            count = 0;
            Console.Write("There are multiple dogs with that name, specify by entering its breed: ");
            string breed = Console.ReadLine().ToLower();

            for(int i = 0; i < dogList.Count; i++)
            {
                if(name == dogList[i].Name && breed == dogList[i].Breed)
                {
                    count++;
                    g_i = i;
                }
            }
            if(count == 0)
            {
                Console.WriteLine("That dog does not exist");
                return;
            }
            if(count == 1)
                FoundDog(g_i);
            else
            {
                /* CHECK AGE */
                count = 0;
                TryInput("There are multiple dogs with that name, specify by entering its age: ", out double age);

                for(int i = 0; i < dogList.Count; i++)
                {
                    if(name == dogList[i].Name && breed == dogList[i].Breed && age == dogList[i].Age)
                    {
                        count++;
                        g_i = i;
                    }
                }
                if(count == 0)
                {
                    Console.WriteLine("That dog does not exist");
                    return;
                }
                if(count == 1)
                    FoundDog(g_i);
                else
                {
                    /* CHECK LENGTH */
                    count = 0;
                    TryInput("There are multiple dogs with that age, specify by entering its length: ", out double length);

                    for(int i = 0; i < dogList.Count; i++)
                    {
                        if(name == dogList[i].Name && breed == dogList[i].Breed && 
                        age == dogList[i].Age && length == dogList[i].Length)
                        {
                            count++;
                            g_i = i;
                        }
                    }
                    if(count == 0)
                    {
                        Console.WriteLine("That dog does not exist");
                        return;
                    }
                    if(count == 1)
                        FoundDog(g_i);
                    else
                    {
                        /* CHECK WITHERS */
                        count = 0;
                        TryInput("There are multiple dogs with that length, specify by entering its withers: ", out double withers);

                        for(int i = 0; i < dogList.Count; i++)
                        {
                            if(name == dogList[i].Name && breed == dogList[i].Breed && age == dogList[i].Age &&
                            length == dogList[i].Length && withers == dogList[i].Withers)
                            {
                                count++;
                                g_i = i;
                            }
                        }
                        if(count == 0)
                        {
                            Console.WriteLine("That dog does not exist");
                            return;
                        }
                        if(count == 1)
                            FoundDog(g_i);
                        else
                        {
                            /* CHECK WEIGHT */
                            count = 0;
                            TryInput("There are multiple dogs with that withers, specify by entering its weight: ", out double weight);

                            for(int i = 0; i < dogList.Count; i++)
                            {
                                if(name == dogList[i].Name && breed == dogList[i].Breed && age == dogList[i].Age && 
                                length == dogList[i].Length && withers == dogList[i].Withers && weight == dogList[i].Weight)
                                {
                                    count++;
                                    g_i = i;
                                }
                            }
                            if(count == 0)
                            {
                                Console.WriteLine("That dog does not exist");
                                return;
                            }
                            if(count == 1)
                                FoundDog(g_i);
                            else
                            {
                                /* CHECK GENDER */
                                count = 0;
                                Console.Write("There are multiple dogs with that name, specify by entering its breed: ");
                                string gender = Console.ReadLine().ToLower();

                                for(int i = 0; i < dogList.Count; i++)
                                {
                                     if(name == dogList[i].Name && breed == dogList[i].Breed && age == dogList[i].Age && 
                                     length == dogList[i].Length && withers == dogList[i].Withers && 
                                     weight == dogList[i].Weight && gender == dogList[i].Gender)
                                    {
                                        count++;
                                        g_i = i;
                                    }
                                }
                                if(count == 0)
                                {
                                    Console.WriteLine("That dog does not exist");
                                    return;
                                }
                                if(count == 1)
                                    FoundDog(g_i);
                            }
                        }
                    }
                }
            }
        }
    }
}