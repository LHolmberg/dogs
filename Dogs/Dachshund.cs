class Dachshund : Dog 
{

    public Dachshund(string  name, string gender, int age, double length,
    double withers, double weight, string breed) : base(name,  gender,  age,
    length, withers, weight, breed)
    {}

    public override double GetTailLength()
    {
        return length / 4;
    }

    public override string GetAsString(){
        return base.GetAsString() + GetTailLength() + "\n";
    }

}