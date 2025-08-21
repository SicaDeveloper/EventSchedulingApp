using System.ComponentModel.DataAnnotations;

namespace HorizonCalender.ApiService.Controllers.Account.Dto;

public sealed record ResetPasswordRequestDto(
    [Required] [EmailAddress] string Email,
    [Required] string ResetCode,
    [Required] string NewPassword);