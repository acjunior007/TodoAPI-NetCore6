using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Domain.Models
{
	public class Notes
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Informar a descricao!")]
		[StringLength(100)]
		public string Description { get; set; }

	}
}
