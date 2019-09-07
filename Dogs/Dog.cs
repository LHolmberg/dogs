abstract class Dog
{
    protected string name, gender, breed;
    protected int age;
    protected double length, withers, weight;
    private double tailLength;

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
        this.tailLength = 0;
    }
    public virtual string GetAsString()
    {
        return "name: " + name + "\n" + "gender: " + gender + "\n" +
                "age: " + age + "\n" + "length: " + length + "\n" +
                "withers: " + withers + "\n" + "weigth: " + weight + "\n" +
                "breed: " + breed + "\n" + "tail length: ";
    }
    public abstract double GetTailLength();

    public string Name
    {
        get { return name; }
    }
    public string Gender
    {
        get { return gender; }
    }
    public int Age
    {
        get { return age; }
    }
    public double Length
    {
        get { return length; }
    }
    public double Withers
    {
        get { return withers; }
    }
    public double Weigth
    {
        get { return weight; }
    }
    public string Breed
    {
        get { return breed; }
    }
}
