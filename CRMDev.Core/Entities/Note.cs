namespace CRMDev.Core.Entities
{
    public class Note(string content) : BaseClass
    {
        public string Content { get; private set; } = content;
    }
}
