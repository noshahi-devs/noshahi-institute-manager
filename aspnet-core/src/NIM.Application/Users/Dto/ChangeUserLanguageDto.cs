using System.ComponentModel.DataAnnotations;

namespace NIM.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}