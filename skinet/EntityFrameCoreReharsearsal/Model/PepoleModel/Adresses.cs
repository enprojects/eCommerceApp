namespace EntityFrameCoreReharsearsal.Model.PepoleModel
{
    public class Adresses :BaseModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Person Person { get; set; }
    }
}