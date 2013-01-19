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
	public class LocationController : ApiController
	{
		private rewardlyContext db = new rewardlyContext();

		public IEnumerable<location> GetCompanyLocations(int id)
		{
			List<location> locations = (from loc in db.locations where loc.companyId == id select loc).ToList();
			return locations;
		}

		// GET api/Location
		public IEnumerable<location> Getlocations()
		{
			return db.locations.AsEnumerable();
		}

		// GET api/Location/5
		public location Getlocation(int id)
		{
			location location = db.locations.Find(id);
			if (location == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}

			return location;
		}

		// PUT api/Location/5
		public HttpResponseMessage Putlocation(int id, location location)
		{
			if (ModelState.IsValid && id == location.locationId)
			{
				db.Entry(location).State = EntityState.Modified;

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

		// POST api/Location
		public HttpResponseMessage Postlocation(location location)
		{
			if (ModelState.IsValid)
			{
				db.locations.Add(location);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, location);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = location.locationId }));
				return response;
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
		}

		// DELETE api/Location/5
		public HttpResponseMessage Deletelocation(int id)
		{
			location location = db.locations.Find(id);
			if (location == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.locations.Remove(location);

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			return Request.CreateResponse(HttpStatusCode.OK, location);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}