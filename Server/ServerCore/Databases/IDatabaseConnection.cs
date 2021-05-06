namespace ServerAspNetCoreLinux.ServerCore.Databases
{
    public interface IDatabaseConnection
    {
        void OpenConnect();
        void CloseConnect();
    }
}