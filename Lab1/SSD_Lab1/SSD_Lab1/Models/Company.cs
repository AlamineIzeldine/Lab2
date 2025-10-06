using System.ComponentModel.DataAnnotations;

public class Company
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, Range(0, 200)]
    [Display(Name = "Years in Business")]
    public int YearsInBusiness { get; set; }

    [Required, Url]
    public string Website { get; set; }

    [StringLength(50)]
    public string? Province { get; set; }
}
