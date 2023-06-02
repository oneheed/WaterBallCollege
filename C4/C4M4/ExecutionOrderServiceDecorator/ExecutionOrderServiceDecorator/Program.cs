// 定義 Component 介面
interface IComponent
{
    void Operation();
}

// 定義 ConcreteComponent
class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("ConcreteComponent.Operation()");
    }
}

// 定義 Decorator 類別
abstract class Decorator : IComponent
{
    private readonly IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }

    public virtual void Operation()
    {
        _component.Operation();
    }
}

// 定義 ConcreteDecoratorA
class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("ConcreteDecoratorA.Operation()");
        base.Operation();
    }
}

// 定義 ConcreteDecoratorB
class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("ConcreteDecoratorB.Operation()");
        base.Operation();
    }
}

// 定義 ConcreteDecoratorC
class ConcreteDecoratorC : Decorator
{
    public ConcreteDecoratorC(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("ConcreteDecoratorC.Operation()");
        base.Operation();
    }
}

// 客戶端程式碼
class Client
{
    static void Main()
    {
        // 按照 A -> B -> C 的順序執行
        IComponent component1 = new ConcreteDecoratorC(new ConcreteDecoratorB(new ConcreteDecoratorA(new ConcreteComponent())));
        component1.Operation();

        // 按照 B -> A -> C 的順序執行
        IComponent component2 = new ConcreteDecoratorC(new ConcreteDecoratorA(new ConcreteDecoratorB(new ConcreteComponent())));
        component2.Operation();

        // 按照 C -> B -> A 的順序執行
        IComponent component3 = new ConcreteDecoratorB(new ConcreteDecoratorA(new ConcreteDecoratorC(new ConcreteComponent())));
        component3.Operation();

        // 按照 C -> A -> B 的順序執行
        IComponent component4 = new ConcreteDecoratorB(new ConcreteDecoratorC(new ConcreteDecoratorA(new ConcreteComponent())));
        component4.Operation();
    }
}
