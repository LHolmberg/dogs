class Dog 
{
    public string name, gender, breed;
    public int age;
    public double length, withers, weight;
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
        this.tailLength = CalculateTailLength();
    }

    private double CalculateTailLength()
    {
        switch(this.breed)
        {
        case "tax":
            this.tailLength = this.length / 4;
            break;
        case "labrador":
            if (this.gender == "male")
            {
                this.tailLength = this.length - this.withers + 2;
            }
            else if (this.gender == "female")
            {
                this.tailLength = this.length - this.withers;
            }
            break;
        case "pudel":
            double res = this.age - this.length; 
            if(res < 8)
                this.tailLength = 8;
            else
                this.tailLength = res;
            break;
        default:
            this.tailLength = 0;
            break;
        }
        return this.tailLength;
    }

    public string GetAsString()
    {
        return "name: " + name + "\n" + "gender: " + gender + "\n" + 
                "age: " + age + "\n" + "length: " + length + "\n" +
                "withers: " + withers + "\n" + "weigth: " + weight + "\n" +
                "breed: " + breed + "\n" + "tail length: " + tailLength + "\n";
    }
}
