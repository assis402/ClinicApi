using System.Collections.Generic;
using Presentation.Utils.JsonModels.Models;

namespace Presentation.Utils
{
    public class Responses
    {
        public static ResultJson SuccessMessage(string message)
        {
            return new ResultJson
            {
                Message = message,
                Success = true,
                Data = null
            };
        }
        
        public static ResultJson SuccessMessage(dynamic data)
        {
            return new ResultJson
            {
                Message = null,
                Success = true,
                Data = data
            };
        }

        public static ResultJson SuccessMessage(string message, dynamic data)
        {
            return new ResultJson
            {
                Message = message,
                Success = true,
                Data = data
            };
        }

        public static ResultJson ApplicationErrorMessage()
        {
            return new ResultJson
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Success = false,
                Data = null
            };
        }

        public static ResultJson ErrorMessage(string message)
        {
            return new ResultJson
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultJson ErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultJson
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static ResultJson UnauthorizedErrorMessage()
        {
            return new ResultJson
            {
                Message = "A combinação de login e senha está incorreta!",
                Success = false,
                Data = null
            };
        }
    }
}