namespace Modelo.Response
{
    public class GenericResponseDTO<T>
    {
        public bool Success { get; set; }
        public int HttpStatus { get; set; }
        public string? MessageResponse { get; set; }
        public T? Body { get; set; }
    }

}
