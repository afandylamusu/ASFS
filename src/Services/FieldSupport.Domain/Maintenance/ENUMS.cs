namespace FieldSupport.Domain.Maintenance
{
    public enum EngineerAvailStatus
    {
    }

    public enum TaskStatus
    {

    }

    public enum TicketState
    {
        New = 10,
        Open = 20,
        ReOpen = 30,
        Transfer = 40,
        Escalate = 50,
        OnBehalf = 60,
        Expired = 70,
        Done = 100
    }
}
