namespace ConsidKompetens_Web.Communications
{
    public class JsonResponse
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public int TotalHits { get; set; }
        public int Page { get; set; }
    }
}
