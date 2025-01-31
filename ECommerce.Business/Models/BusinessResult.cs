namespace E_Commerce.Business.Models
{
    public class BusinessResult
    {
        public bool IsSuccess { get; set; }
        public BusinessError? Error { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }

        protected BusinessResult(bool isSuccess, BusinessError? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        private BusinessResult(bool isSuccess, BusinessError? error, string userWishList)
        {
            IsSuccess = isSuccess;
            Error = error;
            Token = userWishList;
        }

        public static BusinessResult<Clients> FromError(string errorMessage, BusinessError? reason)
        {
            BusinessError error = new(errorMessage, reason);
            return new BusinessResult<Clients>(false, error);
        }

        public static BusinessResult FromSuccess(BusinessResult<Achats> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(BusinessResult<Admin> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(BusinessResult<Produit> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult<Clients> FromSuccess(BusinessResult<Clients> businessResult)
        {
            return new BusinessResult<Clients>(true, null, businessResult.Result);
        }

        public static BusinessResult FromError(string registrationResultMessage, BusinessError? registrationResultError,
            string userToken)
        {
            return new BusinessResult(false, registrationResultError);
        }

        public static BusinessResult FromError(string productAlreadyInWishlist)
        {
            return new BusinessResult(false, null);
        }

        public static BusinessResult FromSuccess(List<Produit> userWishList)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(BusinessResult<string> userWishList)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(string userWishList)
        {
            return new BusinessResult(true, null, userWishList);
        }

        public static BusinessResult<Clients> FromSuccess(Clients userWishList)
        {
            return new BusinessResult<Clients>(true, null, userWishList);
        }

        public static BusinessResult FromSuccess()
        {
            return new BusinessResult(true, null);
        }
    }

    public class BusinessResult<T> : BusinessResult
    {
        public T Result { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }

        public BusinessResult(bool isSuccess, BusinessError? error, T? result = default) : base(isSuccess, error)
        {
            Result = result;
        }

        public BusinessResult() : base(false, null)
        {
            IsSuccess = false;
            Message = string.Empty;
            Token = string.Empty;
        }

        public static BusinessResult<T> FromSuccess(T result)
        {
            return new BusinessResult<T>(true, null, result);
        }

        public static BusinessResult<T> FromError(string errorMessage, BusinessError? reason, T? result = default)
        {
            BusinessError error = new(errorMessage, reason);
            return new BusinessResult<T>(false, error, result);
        }

        public static BusinessResult<Achats> FromSuccess(Achats updatedUser)
        {
            return new BusinessResult<Achats>(true, null, updatedUser);
        }

        public static BusinessResult<Admin> FromSuccess(Admin updatedTask)
        {
            return new BusinessResult<Admin>(true, null, updatedTask);
        }

       
        
        public static BusinessResult<Clients> FromSuccess(Clients businessResult)
        {
            return new BusinessResult<Clients>(true, null, businessResult);
        }
        
        public static BusinessResult<Produit> FromSuccess(Produit businessResult)
        {
            return new BusinessResult<Produit>(true, null, businessResult);
        }

        
    }

    public class BusinessError
    {
        public string ErrorMessage { get; set; }

        public BusinessError? Reason { get; set; }

        public BusinessError(string errorMessage, BusinessError? reason)
        {
            ErrorMessage = errorMessage;
            Reason = reason;
        }
    }
    public enum BusinessErrorReason
    {
        BusinessRule = 400,
        NotFound = 404, 
        InvalidCredentials,
    }
}