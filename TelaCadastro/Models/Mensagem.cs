using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TelaCadastro.Models
{
    [Table ("mensagem", Schema = "public")]
    public class Mensa
    {
        [Key]
        public int id { get; set; }
        public int cadastroid { get; set; }

        public string mensagem { get; set; }

    }
}
