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
			List<memberCompany> usrcompanies = (from cmp in db.memberCompanies where cmp.UserId == id select cmp).ToList();
			int[] companyIds = usrcompanies.Select(x => x.companyId).ToArray();
			List<company> companies = (from cmp in db.companies
									   where companyIds.Contains(cmp.companyId)
									   select cmp).ToList();
			List<CompanyPoints> result = (from usr in usrcompanies
										  join cmp in companies on usr.companyId equals cmp.companyId
										  select new CompanyPoints
										  {
											  companyId = cmp.companyId,
											  companyName = cmp.companyName,
											  companyLogo = cmp.companyLogo,
											  points = usrcompanies.Find(x => x.companyId == cmp.companyId).points
										  }).ToList();
			return result;
		}

		public CompanyPoints GetPoints(int UserId, int CompanyId)
		{
			company cmp = db.companies.Find(CompanyId);
			memberCompany mc = (from r in db.memberCompanies where r.companyId == CompanyId && r.UserId == UserId select r).FirstOrDefault();
			CompanyPoints cp = new CompanyPoints
			{
				companyId = cmp.companyId,
				companyName = cmp.companyName,
				companyLogo = cmp.companyLogo,
				points = mc.points
			};
			return cp;
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