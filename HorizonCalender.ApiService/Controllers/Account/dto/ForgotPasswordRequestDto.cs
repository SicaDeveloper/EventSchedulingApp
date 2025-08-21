using System.ComponentModel.DataAnnotations;

namespace HorizonCalender.ApiService.Controllers.Account.Dto;

public sealed record ForgotPasswordRequestDto(
    [Required] [EmailAddress] string Email);