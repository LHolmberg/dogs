using System;

abstract class Dog : IComparable<Dog>
{
    protected string name, gender, breed;
    protected int age;
    protected double length, withers, weight;

    public Dog(string name, string gender, int age, double length,
    double withers, double weight, string breed)
    {
        this.name = name;
        this.gender = gender;
        this.age = age;
        this.length = length;
        this.withers = withers;
        this.weight = weight;
        this.breed = breed;
    }

    public virtual string GetAsString()
    {
        return "name: " + name + "\n" + "breed: " + breed + "\n" + "gender: " + gender + "\n" +
                "age: " + age + "\n" + "length: " + length + "\n" +
                "withers: " + withers + "\n" + "weigth: " + weight + "\n" + "tail length: ";
    }
    
    public abstract double GetTailLength();

    public int CompareTo(Dog obj)
    {
        return this.Name.CompareTo(obj.Name);
    }

    public string Name
    {
        get { return name; }
        set { this.name = value; }
    }
    public string Gender
    {
        get { return gender; }
        set { this.gender = value; }
    }
    public int Age
    {
        get { return age; }
        set { this.age = value; }
    }
    public double Length
    {
        get { return length; }
        set { this.length = value; }
    }
    public double Withers
    {
        get { return withers; }
        set { this.withers = value; }
    }
    public double Weigth
    {
        get { return weight; }
        set { this.weight = value; }
    }
    public string Breed
    {
        get { return breed; }
        set {this.breed = value;}
    }
}
