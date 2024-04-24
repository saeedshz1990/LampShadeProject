namespace _0_FrameWork.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }

        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedded = true;
            Message = message;
            // "This " is mean return this class
            return this;

        }

        public OperationResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            // "This " is mean return this class
            return this;
        }
    }
}
