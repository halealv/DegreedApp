namespace APIClient
{
    public class JokeClass
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public int Status { get; set; }

        public int Length
        {
            get
            {
                var split = Joke.Split(' ');
                return split.Length;
            }
        }

        public string LengthValue
        {
            get
            {
                if (Length < 10)
                    return Constants.Short;
                else if (Length < 20)
                    return Constants.Medium;
                else
                    return Constants.Long;
            }
        }
    }
}
