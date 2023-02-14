namespace ClientWeb.API.Models.Domain
{
    public class Clinician
    {
        public Guid Id { get; set; }

        public string Name { get; set;}

        public string Sex { get; set;}

        public double Age { get; set; }

        public string Location { get; set; }


        public string SSN { get; set; }

        public Guid ClientId { get; set; }

        public Guid PayerId { get; set; }

        //Navigation Property

        public Client Client { get; set; }

        public Payer Payer { get; set; }


    }
}
