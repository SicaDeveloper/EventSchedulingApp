using System.ComponentModel.DataAnnotations;

namespace HorizonCalender.ApiService.Controllers.Account.Dto;

public sealed record LoginRequestDto(
    [Required] [EmailAddress] string Email,
    string Password);