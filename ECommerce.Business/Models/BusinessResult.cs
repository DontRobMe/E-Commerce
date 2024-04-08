﻿namespace E_Commerce.Busines.Models
{
    public class BusinessResult
    {
        public bool IsSuccess { get; set; }
        public BusinessError? Error { get; set; }

        public BusinessResult()
        {
        }

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

        public static BusinessResult FromSuccess(BusinessResult<Client> businessResult)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess(BusinessResult<Site> existingProject)
        {
            return new BusinessResult(true, null);
        }

        public static BusinessResult FromSuccess()
        {
            return new BusinessResult(true, null);
        }
    }

    public class BusinessResult<T> : BusinessResult // Hérite du résultat sans retour
    {
        public T? Result { get; set; }

        public BusinessResult(bool isSuccess, BusinessError? error, T? result = default) : base(isSuccess, error)
        {
            Result = result;
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
        
        public static BusinessResult<Client> FromSuccess(Client businessResult)
        {
            return new BusinessResult<Client>(true, null, businessResult);
        }
        
        public static BusinessResult<Produit> FromSuccess(Produit businessResult)
        {
            return new BusinessResult<Produit>(true, null, businessResult);
        }

        public static BusinessResult<T> FromError(string leProjetNExistePas)
        {
            return BusinessResult<T>.FromError(leProjetNExistePas, BusinessErrorReason.NotFound);
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