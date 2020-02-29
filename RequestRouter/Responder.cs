namespace RequestRouter
{
    public class Responder
    {
        public virtual Response GetResponse(Request request)
        {
            return new Response();
        }
    }
}
