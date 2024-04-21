namespace Task.Business.Results
{
    public class ServiceResult
    {
        public object goodsTree { get; }
        public string Message { get; }
        public bool Success { get; }

        public ServiceResult(bool success, object data, string message)
        {
            goodsTree = data;
            Success = success;
            Message = message;

        }

        public ServiceResult(bool success, string message)
        {
            goodsTree = null;
            Success = success;
            Message = message;
        }

        public ServiceResult(bool success, object data)
        {
            goodsTree = data;
            Success = success;
            Message = "";
        }

        public ServiceResult(bool success)
        {
            goodsTree = null;
            Success = success;
            Message = "";
        }
    }
}