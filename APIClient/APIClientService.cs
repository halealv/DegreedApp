using System.Linq;
using System.Text.RegularExpressions;

namespace APIClient
{
    public static class APIClientService
    {
        private const string _url = "https://icanhazdadjoke.com/";
        private const string _urlSearch = "https://icanhazdadjoke.com/search?";

        public static JokeClass GetRandomJoke()
        {
            JokeClass jokeClass = APIClient<JokeClass>.Get(_url);

            return jokeClass;
        }

        public static SearchResultClass GetListJoke(FilterClass filter)
        {
            filter.Limit = filter.Limit ?? Constants.Limit;

            var parameters = filter.GenerateQueryString();
            var url = _urlSearch + parameters;

            SearchResultClass listJoke = APIClient<SearchResultClass>.Get(url);

            listJoke.Results = listJoke.Results.OrderBy(x => x.Length).ToList();

            if (filter.Term != null)
                listJoke.Results.ForEach(x => { x.Joke = Regex.Replace(x.Joke, filter.Term, Constants.EmphasizedLeft + filter.Term + Constants.EmphasizedRight, RegexOptions.IgnoreCase); });

            return listJoke;
        }
    }
}
