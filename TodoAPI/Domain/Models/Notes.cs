using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListAPI.Domain.Models
{
	public class Notes
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Informar uma descricao!")]
		[Column("Description")]
		[StringLength(100)]
		public string Description { get; set; }

		public bool Active { get; set; }

		public DateTime DateCreated { get; set; }

		public bool ValidDescription()
		{
			return !string.IsNullOrEmpty(Description);
		}
	}
}
