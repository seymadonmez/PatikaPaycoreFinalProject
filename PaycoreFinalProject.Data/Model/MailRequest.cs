namespace PaycoreFinalProject.Data.Model
{
    //[Serializable]
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; } = "seymadonmezz1@gmail.com";
        public bool Status { get; set; }
    }
}
