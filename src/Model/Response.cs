using System;

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
        public string termsOfUse { get; set; }
        public DateTime registrationDate { get; set; }
    }

    public class Org
    {

    }

    public class Poc
    {

    }



}
