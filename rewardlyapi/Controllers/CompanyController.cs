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
	public class CompanyController : ApiController
	{
		private rewardlyContext db = new rewardlyContext();

		// GET api/Company
		public IEnumerable<company> Getcompanies()
		{
			return db.companies.AsEnumerable();
		}

		public IEnumerable<company> GetSearchCompanies(int venueId, int prizePoint)
		{
			int[] companyIds = db.locations
				.Where(loc => loc.venueId == venueId && loc.pricePoint < prizePoint)
				.GroupBy(p => p.locationId)
				.Select(g => g.FirstOrDefault())
				.ToList()
				.Select(l => l.locationId)
				.ToArray();
			List<company> companies = (from cmp in db.companies where companyIds.Contains(cmp.companyId) select cmp).ToList();
			return companies;
		}

		// GET api/Company/5
		public company Getcompany(int id)
		{
			company company = db.companies.Find(id);
			if (company == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}

			return company;
		}

		// PUT api/Company/5
		public HttpResponseMessage Putcompany(int id, company company)
		{
			if (ModelState.IsValid && id == company.companyId)
			{
				db.Entry(company).State = EntityState.Modified;

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

		// POST api/Company
		public HttpResponseMessage Postcompany(company company)
		{
			if (ModelState.IsValid)
			{
				db.companies.Add(company);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, company);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = company.companyId }));
				return response;
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
		}

		// DELETE api/Company/5
		public HttpResponseMessage Deletecompany(int id)
		{
			company company = db.companies.Find(id);
			if (company == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.companies.Remove(company);

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			return Request.CreateResponse(HttpStatusCode.OK, company);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

	}


}