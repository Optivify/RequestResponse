using Microsoft.AspNetCore.Mvc;
using Optivify.RequestResponse.Responses;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

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

    private static ResultResponse CreateResultResponse<T>(Result<T> result)
    {
        return new ResultResponse
        {
            IsSuccess = result.IsSuccess,
            ValidationErrors = result.ValidationErrors
        };
    }

    private static DataResultResponse<T> CreateDataResultResponse<T>(Result<T> result)
    {
        return new DataResultResponse<T>
        {
            Data = result.Value,
            IsSuccess = result.IsSuccess,
            ValidationErrors = result.ValidationErrors
        };
    }

    private static ActionResult Success<T>(ControllerBase controller, Result<T> result)
    {
        if (result.Value is IResultResponse response)
        {
            response.IsSuccess = result.IsSuccess;
            response.ValidationErrors = result.ValidationErrors;

            if (result.Value is IDataResultResponse<T>)
            {
                return controller.Ok(CreateDataResultResponse(result));
            }
            else
            {
                controller.Ok(CreateResultResponse(result));
            }
        }

        return controller.Ok(result.Value);
    }

    private static ActionResult Error<T>(ControllerBase controller, Result<T> result)
    {
        if (result.Value is IResultResponse response)
        {
            response.IsSuccess = result.IsSuccess;
            response.ValidationErrors = result.ValidationErrors;

            if (result.Value is IDataResultResponse<T>)
            {
                return controller.UnprocessableEntity(CreateDataResultResponse(result));
            }
            else
            {
                controller.UnprocessableEntity(CreateResultResponse(result));
            }
        }

        return controller.UnprocessableEntity(result.Value);
    }

    private static ActionResult BadRequest<T>(ControllerBase controller, Result<T> result)
    {
        if (result.Value is IResultResponse response)
        {
            response.IsSuccess = result.IsSuccess;
            response.ValidationErrors = result.ValidationErrors;

            if (result.Value is IDataResultResponse<T>)
            {
                return controller.BadRequest(CreateDataResultResponse(result));
            }
        }

        return controller.BadRequest(CreateResultResponse(result));
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