// Ignore Spelling: Telecom

using CommandPattern.interfaces;
using CommandPattern.Models;

namespace CommandPattern.Commands
{
    internal class ConnectTelecom : ICommand
    {
        private readonly Telecom _telecom;

        public ConnectTelecom(Telecom telecom)
        {
            this._telecom = telecom;
        }

        public void Execute()
        {
            _telecom.Connect();
        }

        public void Undo()
        {
            _telecom.Disconnect();
        }

        public override string ToString()
        {
            return nameof(ConnectTelecom);
        }
    }
}
