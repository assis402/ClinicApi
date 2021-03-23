namespace Domain.Enums
{
    public enum ActionType
    {
        ScheduleAsUser = 0,
        RescheduleAsUser = 1,
        UndoScheduleAsUser = 2,
        MissedScheduling = 3,
        ScheduleAsClinicalUnit = 4,
        RescheduleAsClinicalUnit = 5,
        UndoScheduleAsClinicalUnit = 6
    }
}