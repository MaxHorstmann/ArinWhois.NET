namespace ArinWhois.Model
{
    public class Response
    {
        public Net net { get; set; }
        public Org org { get; set; }
        public Poc poc { get; set; }
    }

    public class Net
    {
        public object registrationDate { get; set; }
    }

    public class Org
    {

    }

    public class Poc
    {

    }



}
