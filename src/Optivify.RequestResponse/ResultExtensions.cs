using Microsoft.AspNetCore.Mvc;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public static class ResultExtensions
{
    public static ActionResult<T> ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        return controller.ToActionResult(result);
    }

    public static ActionResult<object> ToActionResult(this Result result, ControllerBase controller)
    {
        return controller.ToActionResult(result);
    }
}