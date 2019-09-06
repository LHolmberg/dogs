class Pudel : Dog {

    private double tailLength;

    public Pudel(string  name, string gender, int age, double length,
    double withers, double weight, string breed) : base(name,  gender,  age,
    length, withers, weight, breed)
    {
        this.tailLength = GetTailLength();
    }

    public override double GetTailLength()
    {
        double tmp = this.length / this.withers;
        if(this.gender == "male")
            return tmp + 2;
        else
            return tmp;
    }
    
    public override string GetAsString(){
        return base.GetAsString() + GetTailLength() + "\n";
    }
}