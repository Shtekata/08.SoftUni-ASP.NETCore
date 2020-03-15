namespace ApiDemo.Controllers
{
    using ApiDemo.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public CandidatesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            return db.Candidates.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Candidate> Get(int id)
        {
            var candidate = db.Candidates.FirstOrDefault(x => x.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> PostAsync(Candidate candidate)
        {
            await db.Candidates.AddAsync(candidate);
            await db.SaveChangesAsync();
            //return Created($"/api/candidates/{candidate.Id}", candidate);
            return CreatedAtAction("GET", new { id = candidate.Id}, candidate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Candidate>> PutAsync(int id, Candidate candidate)
        {
            var dbCandidate = db.Candidates.FirstOrDefault(x => x.Id == id);
            if (dbCandidate == null)
            {
                return NotFound();
            }

            dbCandidate.Names = candidate.Names;
            dbCandidate.YearsOfExperience = candidate.YearsOfExperience;
            
            await db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteAsync(int id)
        {
            var dbCandidate = db.Candidates.FirstOrDefault(x => x.Id == id);
            if (dbCandidate == null)
            {
                return NotFound();
            }

            db.Candidates.Remove(dbCandidate);
            await db.SaveChangesAsync();

            return dbCandidate;
        }
    }
}
