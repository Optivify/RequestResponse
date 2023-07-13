using Microsoft.AspNetCore.Mvc;
using Optivify.RequestResponse.Responses;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse.AspNetCore;

public static class ControllerExtensions
{
    public static ActionResult ToActionResult<T>(this ControllerBase controller, Result<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => Success(controller, result),
            ResultStatus.Error => Error(controller, result),
            ResultStatus.Invalid => BadRequest(controller, result),
            ResultStatus.NotFound => NotFound(controller, result),
            ResultStatus.Unauthorized => Unauthorized(controller, result),
            ResultStatus.Forbidden => Forbidden(controller),
            _ => throw new NotSupportedException("The result status value is not supported."),
        };
    }

    private static ResultResponse<T> CreateResultDataResponse<T>(Result<T> result)
    {
        return new ResultResponse<T>
        {
            Data = result.Value,
            IsSuccess = result.IsSuccess,
            ValidationErrors = result.ValidationErrors
        };
    }

    private static IValidationResponse? GetValidationResultResponse<T>(Result<T> result)
    {
        if (result.Value is IValidationResponse response)
        {
            response.IsSuccess = result.IsSuccess;
            response.ValidationErrors = result.ValidationErrors;

            return response;
        }

        return null;
    }

    private static ActionResult Success<T>(ControllerBase controller, Result<T> result)
    {
        var validationResultResponse = GetValidationResultResponse(result);

        if (validationResultResponse is null)
        {
            return controller.Ok(result.Value);
        }

        return controller.Ok(validationResultResponse);
    }

    private static ActionResult Error<T>(ControllerBase controller, Result<T> result)
    {
        var validationResultResponse = GetValidationResultResponse(result);

        if (validationResultResponse is null)
        {
            return controller.UnprocessableEntity(CreateResultDataResponse(result));
        }

        return controller.UnprocessableEntity(validationResultResponse);
    }

    private static ActionResult BadRequest<T>(ControllerBase controller, Result<T> result)
    {
        var validationResultResponse = GetValidationResultResponse(result);

        if (validationResultResponse is null)
        {
            return controller.BadRequest(CreateResultDataResponse(result));
        }

        return controller.BadRequest(validationResultResponse);
    }

    private static ActionResult NotFound<T>(ControllerBase controller, Result<T> result)
    {
        return controller.NotFound(result.CombineErrorMessages());
    }

    private static ActionResult Unauthorized<T>(ControllerBase controller, Result<T> result)
    {
        return controller.Unauthorized(result.CombineErrorMessages());
    }

    private static ActionResult Forbidden(ControllerBase controller)
    {
        return controller.Forbid();
    }
}