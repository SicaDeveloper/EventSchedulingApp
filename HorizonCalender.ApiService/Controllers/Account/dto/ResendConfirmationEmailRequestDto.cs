using System.ComponentModel.DataAnnotations;

namespace HorizonCalender.ApiService.Controllers.Account.Dto;

public sealed record ResendConfirmationEmailRequestDto(
    [Required] [EmailAddress] string Email);