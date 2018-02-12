namespace FieldSupport.Domain.Maintenance
{
    public enum EngineerAvailStatus
    {
        Open,
        Close,
        Suspend
    }

    public enum TaskStatus
    {
        Pending = 10,
        InProgress = 20,
        Done = 30

    }

    public enum TicketState
    {
        New = 10,
        Pending = 11,
        InProgress = 20,
        ReOpen = 30,
        Transfer = 40,
        Escalate = 50,
        OnBehalf = 60,
        Expired = 70,
        Done = 100,
        Waiting = 110
    }
}
