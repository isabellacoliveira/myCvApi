using System.ComponentModel.DataAnnotations;

namespace myCvApi.Models
{
    public class Formacao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da linguagem é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Local é obrigatório.")]
        public string Local { get; set; }
        [Required(ErrorMessage = "O período é obrigatório.")]
        public string Periodo { get; set; }
        [Required(ErrorMessage = "A URL da imagem é obrigatória.")]
        public string Imagem { get; set; }
    }
}