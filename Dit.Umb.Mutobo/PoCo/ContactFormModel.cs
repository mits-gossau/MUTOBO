using Dit.Umb.Mutobo.Configuration;

namespace Dit.Umb.Mutobo.PoCo
{
    public class ContactFormModel
    {
        
        public string LabelName { get; set; }
        public string LabelFirstName { get; set; }
        public string LabelAddress { get; set; }
        public string LabelZipCity { get; set; }
        public string LabelMail { get; set; }
        public string LabelPhone { get; set; }
        public string LabelMessage { get; set; }


        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string ZipCity { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        public bool? success = null;

        public string Gender { get; set; }
        public string Zip { get; set; }
        public string Place { get; set; }
        public bool Policy { get; set; }


        public MailConfiguration Customer { get; set; }
        public MailConfiguration Receiver { get; set; }

    }
}
