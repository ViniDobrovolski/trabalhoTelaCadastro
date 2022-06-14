using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TelaCadastro.Models
{
    [Table("endereco", Schema = "public")]
    public class Ender
    {
        [Key]
        public int id { get; set; }
        public int cadastroid { get; set; }

        public string rua { get; set; }
        public int numero { get; set; }
        public string cep { get; set; }
        public string cidade    { get; set; }
        public string estado { get; set; }

    }
}
