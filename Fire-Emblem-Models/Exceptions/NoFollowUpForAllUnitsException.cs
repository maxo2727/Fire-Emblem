namespace Fire_Emblem_Models.Exceptions;

public class NoFollowUpForAllUnitsException : Exception
{
    public virtual bool IsDefenderCounterDenied { get; set; } = false;
}