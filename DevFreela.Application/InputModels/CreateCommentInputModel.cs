namespace DevFreela.Application.InputModels
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IsUser { get; set; }
    }
}
