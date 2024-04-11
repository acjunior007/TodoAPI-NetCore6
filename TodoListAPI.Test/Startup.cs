
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoListAPI.Application.Services;
using TodoListAPI.Config;
using TodoListAPI.Domain.Interface;
using TodoListAPI.Infra.Context;
using TodoListAPI.Infra.Repository;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace TodoListAPI.Test
{
	public class Startup
	{
		// private readonly IConfiguration _configuration;

		//public Startup(IConfiguration configuration)
		//{
		//	_configuration = configuration;
		//}
		public void ConfigureServices(IServiceCollection services)
		{

			var path = Path.GetDirectoryName(GetType().Assembly.Location);
			var configurationBuilder = new ConfigurationBuilder();

			configurationBuilder
				.SetBasePath(path)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
				.AddEnvironmentVariables();

			// configurationBuilder.AddConnections();
			var configuration = configurationBuilder.Build();
			var provider = services.BuildServiceProvider();

			services.AddDbContext<DBTodoAPPContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("conn")
					));

			IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
			services.AddSingleton(mapper);

			services.AddSingleton<IConfiguration>(configuration);
			services.AddLogging(logging => logging.AddConsole());

			services.AddScoped<INoteRepository, NoteRepository>();
			services.AddScoped<INoteService, NoteService>();

			services.AddSingleton<IServiceProvider>(provider);
		}

		public void Configure(IServiceProvider provider, ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
		{
			loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor));
			if (provider is null)
				Console.WriteLine("Provider is not from startup.configure");
		}
	}
}
