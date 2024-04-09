using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Application.ValueObject
{
	public class NoteVO
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public bool Active { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime? DateUpdated { get; set; }
	}
}
