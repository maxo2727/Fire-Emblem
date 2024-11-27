namespace Fire_Emblem_Models.Exceptions;

public class NoFollowUpForAttackerException : NoFollowUpForAllUnitsException
{
    public override bool IsDefenderCounterDenied { get; set; } = true;
}