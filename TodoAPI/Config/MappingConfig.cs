using AutoMapper;
using TodoListAPI.Application.ValueObject;
using TodoListAPI.Domain.Models;

namespace TodoListAPI.Config
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<NoteVO, Notes>();
				config.CreateMap<Notes, NoteVO>();
			});

			return mappingConfig;
		}
	}
}
