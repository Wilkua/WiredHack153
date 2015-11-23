using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WiredHack.DAL;

namespace WiredHack153Web.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public ActionResult Index()
        {
            return View();
        }

        public String CareerClusters()
        {
            using (var db = new WiredHackEntities())
            {
                var CCList = db.CareerClusters.Select(cc => new { cc.CCId, cc.Description }).ToList();
                return new JavaScriptSerializer().Serialize(CCList);
            }
        }

        public String SchoolChart(int? ccid)
        {
            if (ccid == null)
                return "";

            using (var db = new WiredHackEntities())
            {
                var results = db.GetCareerClusterSchoolChart(ccid.Value);

                var highChart = new HighChart<int>();
                highChart.chart.type = "column";
                highChart.title.text = "Schools";
                highChart.yAxis.min = 0;
                highChart.yAxis.title.text = "Count";
                highChart.tooltip.headerFormat = "<span style=\"font - size:10px\">{point.key}</span><table>";
                highChart.tooltip.printFormat = "<tr><td style=\"color: { series.color}; padding: 0\">{series.name}: </td><td style=\"padding:0\"><b>{point.y:.1f}</b></td></tr>";
                highChart.tooltip.footerFormat = "</table>";
                highChart.tooltip.shared = true;
                highChart.tooltip.useHTML = true;
                highChart.plotOptions.column.pointPadding = 0.2f;
                highChart.plotOptions.column.borderWidth = 0;
                var chartSeries = new HighChart<int>.ChartSeries<int>();
                chartSeries.name = "Schools";

                foreach (var item in results)
                {
                    highChart.xAxis.categories.Add(item.Name);
                    chartSeries.data.Add(item.count.Value);
                }

                highChart.series.Add(chartSeries);
                
                return new JavaScriptSerializer().Serialize(highChart);
            }
        }

        public String JobsChart(int? ccid)
        {
            if (ccid == null)
                return "";

            using (var db = new WiredHackEntities())
            {
                var results = db.GetCareerClusterJobChart(ccid.Value);

                var highChart = new HighChart<int>();
                highChart.chart.type = "column";
                highChart.title.text = "Jobs";
                highChart.yAxis.min = 0;
                highChart.yAxis.title.text = "Count";
                highChart.tooltip.headerFormat = "<span style=\"font - size:10px\">{point.key}</span><table>";
                highChart.tooltip.printFormat = "<tr><td style=\"color: { series.color}; padding: 0\">{series.name}: </td><td style=\"padding:0\"><b>{point.y:.1f}</b></td></tr>";
                highChart.tooltip.footerFormat = "</table>";
                highChart.tooltip.shared = true;
                highChart.tooltip.useHTML = true;
                highChart.plotOptions.column.pointPadding = 0.2f;
                highChart.plotOptions.column.borderWidth = 0;
                var chartSeries = new HighChart<int>.ChartSeries<int>();
                chartSeries.name = "Schools";

                foreach (var item in results)
                {
                    highChart.xAxis.categories.Add(item.Name);
                    chartSeries.data.Add(item.count.Value);
                }

                highChart.series.Add(chartSeries);

                return new JavaScriptSerializer().Serialize(highChart);
            }
        }

        public String HomeCC()
        {
            using (var db = new WiredHackEntities())
            {
                var clusters = db.CareerClusters;

                var highChart = new HighChart<int>();
                highChart.chart.type = "column";
                highChart.title.text = "Career Clusters";
                highChart.yAxis.min = 0;
                highChart.yAxis.title.text = "Count";
                highChart.tooltip.headerFormat = "<span style=\"font - size:10px\">{point.key}</span><table>";
                highChart.tooltip.printFormat = "<tr><td style=\"color: { series.color}; padding: 0\">{series.name}: </td><td style=\"padding:0\"><b>{point.y:.1f}</b></td></tr>";
                highChart.tooltip.footerFormat = "</table>";
                highChart.tooltip.shared = true;
                highChart.tooltip.useHTML = true;
                highChart.plotOptions.column.pointPadding = 0.2f;
                highChart.plotOptions.column.borderWidth = 0;
                var chartSeries = new HighChart<int>.ChartSeries<int>();
                chartSeries.name = "Schools";

                foreach (var item in clusters)
                {
                    var jobs = db.JobCCConnections.Where(c => c.CCID == item.CCId).Count();

                    highChart.xAxis.categories.Add(item.Name);
                    chartSeries.data.Add(jobs);
                }

                highChart.series.Add(chartSeries);

                return new JavaScriptSerializer().Serialize(highChart);
            }
        }
    }

    public class HighChart<T>
    {
        public class ChartType
        {
            public string type { get; set; }
        }

        public class ChartTitle
        {
            public string text { get; set; }
        }

        public class AxisTitle
        {
            public string text { get; set; }
        }

        public class ChartXAxis
        {
            public List<string> categories { get; set; }
            public bool crosshair { get; set; }

            public ChartXAxis()
            {
                categories = new List<string>();
            }
        }

        public class ChartYAxis
        {
            public int min { get; set; }
            public AxisTitle title { get; set; }

            public ChartYAxis()
            {
                title = new AxisTitle();
            }
        }

        public class ChartTooltip
        {
            public string headerFormat { get; set; }
            public string printFormat { get; set; }
            public string footerFormat { get; set; }
            public bool shared { get; set; }
            public bool useHTML { get; set; }
        }

        public class ChartPlotColumn
        {
            public float pointPadding { get; set; }
            public int borderWidth { get; set; }
        }

        public class ChartPlotOptions
        {
            public ChartPlotColumn column { get; set; }

            public ChartPlotOptions()
            {
                column = new ChartPlotColumn();
            }
        }

        public class ChartSeries<Tx>
        {
            public string name { get; set; }
            public List<Tx> data { get; set; }

            public ChartSeries()
            {
                data = new List<Tx>();
            }
        }

        public ChartType chart { get; set; }
        public ChartTitle title { get; set; }
        public ChartXAxis xAxis { get; set; }
        public ChartYAxis yAxis { get; set; }
        public ChartTooltip tooltip { get; set; }
        public ChartPlotOptions plotOptions { get; set; }
        public List<ChartSeries<T>> series { get; set; }

        public HighChart()
        {
            chart = new ChartType();
            title = new ChartTitle();
            xAxis = new ChartXAxis();
            yAxis = new ChartYAxis();
            tooltip = new ChartTooltip();
            plotOptions = new ChartPlotOptions();
            series = new List<ChartSeries<T>>();
        }
    }

    public class SchoolChartInfo
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}