using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using rewardly.Models;
using rewardly.ViewModels;

namespace rewardlyapi.Controllers
{
	public class MembersController : ApiController
	{
		private rewardlyContext db = new rewardlyContext();

		public IEnumerable<CompanyPoints> GetUserCompanyPoints(int id)
		{
			List<memberCompany> companies = (from cmp in db.memberCompanies where cmp.UserId == id select cmp).ToList();
			List<CompanyPoints> result = (from cmp in db.companies
										  join usrcmp in companies on cmp.companyId equals usrcmp.companyId
										  select new CompanyPoints
										  {
											  companyId = cmp.companyId,
											  companyName = cmp.companyName,
											  companyLogo = cmp.companyLogo,
											  points = usrcmp.points
										  }).ToList();
			return result;
		}

		// GET api/Members
		public IEnumerable<UserProfile> GetUserProfiles()
		{
			return db.UserProfiles.AsEnumerable();
		}

		// GET api/Members/5
		public UserProfile GetUserProfile(int id)
		{
			UserProfile userprofile = db.UserProfiles.Find(id);
			if (userprofile == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}

			return userprofile;
		}

		// PUT api/Members/5
		public HttpResponseMessage PutUserProfile(int id, UserProfile userprofile)
		{
			if (ModelState.IsValid && id == userprofile.UserId)
			{
				db.Entry(userprofile).State = EntityState.Modified;

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

		// POST api/Members
		public HttpResponseMessage PostUserProfile(UserProfile userprofile)
		{
			if (ModelState.IsValid)
			{
				db.UserProfiles.Add(userprofile);
				db.SaveChanges();

				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, userprofile);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = userprofile.UserId }));
				return response;
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
		}

		// DELETE api/Members/5
		public HttpResponseMessage DeleteUserProfile(int id)
		{
			UserProfile userprofile = db.UserProfiles.Find(id);
			if (userprofile == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.UserProfiles.Remove(userprofile);

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			return Request.CreateResponse(HttpStatusCode.OK, userprofile);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}