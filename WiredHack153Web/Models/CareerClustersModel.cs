using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WiredHack.DAL;

namespace WiredHack153Web.Models
{
    public class CareerClustersModel
    {
        public CareerClustersModel()
        {
            Clusters = new List<CareerCluster>();
        }
        public List<CareerCluster> Clusters { get; set; }
    }

    public class CareerCluster
    {
        public CareerCluster()
        {
            Schools = new List<ChartStatistic>();
            Jobs = new List<ChartStatistic>();
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String SchoolID
        {
            get
            {
                return "SchoolChart" + Id;
            }
        }
        public String JobID
        {
            get
            {
                return "JobChart" + Id;
            }
        }

        public List<ChartStatistic> Schools { get; set; }
        public List<ChartStatistic> Jobs { get; set; }
    }

    public class ChartStatistic
    {
        public String Name { get; set; }
        public int Count { get; set; }
    }
    public class EmployeeProfileThumb
    {
        public int EmployeeID { get; set; }
        public String Name { get; set; }
        public string Image { get; set; }
        public String Bio { get; set; }
        public String Employer { get; set; }
        public int EmployerID { get; set; }
        public String JobTitle { get; set; }
        public string College { get; set; }
        public String Major { get; set; }
    }

    public class EmployerDetails
    {
        public int Id { get; set; }
        public String EmployerName { get; set; }
        public String Industry { get; set; }
        public String NumOfEmployees { get; set; }
    }
}