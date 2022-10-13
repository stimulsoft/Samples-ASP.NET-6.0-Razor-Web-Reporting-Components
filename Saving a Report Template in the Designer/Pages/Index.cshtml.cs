﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;

namespace Saving_a_Report_Template_in_the_Designer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        static IndexModel()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostGetReport()
        {
            var report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists.mrt"));

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult OnPostSaveReport()
        {
            var report = StiNetCoreDesigner.GetReportObject(this);

            // Save the report template, for example to JSON string
            var json = report.SaveToJsonString();

            return StiNetCoreDesigner.SaveReportResult(this);
        }

        public IActionResult OnPostSaveReportAs()
        {
            return StiNetCoreDesigner.SaveReportResult(this);
        }

        public IActionResult OnGetDesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }

        public IActionResult OnPostDesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}