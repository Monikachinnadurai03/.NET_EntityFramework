using System;
using System.Collections.Generic;

namespace IMS_DBFirst.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public string Occupation { get; set; } = null!;

    public string StreetName { get; set; } = null!;

    public int CityId { get; set; }

    public int StateId { get; set; }

    public string Country { get; set; } = null!;

    public string? PanCardNo { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }

    public virtual ClientCity City { get; set; } = null!;

    public virtual ICollection<ClientInvestment> ClientInvestments { get; set; } = new List<ClientInvestment>();

    public virtual ClientState State { get; set; } = null!;
}
