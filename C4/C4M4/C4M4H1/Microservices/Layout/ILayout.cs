using Microservices.Logger;

namespace Microservices.Layout
{
    internal interface ILayout
    {
        string Format(LevelType levelType, string name, string message);
    }
}