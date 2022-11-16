using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using rewriter.Shared.Common.Responses;
using rewriter.Shared.Common.Helpers;
using rewriter.Shared.Common.Validator;
using rewriter.OrderService.Models;
using FluentValidation;

namespace rewriter.api.Configuration
{
    public static class ValidationConfiguration
    {
        public static IMvcBuilder AddValidator(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var fieldErrors = new List<ErrorResponseFieldInfo>();
                    foreach (var item in context.ModelState)
                    {
                        if (item.Value.ValidationState == ModelValidationState.Invalid)
                            fieldErrors.Add(new ErrorResponseFieldInfo()
                            {
                                FieldName = item.Key,
                                Message = string.Join(", ", item.Value.Errors.Select(x => x.ErrorMessage))
                            });
                    }

                    var result = new BadRequestObjectResult(new ErrorResponse()
                    {
                        ErrorCode = -1,
                        Message = "One or more validation errors occurred.",
                        FieldErrors = fieldErrors
                    });

                    return result;
                };
            });

            builder.AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.ImplicitlyValidateChildProperties = true;
                fv.AutomaticValidationEnabled = true;
                fv.RegisterValidatorsFromAssemblyContaining<AddBookModelValidator>();
            });

            ValidatorsRegisterHelper.Register(builder.Services);
            // builder.Services.AddTransient<IModelValidator<Ad>
            builder.Services.AddSingleton<IValidator<AddOrderModel>, AddBookModelValidator>();
              builder.Services.AddSingleton(typeof(IModelValidator<>),typeof(ModelValidator<>));
            
            return builder;
        }
    }
}
