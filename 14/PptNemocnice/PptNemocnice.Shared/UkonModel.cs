using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PptNemocnice.Shared;

public class UkonModel
{
    public Guid Id { get; set; }
    public string Detail { get; set; } = "";
    public string Kod { get; set; } = "";
    public DateTime DateTime { get; set; } = DateTime.Now;
    public Guid VybaveniId { get; set; }
    public string PracovnikName { get; set; } = "";
}
