using System;
using System.Collections.Generic;

namespace IMS_DBFirst.Models;

public partial class ClientCity
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
