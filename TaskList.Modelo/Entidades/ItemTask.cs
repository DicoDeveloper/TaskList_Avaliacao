using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskList.Modelo.Enumeradores;

namespace TaskList.Modelo.Entidades
{
    [Table("TASKS")]
    public class ItemTask
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ID"), Required]
        public long Id { get; set; }
        [Column("TIT_TSK")]
        public string Titulo { get; set; }
        [Column("STS_TSK")]
        public StatusTask Status { get; set; } = StatusTask.Normal;
    }
}
