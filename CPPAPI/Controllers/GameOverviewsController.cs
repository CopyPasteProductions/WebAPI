using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CPPAPI.Models;

namespace CPPAPI.Controllers
{
    public class GameOverviewsController : ApiController
    {
        private CPP_DB db = new CPP_DB();

        // GET: api/GameOverviews
        public IQueryable<GameOverview> GetGameOverviews()
        {
            return db.GameOverviews.Include(x=>x.Players);
        }



        // GET: api/GameOverviews/5
        [ResponseType(typeof(GameOverview))]
        public async Task<IHttpActionResult> GetGameOverview(int id)
        {
            GameOverview gameOverview = await db.GameOverviews.FindAsync(id);
            if (gameOverview == null)
            {
                return NotFound();
            }

            return Ok(gameOverview);
        }

        // PUT: api/GameOverviews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGameOverview(int id, GameOverview gameOverview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameOverview.Id)
            {
                return BadRequest();
            }

            db.Entry(gameOverview).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameOverviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GameOverviews
        [ResponseType(typeof(GameOverview))]
        public async Task<IHttpActionResult> PostGameOverview(GameOverview gameOverview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameOverviews.Add(gameOverview);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gameOverview.Id }, gameOverview);
        }

        // DELETE: api/GameOverviews/5
        [ResponseType(typeof(GameOverview))]
        public async Task<IHttpActionResult> DeleteGameOverview(int id)
        {
            GameOverview gameOverview = await db.GameOverviews.FindAsync(id);
            if (gameOverview == null)
            {
                return NotFound();
            }

            db.GameOverviews.Remove(gameOverview);
            await db.SaveChangesAsync();

            return Ok(gameOverview);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameOverviewExists(int id)
        {
            return db.GameOverviews.Count(e => e.Id == id) > 0;
        }
    }
}