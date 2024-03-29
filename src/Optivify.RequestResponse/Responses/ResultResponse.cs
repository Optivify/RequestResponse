﻿using Optivify.ServiceResult;

namespace Optivify.RequestResponse.Responses;

public class ResultResponse : IResultResponse
{
    public bool IsSuccess { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }
}
