/*
    Author: Lukas Holmberg
    Course: PRRPRR02
*/

class Labrador : Dog 
{

    public Labrador(string  name, string gender, int age, double length,
    double withers, double weight, string breed) : base(name,  gender,  age,
    length, withers, weight, breed)
    {}

    public override double GetTailLength()
    {
        double tailLength = age - length;
        if(tailLength <= 8)
            return 8;
        else 
            return tailLength;
    }

    public override string GetAsString()
    {
        return base.GetAsString() + GetTailLength() + "\n";
    }
}