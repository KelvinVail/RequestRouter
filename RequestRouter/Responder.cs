namespace RequestRouter
{
    public class Responder
    {
        public virtual Response GetResponse(RealRequest realRequest)
        {
            return new Response();
        }
    }
}
