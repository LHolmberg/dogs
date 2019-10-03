/*
    Author: Lukas Holmberg
    Course: PRRPRR02
*/

class Poodle : Dog 
{

    public Poodle(string  name, string gender, int age, double length,
    double withers, double weight, string breed) : base(name,  gender,  age,
    length, withers, weight, breed)
    {}

    public override double GetTailLength()
    {
        double tailLength = length / withers;
        if(gender == "male")
            return tailLength + 2;
        else
            return tailLength;
    }
    
    public override string GetAsString()
    {
        return base.GetAsString() + GetTailLength() + "\n";
    }
}