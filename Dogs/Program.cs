/*
    Author: Lukas Holmberg
    Course: PRRPRR02
*/

using System;
using System.Collections.Generic;

class Program
{
    private List<Dog> dogList = new List<Dog>();
    
    static void Main(string[] args)
    {
        Program program = new Program(); //skapar en instans för program klassen
        program.ProgramLoop();
    }

    private void ProgramLoop()
    {
        string input;
        while (true) //frågar användaren vad han/hon vill göra tills användaren väljer t.ex "add" eller "exit", om fel: felmeddelande
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
            try //Försök att parse användarens input till datatypen double
            {
                Console.Write(msg);
                age = double.Parse(Console.ReadLine());
                break;
            } 
            catch(Exception e) 
            {
                Console.WriteLine("{0} : Wrong format", e.GetType().Name); //felmeddelande
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
            Console.Write("What do you want to edit about the dog? (use exit to exit or help for help): ");
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
                    switch(breed) //Om breed ändras så måste objektet också ändras till det nya breedet
                    {
                        case "labrador":
                            dogList.Add(new Labrador(dogList[id].Name, dogList[id].Gender, 
                                                dogList[id].Age, dogList[id].Length, dogList[id].Withers,
                                                dogList[id].Weight, "labrador"));
                            dogList.Remove(dogList[id]);
                            id = dogList.Count - 1;
                            break;
                        case "dachshund":
                            dogList.Add(new Dachshund(dogList[id].Name, dogList[id].Gender, 
                                                dogList[id].Age, dogList[id].Length, dogList[id].Withers,
                                                dogList[id].Weight, "dachshund"));
                            dogList.Remove(dogList[id]);
                            id = dogList.Count - 1;
                            break;
                        case "poodle":
                            dogList.Add(new Poodle(dogList[id].Name, dogList[id].Gender, 
                                                dogList[id].Age, dogList[id].Length, dogList[id].Withers,
                                                dogList[id].Weight, "poodle"));
                            dogList.Remove(dogList[id]);
                            id = dogList.Count - 1;
                            break;
                        default:
                            Console.WriteLine("No info about that breed");
                            break;
                    }
                    break;
                case "exit":
                    running = false;
                    break;
                case "help":
                        Console.WriteLine("###############");
                        Console.WriteLine("changable properties: ");
                        Console.WriteLine("age");
                        Console.WriteLine("name");
                        Console.WriteLine("gender");
                        Console.WriteLine("length");
                        Console.WriteLine("withers");
                        Console.WriteLine("weight");
                        Console.WriteLine("breed");
                        Console.WriteLine("###############");
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
        Console.Write("Name: ");
        string name = FirstCharToUpper(Console.ReadLine());
        List<Dog> foundDogs = new List<Dog>();

        foreach(Dog dog in dogList) //Check for name
        {
            if(dog.Name == name) //kollar om användarens input är lika med en hunds namn i listan
            {
                foundDogs.Add(dog); //om en hund vars namn är användarens input så har en hund hittats
            }
        }
        if(foundDogs.Count >= 1) //om en eller flera hundar har hittats så kallas denna metod som sköter resten
            CheckFoundDogs(foundDogs.Count,"name", foundDogs[0]);
        else //annars så finns det inga hundar med det namnet
        {
            Console.WriteLine("There are no dogs by that name");
            return;
        }
        
        if(dogList.Count > 1) //Check for gender
        {
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            for(int i = foundDogs.Count - 1; i >= 0; i--) /* går backlänges igenom listan med de hittade hundarna
                                                                för att out of index errors */
            {
                if(foundDogs[i].Gender != gender)
                {
                    foundDogs.Remove(foundDogs[i]);
                }
            }
            if(foundDogs.Count >= 1) // Samma som innan
                CheckFoundDogs(foundDogs.Count,"gender", foundDogs[0]);
            else
            {
                Console.WriteLine("There are no dogs with that combination");
                return;
            }
        }
        
        if(dogList.Count > 1) //Check for age
        {
            TryInput("Age: ", out double age);
            for(int i = foundDogs.Count - 1; i >= 0; i--)
            {
                if(foundDogs[i].Age != age)
                    foundDogs.Remove(foundDogs[i]);
            }
            if(foundDogs.Count >= 1)
                CheckFoundDogs(foundDogs.Count,"age", foundDogs[0]);
            else
            {
                Console.WriteLine("There are no dogs with that combination");
                return;
            }
        }

        if(dogList.Count > 1) //Check for length
        {
            TryInput("Length: ", out double length);
            for(int i = foundDogs.Count - 1; i >= 0; i--)
            {
                if(foundDogs[i].Length != length)
                    foundDogs.Remove(foundDogs[i]);
            }
            if(foundDogs.Count >= 1)
                CheckFoundDogs(foundDogs.Count,"length", foundDogs[0]);
            else
            {
                Console.WriteLine("There are no dogs with that combination");
                return;
            }
        }

        if(dogList.Count > 1) //Check for withers
        {
            TryInput("Withers: ", out double withers);
            for(int i = foundDogs.Count - 1; i >= 0; i--)
            {
                if(foundDogs[i].Withers != withers)
                    foundDogs.Remove(foundDogs[i]);
            }
            if(foundDogs.Count >= 1)
                CheckFoundDogs(foundDogs.Count,"withers", foundDogs[0]);
            else
            {
                Console.WriteLine("There are no dogs with that combination");
                return;
            }
        }

        if(dogList.Count > 1) //Check for weight
        {
            TryInput("Weight: ", out double weight);
            for(int i = foundDogs.Count - 1; i >= 0; i--)
            {
                if(foundDogs[i].Weight != weight)
                    foundDogs.Remove(foundDogs[i]);
            }
            if(foundDogs.Count >= 1)
                CheckFoundDogs(foundDogs.Count,"weight", foundDogs[0]);
            else
            {
                Console.WriteLine("There are no dogs with that combination");
                return;
            }
        }

        if(dogList.Count > 1) //Check for breed
        {
            Console.Write("Breed: ");
            string breed = Console.ReadLine().ToLower();

            for(int i = foundDogs.Count - 1; i >= 0; i--)
            {
                if(foundDogs[i].Breed != breed)
                {
                    foundDogs.Remove(foundDogs[i]);
                }
            }
            if(foundDogs.Count >= 1)
                CheckFoundDogs(foundDogs.Count,"breed", foundDogs[0]);
            else
            {
                Console.WriteLine("There are no dogs with that combination");
                return;
            }
        }
    }

    void CheckFoundDogs(int length, string info, Dog dog)
    {
        if(length == 0)
        {
            Console.WriteLine("No dogs by that " + info);
            return;
        }
        else if(length == 1)
        {
           for(int i = 0; i < dogList.Count; i++)
           {
               if(dogList[i] == dog)
               {
                   FoundDog(i);
               }
           }
        }
        else if(length > 1)
            Console.WriteLine("There are multiple dogs with that " + info + ", Please specify");
    }
}