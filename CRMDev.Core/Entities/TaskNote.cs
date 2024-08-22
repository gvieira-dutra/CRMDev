namespace CRMDev.Core.Entities
{
    public class TaskNote(Task task, string content) : BaseNote(content)
    {
        public int TaskId { get; private set; } = task.Id;
    }
}
