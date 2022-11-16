using FluentValidation.Results;
using rewriter.Shared.Common.Responses;
namespace rewriter.Shared.Common.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// make error response from validationresult
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ErrorResponse toErrorresponse(this ValidationResult data)
        {
            var res = new ErrorResponse()
            {
                Message = "",
                FieldErrors = data.Errors.Select(x =>
                {
                    var elems = x.ErrorMessage.Split('&');
                    var errorname = elems[0];
                    var errorMessage = elems.Length > 0 ? elems[1] : errorname;
                    return new ErrorResponseFieldInfo()
                    {
                        FieldName = x.PropertyName,
                        Message = errorMessage,
                    };
                })
            }; 

            return res;
        }

        /// <summary>
        /// convert process exception to errorresponse
        /// </summary>
        /// <param name="data">process exception</param>
        /// <returns></returns>
        //public static errorresponse toerrorresponse(this processexception data)
        //{
        //    var res = new errorresponse()
        //    {
        //        message = data.message
        //    };

        //    return res;
        //}

        /// <summary>
        /// convert exception to errorresponse
        /// </summary>
        /// <param name="data">exception</param>
        /// <returns></returns>
        public static ErrorResponse ToErrorResponse(this Exception data)
        {
            var res = new ErrorResponse()
            {
                ErrorCode = -1,
                Message = data.Message
            };

            return res;
        }
    }
}
