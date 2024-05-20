namespace E_Commerce.Business.Models
{
    public class BusinessResult
    {
        public bool IsSuccess { get; set; }
        public BusinessError? Error { get; set; }

        protected BusinessResult(bool isSuccess, BusinessError? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static BusinessResult FromError(string errorMessage, BusinessErrorReason reason)
        {
            BusinessError error = new(errorMessage, reason);
            return new BusinessResult(false, error);
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

        public static BusinessResult FromSuccess(BusinessResult<Site> existingProject)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess()
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromError(string registrationResultMessage, BusinessError? registrationResultError)
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
    }

    public class BusinessResult<T> : BusinessResult // Hérite du résultat sans retour
    {
        public T? Result { get; set; }
        public string Message { get; set; }

        public BusinessResult(bool isSuccess, BusinessError? error, T? result = default) : base(isSuccess, error)
        {
            Result = result;
        }

        public BusinessResult() : base(false, null)
        {
            IsSuccess = false;
            Message = string.Empty;
            
        }

        public static BusinessResult<T> FromSuccess(T? result)
        {
            return new BusinessResult<T>(true, null, result);
        }

        public static BusinessResult<T> FromError(string errorMessage, BusinessErrorReason reason, T? result = default)
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

        public static BusinessResult<Site> FromSuccess(Site businessResult)
        {
            return new BusinessResult<Site>(true, null, businessResult);
        }
        
        public static BusinessResult<Clients> FromSuccess(Clients businessResult)
        {
            return new BusinessResult<Clients>(true, null, businessResult);
        }
        
        public static BusinessResult<Produit> FromSuccess(Produit businessResult)
        {
            return new BusinessResult<Produit>(true, null, businessResult);
        }

        public static BusinessResult<T> FromError(string leProjetNExistePas)
        {
            return BusinessResult<T>.FromError(leProjetNExistePas, BusinessErrorReason.NotFound);
        }

        public static BusinessResult<Achats> Success(Achats achat)
        {
            throw new NotImplementedException();
        }

        public static BusinessResult<Achats> Failure(string achatNotFound)
        {
            throw new NotImplementedException();
        }
    }

    // Erreur métier (cas géré et attendu)
    public class BusinessError
    {
        // Message de l'erreur
        public string ErrorMessage { get; set; }

        // Cause de l'erreur, utile pour déterminer le statut http
        public BusinessErrorReason Reason { get; set; }

        public BusinessError(string errorMessage, BusinessErrorReason reason)
        {
            ErrorMessage = errorMessage;
            Reason = reason;
        }
    }

    // Causes possibles d'une erreur métier
    // La liste peut être augmentée au fil du développement
    public enum BusinessErrorReason
    {
        BusinessRule = 400,
        NotFound = 404,
    }
}