using System.ComponentModel.DataAnnotations;

namespace WpfDesktopApp1;

public class AppSettings
{
    [Required(AllowEmptyStrings = false)]
    public string HubUrl { get; set; } = string.Empty;
}
