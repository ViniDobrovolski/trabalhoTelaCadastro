using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TelaCadastro.Models
{
    [Table("telacadastro", Schema = "public")]
    public class TelaCad { 
        [Key]
        public int id { get; set; }
        public string nome { get; set; }   
        public string email { get; set; }  
        public string senha { get; set; }

        public DateOnly datanascimento { get; set; }
        public char genero { get; set; }
        
    }
}
