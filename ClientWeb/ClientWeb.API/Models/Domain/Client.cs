namespace ClientWeb.API.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }

        public string PatientId { get; set; }

        public string Name { get; set; }

        public double Age { get; set; }

        public string Sex { get; set; }

        public string Location { get; set; }

        public string SSN { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        //Navigation Property

        public IEnumerable<Clinician> Clinicians { get; set;}

    }
}
