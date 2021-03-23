using Domain.Enums;

namespace Domain.Entities
{
    public class Protocol : Base
    {
        public int ProtocolNumber { get; private set; }

        public ActionType ActionType { get; private set; }

        public Protocol(int protocolNumber, ActionType actionType)
        {
            ProtocolNumber = protocolNumber;
            ActionType = actionType;
        }
    }
}