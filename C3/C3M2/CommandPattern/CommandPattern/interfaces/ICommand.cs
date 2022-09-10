namespace CommandPattern.interfaces
{
    internal interface ICommand
    {
        void Execute();

        void Undo();
    }
}
