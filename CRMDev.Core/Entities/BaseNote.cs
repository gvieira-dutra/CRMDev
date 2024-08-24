namespace CRMDev.Core.Entities
{
    public class BaseNote : BaseClass
    {
        protected BaseNote(string content)
        {
            Content = content;
        }
        public BaseNote() {}
        public string Content { get; private set; }

        public void EditNoteContent(string newContent)
        {
            Content = string.IsNullOrEmpty(newContent) ? Content : newContent;
        }
    }
}
