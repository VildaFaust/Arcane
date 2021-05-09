namespace Server.ServerCore.Databases.Connect
{
    public interface IDatabaseConnection
    {
        void OpenConnect();
        void CloseConnect();
        bool IsConnected { get; set; }
    }
}