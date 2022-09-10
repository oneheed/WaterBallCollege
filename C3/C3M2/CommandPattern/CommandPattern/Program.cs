// See https://aka.ms/new-console-template for more information
using CommandPattern;
using CommandPattern.Commands;
using CommandPattern.interfaces;

var mainController = new MainController();

var commands = new List<ICommand>
{
    new MoveTankForward(new ()),
    new MoveTankBackward(new ()),
    new ConnectTelecom(new()),
    new DisconnectTelecom(new()),
    new ResetMainControlKeyboard(mainController),
};

mainController.SetCommands(commands);


while (true)
{
    mainController.Action();
}