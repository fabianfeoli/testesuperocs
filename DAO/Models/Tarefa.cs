using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSuperoCS.DAO.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        public string TituloTarefa { get; set; }
        public string DsTarefa { get; set; }

        public StatusTarefa StatusTarefa { get; set; }
        public DateTime DtDeadline { get; set; }
        public DateTime DtCriacaoTarefa { get; set; } = DateTime.UtcNow;
        public DateTime DtAlteracaoTarefa { get; set; }
        public DateTime DtConclusaoTarefa { get; set; }
        public DateTime DtExclusaoTarefa { get; set; }
    }
}
