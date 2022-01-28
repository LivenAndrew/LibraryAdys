using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp
{
    class Person
    {
        public string ID_Customer { get; set; }
        public string C_LastName { get; set; }
        public string C_FirstName { get; set; }
        public string Date_of_birth{ get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAdress { get; set; }

        public virtual IdCollection<ReaderBook> ReaderBook { get; set; }
        public string ID { get; internal set; }
        public string Name { get; internal set; }
        public string Login { get; internal set; }

        internal string password;
    }
}
