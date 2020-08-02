namespace EntityFrameCoreReharsearsal.Model.PepoleModel
{
    public class Email :BaseModel
    {
        public string EmailAddress { get; set; }
        public Person Person { get; set; }
    }
}