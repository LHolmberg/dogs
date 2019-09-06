class Tax : Dog {

    private double tailLength;

    public Tax(string  name, string gender, int age, double length,
    double withers, double weight, string breed) : base(name,  gender,  age,
    length, withers, weight, breed)
    {
        this.tailLength = GetTailLength();
    }

    public override double GetTailLength()
    {
        return this.length / 4;
    }

    public override string GetAsString(){
        return base.GetAsString() + GetTailLength() + "\n";
    }

}