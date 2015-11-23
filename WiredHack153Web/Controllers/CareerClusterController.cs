using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WiredHack.DAL;
using WiredHack153Web.Models;

namespace WiredHack153Web.Controllers
{
    public class CareerClusterController : Controller
    {
        // GET: CareerCluster
        public ActionResult Index()
        {
            using(WiredHackEntities context = new WiredHackEntities())
            {
                var clusters = context.CareerClusters;

                CareerClustersModel model = new CareerClustersModel();
                foreach(var c in clusters)
                {
                    List<ChartStatistic> Jobs = new List<ChartStatistic>();
                    List<ChartStatistic> Schools = new List<ChartStatistic>();

                    foreach (var item in context.GetCareerClusterJobChart(c.CCId))
                    {
                        Jobs.Add(new ChartStatistic()
                        {
                            Name = item.Name,
                            Count = item.count.Value
                        });
                    }
                    foreach (var item in context.GetCareerClusterSchoolChart(c.CCId))
                    {
                        Schools.Add(new ChartStatistic()
                        {
                            Name = item.Name,
                            Count = item.count.Value
                        });
                    }
                    model.Clusters.Add(new Models.CareerCluster()
                    {
                        Id = c.CCId,
                        Name = c.Name,
                        Description = c.Description,
                        Jobs = Jobs,
                        Schools = Schools
                    });
                }

                return View(model);
            }
        }

        public ActionResult Employees(int id)
        {
            using (WiredHackEntities context = new WiredHackEntities())
            {
                List<EmployeeProfileThumb> employees = new List<EmployeeProfileThumb>();
                foreach (var item in context.GetCareerClusterEmployees(id).ToList())
                {
                    var t = context.EmployeeJobConnections.FirstOrDefault(o => o.EmployeeID == item.Id);
                    t.Jobs = context.Jobs.Where(o => o.JobID == t.JobId).ToList();

                    EmployeeProfileThumb i = new EmployeeProfileThumb();
                    i.EmployeeID = context.Users.FirstOrDefault(o => o.EmployeeId.Value == item.Id).Id;
                    i.Name = item.FirstName + ' ' + item.LastName;
                    i.Image = item.Image;
                    i.Bio = item.Bio != null ? item.Bio : "";
                    i.EmployerID = context.Users.FirstOrDefault(o => o.EmployeeId.Value == item.Id).EmployerId.Value;
                    i.Employer = context.Employers.FirstOrDefault(o => o.EmployerID == i.EmployerID).Name + ": " + context.Employers.FirstOrDefault(o => o.EmployerID == i.EmployerID).NumEmployees;
                    i.Major = context.Majors.FirstOrDefault(o => o.Id == item.MajorID).Description;
                    i.College = context.Universities.FirstOrDefault(o => o.Id == item.UniversityID).Name;
                    i.JobTitle = t.Jobs.FirstOrDefault().Name;

                    employees.Add(i);
                }
                return View(employees);
            }
            return View();
        }

        public ActionResult Employers(int id)
        {
            using (WiredHackEntities context = new WiredHackEntities())
            {
                List<EmployerDetails> employers = new List<EmployerDetails>();
                foreach (var item in context.Employers.ToList())
                {
                    EmployerDetails blank = new EmployerDetails();
                    blank.EmployerName = item.Name;
                    blank.NumOfEmployees = item.NumEmployees;
                    blank.Industry = context.Industries.FirstOrDefault(o => o.IndustryId.ToString() == item.IndustryID).Description;
                    blank.Id = item.EmployerID;
                    
                    employers.Add(blank);
                }
                return View(employers);
            }
            return View();
        }
    }
}