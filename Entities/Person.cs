namespace GymSphere.Entities;

public abstract class Person : BaseEntity
{
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
}