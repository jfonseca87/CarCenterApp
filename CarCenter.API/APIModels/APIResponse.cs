namespace CarCenter.API.APIModels
{
    public class APIResponse<T>
    {
        public int ResponseNumber { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
