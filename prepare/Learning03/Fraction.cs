/* Class to make fractions, and my first foray into private settings.
*/

public class Fraction
{
    private double _top;
    private double _bottom;

    // make constructors, so it defaults to 1/1, x/1, or y/x

    public Fraction()
    {
        // default value behavior there
        _top = 1;
        _bottom = 1;
    }
    public Fraction(double topNumber)
    {
        // half default here
        _top = topNumber;
        _bottom = 1;
    }
    public Fraction(double topNumber, double bottomNumber)
    {
        // both values are set here
        _top = topNumber;
        _bottom = bottomNumber;
    }

    // next is getters and setters, which I probably understand the least
    // far as I can tell, getters indirectly collect data from the user by way of the parameter,
    // then return the info so it can be used in the class/object
    // setters are where the mutability of attributes goes, basically so the user can
    // change things with as little direct interaction as possible.

    // nvm I have that wrong, what is the point of getter? Just copy what's in here I guess

    // and setter is what takes a parameter that the user program can supply

    // OH nvm I get it, setter takes in the user value or whatever into the class, and
    // the getter pushes a result back out, so if say you wanted to put in a number and run
    // a calculation you make the object, call the setter and pass in a parameter, 
    // the class would internally do math, then the interface program must call the
    // getter to get the return. I think this is almost like if we wanted to make a function
    // that was pretty complicated and were worried the other code would mess some of it up
    // and if it's doing multiple steps it's easier to have the input and output be separate,
    // so you don't have to figure out how to get everything done super short
    public double GetTop()
    {
        return _top;
    }
    public void SetTop(double top)
    {
        _top = top;
    }
    public double GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(double bottom)
    {
        _bottom = bottom;
    }
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        double decValue = _top/_bottom;
        return decValue;
    }
}