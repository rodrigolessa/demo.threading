using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.THR.Dominio.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataDeInclusao { get; set; }
        public Nullable<DateTime> DataDeAlteracao { get; set; }
    }
}
