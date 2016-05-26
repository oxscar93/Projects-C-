

namespace ChatSystem.Common
{
    public class ContactMessage
    {
        //TODO: Refactor setters and getters
        public string _message;
        public string _emissorId;
        public string _receiveId;
        public string _emissorName;

        public ContactMessage()
        {
            
        }

        public ContactMessage(string id, string message)
        {
            _message = message;
            _emissorId = id;
        }

        public ContactMessage(string id, string receiveId, string message)
        {
            _message = message;
            _emissorId = id;
            _receiveId = receiveId;
        }

        public string GetMessage()
        {
            return _message;
        }

        public string GetEmissorId()
        {
            return _emissorId;
        }

        public void SetReceiveId(string id)
        {
            _receiveId = id;
        }

        public string GetReceiveId()
        {
            return _receiveId;
        }

        public void SetEmissorContactName(string name)
        {
            _emissorName = name;
        }

        public string GetEmissorContactName()
        {
            return _emissorName;
        }
    }
}
