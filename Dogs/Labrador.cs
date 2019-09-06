class Labrador : Dog {

    private double tailLength;

    public Labrador(string  name, string gender, int age, double length,
    double withers, double weight, string breed) : base(name,  gender,  age,
    length, withers, weight, breed)
    {
        this.tailLength = GetTailLength();
    }

    public override double GetTailLength()
    {
        double tmp = this.age - this.length;
        if(tmp <= 8)
            return 8;
        else 
            return tmp;
    }

    public override string GetAsString(){
        return base.GetAsString() + GetTailLength() + "\n";
    }
}