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
using WebApi_Final.Models;

namespace WebApi_Final.Controllers
{
    public class B_productController : ApiController
    {
        private AdventureWorks2017Entities db = new AdventureWorks2017Entities();

        // GET: api/B_product
        public IQueryable<B_product> GetB_product()
        {
            return db.B_product;
        }

        // GET: api/B_product/5
        [ResponseType(typeof(B_product))]
        public async Task<IHttpActionResult> GetB_product(int id)
        {
            B_product b_product = await db.B_product.FindAsync(id);
            if (b_product == null)
            {
                return NotFound();
            }

            return Ok(b_product);
        }

        // PUT: api/B_product/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutB_product(int id, B_product b_product)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != b_product.product_id)
            {
                return BadRequest();
            }

            db.Entry(b_product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!B_productExists(id))
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

        // POST: api/B_product
        [ResponseType(typeof(B_product))]
        public async Task<IHttpActionResult> PostB_product(B_product b_product)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.B_product.Add(b_product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = b_product.product_id }, b_product);
        }

        // DELETE: api/B_product/5
        [ResponseType(typeof(B_product))]
        public async Task<IHttpActionResult> DeleteB_product(int id)
        {
            B_product b_product = await db.B_product.FindAsync(id);
            if (b_product == null)
            {
                return NotFound();
            }

            db.B_product.Remove(b_product);
            await db.SaveChangesAsync();

            return Ok(b_product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool B_productExists(int id)
        {
            return db.B_product.Count(e => e.product_id == id) > 0;
        }
    }
}