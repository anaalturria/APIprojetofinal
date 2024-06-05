using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Api.Models
{
    public class PessoasModel
    {
        public int PessoaId { get; set; }

        public string PessoaNome { get; set; } = string.Empty;

        public string PessoaRoupa { get; set; } = string.Empty;

        public string PessoaCor { get; set; } = string.Empty;

        public string PessoaSexo { get; set; } = string.Empty;

        public string PessoaObservacao { get; set; } = string.Empty;

        public string PessoaLocalDesaparecimento { get; set; } = string.Empty;

        public string PessoaFoto { get; set; } = string.Empty;

        public DateTime PessoaDtDesaparecimento { get; set; }

        public string? PessoaDtEncontro { get; set; }

        public byte PessoaStatus { get; set; }

        public int UsuarioId { get; set; }

        public static implicit operator List<object>(PessoasModel v)
        {
            throw new NotImplementedException();
        }
        

       

        

        
      

        
      
       
    }
}
