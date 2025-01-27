namespace BoostyLib.Entities.Helpers;

public abstract class AbstractJsonHolder
{
    public abstract void ReadFromString(string value);

    public abstract string WriteToString();
}