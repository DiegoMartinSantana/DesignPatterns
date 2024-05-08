using System;
using System.Collections.Generic;

namespace PatronesDiseño.Models.Data;

public partial class ObrasSociale
{
    public int Idobrasocial { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Cobertura { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
