using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using rewardly.Models;

namespace rewardlyapi.Controllers
{
	public class RewardsController : ApiController
	{
		private rewardlyContext db = new rewardlyContext();

		public IEnumerable<catalog> GetLocationCatalog(int id)
		{
			List<catalog> rewards = (from prize in db.catalogs where prize.locationId == id orderby prize.points select prize).ToList();
			return rewards;
		}

		// GET api/Rewards
		public IEnumerable<catalog> Getcatalogs()
		{
			return db.catalogs.AsEnumerable();
		}

		// GET api/Rewards/5
		public catalog Getcatalog(int id)
		{
			catalog catalog = db.catalogs.Find(id);
			if (catalog == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}

			return catalog;
		}

		// PUT api/Rewards/5
		public HttpResponseMessage Putcatalog(int id, catalog catalog)
		{
			if (ModelState.IsValid && id == catalog.catalogId)
			{
				db.Entry(catalog).State = EntityState.Modified;

				try
				{
					db.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					return Request.CreateResponse(HttpStatusCode.NotFound);
				}

				return Request.CreateResponse(HttpStatusCode.OK);
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
		}

		// POST api/Rewards
		public HttpResponseMessage Postcatalog(catalog catalog)
		{
			if (ModelState.IsValid)
			{
				db.catalogs.Add(catalog);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, catalog);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = catalog.catalogId }));
				return response;
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
		}

		// DELETE api/Rewards/5
		public HttpResponseMessage Deletecatalog(int id)
		{
			catalog catalog = db.catalogs.Find(id);
			if (catalog == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.catalogs.Remove(catalog);

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			return Request.CreateResponse(HttpStatusCode.OK, catalog);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}