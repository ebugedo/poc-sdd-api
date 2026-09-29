using System.Collections.Generic;

namespace Poc.SDD.Domain.Shared;

public class Result
{
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; } = new();

    public static Result Success() => new() { IsSuccess = true };
    public static Result Failure(List<string> errors) => new() { IsSuccess = false, Errors = errors };
}