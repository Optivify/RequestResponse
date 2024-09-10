using Microsoft.AspNetCore.Mvc;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public static class ControllerExtensions
{
    public static ActionResult ToActionResult<T>(this ControllerBase controller, IResult<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => Success(controller, result),
            ResultStatus.Error => Error(controller, result),
            ResultStatus.Invalid => BadRequest(controller, result),
            ResultStatus.NotFound => NotFound(controller, result),
            ResultStatus.Unauthorized => Unauthorized(controller, result),
            ResultStatus.Forbidden => Forbidden(controller),
            _ => throw new NotSupportedException("The result status value is not supported.")
        };
    }

    private static ResultResponse CreateResultResponse<T>(IResult<T> result) =>
        new()
        {
            IsSuccess = result.IsSuccess,
            Message = result.IsSuccess ? result.SuccessMessage : result.ErrorMessage,
            ValidationErrors = result.ValidationErrors
        };

    private static Response<T> CreateResponse<T>(IResult<T> result) =>
        new()
        {
            Data = result.Value,
            IsSuccess = result.IsSuccess,
            Message = result.IsSuccess ? result.SuccessMessage : result.ErrorMessage,
            ValidationErrors = result.ValidationErrors
        };

    private static ActionResult Success<T>(ControllerBase controller, IResult<T> result)
    {
        switch (result.Value)
        {
            case IResponse<T>:
                return controller.Ok(CreateResponse(result));
            default:
                return controller.Ok(result.Value);
        }
    }

    private static ActionResult Error<T>(ControllerBase controller, IResult<T> result)
    {
        if (result.Value is IResultResponse)
        {
            return result.Value is IResponse<T> ?
                controller.UnprocessableEntity(CreateResponse(result)) :
                controller.UnprocessableEntity(result.Value);
        }

        return controller.UnprocessableEntity(CreateResultResponse(result));
    }

    private static ActionResult BadRequest<T>(ControllerBase controller, IResult<T> result)
    {
        if (result.Value is IResultResponse)
        {
            return result.Value is IResponse<T> ?
                controller.BadRequest(CreateResponse(result)) :
                controller.BadRequest(result.Value);
        }

        return controller.BadRequest(CreateResultResponse(result));
    }

    private static ActionResult NotFound<T>(ControllerBase controller, IResult<T> result) =>
        controller.NotFound(result.ErrorMessage);

    private static ActionResult Unauthorized<T>(ControllerBase controller, IResult<T> result) =>
        controller.Unauthorized(result.ErrorMessage);

    private static ActionResult Forbidden(ControllerBase controller) =>
        controller.Forbid();
}