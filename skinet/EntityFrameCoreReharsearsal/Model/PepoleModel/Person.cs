using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameCoreReharsearsal.Model.PepoleModel
{
    public class Person : BaseModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Adresses> Adresses { get; set; } = new List<Adresses>();
        public List<Email> Emails { get; set; } = new List<Email>();
    }
}
