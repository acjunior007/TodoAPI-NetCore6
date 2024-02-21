using Microsoft.AspNetCore.Mvc;
using TodoAPI.Domain.Interface;
using TodoAPI.Domain.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly INoteService _noteService;

        public TodoAppController(IConfiguration configuration, INoteService noteService)
        {
            _configuration = configuration;
            _noteService = noteService;
        }

        //[HttpGet(Name = "GetNoes")]
        //public JsonResult GetNotes()
        //{
        //    string query = "select * from dbo.Notes";
        //    DataTable dt = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("conn");
        //    SqlDataReader myReader;
        //    using (SqlConnection conn = new SqlConnection(sqlDataSource))
        //    {
        //        conn.Open();
        //        using (SqlCommand comand = new SqlCommand(query, conn))
        //        {
        //            myReader = comand.ExecuteReader();
        //            dt.Load(myReader);
        //            conn.Close();
        //        }
        //    }
        //    return new JsonResult(dt);
        //}

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var notes = await _noteService.GetNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Notes note)
        {
            try
            {
                note = await _noteService.Create(note);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
