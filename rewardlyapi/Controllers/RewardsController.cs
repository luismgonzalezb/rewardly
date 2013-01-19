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

		public string GetCode(int UserId, int catalogId)
		{
			int points = (from pts in db.catalogs where pts.catalogId == catalogId select pts.points).FirstOrDefault();
			int[] companyIds = (from lc in db.locations join cat in db.catalogs on lc.locationId equals cat.locationId select lc.companyId).ToArray();
			int companyId = (from cmp in db.companies where companyIds.Contains(cmp.companyId) select cmp.companyId).FirstOrDefault();
			memberCompany mc = (from m in db.memberCompanies
								where m.companyId == companyId && m.UserId == UserId
								select m).FirstOrDefault();
			mc.points = mc.points - points;
			db.Entry(mc).State = EntityState.Modified;
			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return "";
			}
			return (from mr in db.memberRedemptions
					where mr.catalogId == catalogId && mr.UserId == UserId
					select mr.code).FirstOrDefault();
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

		public HttpResponseMessage PostCheckin(memberVisit visit)
		{
			if (ModelState.IsValid)
			{
				db.memberVisits.Add(visit);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, visit);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = visit.memberVisitId }));
				return response;
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
		}

		public HttpResponseMessage PostRedem(memberRedemption redem)
		{
			if (ModelState.IsValid)
			{
				redem.code = new Guid().ToString().Substring(0, 19);
				db.memberRedemptions.Add(redem);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, redem);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = redem.memberRedemptionId }));
				return response;
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