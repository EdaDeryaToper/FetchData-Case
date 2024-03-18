namespace BackendCase.ExceptionHandler
{
    public static class ExceptionMessages
    {
        public static readonly string NotFound = "Not found";
        public static readonly string TooManyRequests = "Too many requests. Please try again later.";
        public static readonly string BadRequests = "NO_SLOT_FOUND";
        public static readonly string InternalServerError = $"{500} an error occured";
    }
}
