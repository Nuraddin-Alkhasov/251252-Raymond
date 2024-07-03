namespace HMI.Interfaces.PD
{
    interface IS
    {
        void OpenConnection();
        void CloseConnection();
        string GetStatus();
    }
}
