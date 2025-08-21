using System.ComponentModel.DataAnnotations;
using HorizonCalender.Data.Enum;

namespace HorizonCalender.ApiService.Controllers.Event.Dto;

public sealed record UpdateEventRequestDto(
    [Required]
    [MaxLength(Data.Entities.Event.MaxTitleCharacters)]
    string Title,
    [MaxLength(Data.Entities.Event.MaxDescriptionCharacters)]
    string? Description,
    [Required] DateTime StartTime,
    [Required] DateTime EndTime,
    [Required] LocationType LocationType,
    [Required]
    [MaxLength(Data.Entities.Event.MaxLocationCharacters)]
    string Location,
    [Required] bool ShowAttendees
);