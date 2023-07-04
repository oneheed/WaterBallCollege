// Ignore Spelling: telecom

using CommandPattern.interfaces;
using CommandPattern.Models;

namespace CommandPattern.Commands
{
    internal class DisconnectTelecom : ICommand
    {
        private readonly Telecom _telecom;

        public DisconnectTelecom(Telecom telecom)
        {
            this._telecom = telecom;
        }

        public void Execute()
        {
            _telecom.Disconnect();
        }

        public void Undo()
        {
            _telecom.Connect();
        }

        public override string ToString()
        {
            return nameof(DisconnectTelecom);
        }
    }
}
