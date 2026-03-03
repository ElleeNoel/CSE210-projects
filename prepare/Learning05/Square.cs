public class Square : Shape
{
    private double _sidelength;
    public Square(string color, double sidelength) : base(color)
    {
        _sidelength = sidelength;
    }
    public override double GetArea()
    {
        return _sidelength*_sidelength;
    }
}