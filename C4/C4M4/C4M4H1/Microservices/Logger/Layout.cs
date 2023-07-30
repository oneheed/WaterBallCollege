namespace Microservices.Logger
{
    internal interface ILayout
    {
        string Format(LevelType levelType, string name, string message);
    }
}