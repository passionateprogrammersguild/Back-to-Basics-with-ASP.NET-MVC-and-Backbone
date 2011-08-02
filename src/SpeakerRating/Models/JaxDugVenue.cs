namespace SpeakerRating.Models
{
    public class JaxDugVenue : SpeakingVenue
    {
        public JaxDugVenue()
        {
            Name = "JAXDUG - Jacksonville Developer User Group";
            Address = "601 Riverside Ave";
            City = "Jacksonville";
            State = "Florida";
            Zip = 32204;
            Building = "1 - Tower";
            Room = "G01";
        }
    }

    public class ArchSIGVenue : SpeakingVenue
    {
        public ArchSIGVenue()
        {
            Name = "JAXARCHSIG - Jacksonville Architecture Special Interest Group";
            Address = "9000 Southside Blvd.";
            City = "Jacksonville";
            State = "Florida";
            Zip = 32256;
            Building = "500";
            Room = "TBD";
        }
    }
}