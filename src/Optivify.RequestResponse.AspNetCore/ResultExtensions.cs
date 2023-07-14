using Microsoft.AspNetCore.Mvc;
using Optivify.ServiceResult;
using System.Text;

namespace Optivify.RequestResponse;

public static class ResultExtensions
{
    public static string CombineErrorMessages(this IResult result)
    {
        var stringBuilder = new StringBuilder();

        foreach (string errorMessage in result.ErrorMessages)
        {
            stringBuilder.AppendLine(errorMessage);

            if (!errorMessage.EndsWith("."))
            {
                stringBuilder.Append('.');
            }
        }

        return stringBuilder.ToString();
    }

    public static ActionResult<T> ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        return controller.ToActionResult(result);
    }

    public static ActionResult<object> ToActionResult(this Result result, ControllerBase controller)
    {
        return controller.ToActionResult(result);
    }
}