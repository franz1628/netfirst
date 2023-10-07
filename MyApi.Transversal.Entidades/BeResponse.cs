namespace MyApi.Transversal.Entidades
{
    public class BeResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
    }

    public class BeResponse<T> : BeResponse
    {
        public T Data { get; set; }
    }
}
