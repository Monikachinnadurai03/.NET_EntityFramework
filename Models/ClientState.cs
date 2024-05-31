﻿using System;
using System.Collections.Generic;

namespace IMS_DBFirst.Models;

public partial class ClientState
{
    public int StateId { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}