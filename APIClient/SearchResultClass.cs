using System.Collections.Generic;

namespace APIClient
{
    public class SearchResultClass
    {
        public int Current_page { get; set; }
        public int Limit { get; set; }
        public int Next_page { get; set; }
        public int Previous_page { get; set; }
        public List<JokeClass> Results { get; set; }
        public string Search_term { get; set; }
        public int Status { get; set; }
        public int Total_jokes { get; set; }
        public int Total_pages { get; set; }
    }
}
