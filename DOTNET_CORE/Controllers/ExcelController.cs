using System.Linq;
using DOTNET_CORE.Models.Data;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

[Route("api/[controller]")]
public class ExcelController:Controller
{


    [HttpGet]
    public IActionResult Excel()
    {
        var comlumHeadrs = new string[]
            {
                "Employee Id",
                "Name",
                "Position",
                "Salary",
                "Joined Date"
            };

            byte[] result;


             using (var package = new ExcelPackage())
            {
                // add a new worksheet to the empty workbook

                var worksheet = package.Workbook.Worksheets.Add("Current Employee"); //Worksheet name
                using (var cells = worksheet.Cells[1, 1, 1, 5]) //(1,1) (1,5)
                {
                    cells.Style.Font.Bold = true;
                }

                //First add the headers
                for (var i = 0; i < comlumHeadrs.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].Value = comlumHeadrs[i];
                }

                //Add values
                var j = 2;
                foreach (var employee in DummyData2.GetEmployeeData())
                {
                    worksheet.Cells["A" + j].Value = employee.Id;
                    worksheet.Cells["B" + j].Value = employee.Name;
                    worksheet.Cells["C" + j].Value = employee.Position;
                    worksheet.Cells["D" + j].Value = employee.Salary;
                    worksheet.Cells["E" + j].Value = employee.JoinedDate.ToString("MM/dd/yyyy");

                    j++;

                    


                }

               


                ExcelBarChart lineChart = worksheet.Drawings.AddChart("barChart", eChartType.BarStacked) as ExcelBarChart;
                 //set the title
                lineChart.Title.Text = "LineChart Example";

                var test1 = DummyData2.GetEmployeeData().Count() + 1;
                 var rangeLabel = worksheet.Cells[$"B2:B{test1}" ];
                var range1 = worksheet.Cells[$"D2:D{test1}"];

                 var rangeLabel2 = worksheet.Cells["B2:B4" ];
                var range2 = worksheet.Cells["D2:D4"];
                 lineChart.Series.Add(range1,rangeLabel);
                //position of the legend


                //size of the chart
                lineChart.SetSize(600, 300);

                //add the chart at cell B6
                lineChart.SetPosition(5, 0, 1, 0);



                result = package.GetAsByteArray();
}

         return File(result, "application/ms-excel", $"Employee.xlsx");


    }

 [HttpGet("old")]
    public IActionResult Excel2()
    {
            byte[] result;


             using (var package = new ExcelPackage())
            {

                ExcelWorksheet myWorksheet = package.Workbook.Worksheets.Add("Sheet1");
 
                    // specify cell values to be used for generating chart.
                    myWorksheet.Cells["C2"].Value = 10;
                    myWorksheet.Cells["C3"].Value = 40;
                    myWorksheet.Cells["C4"].Value = 30;
                    
                    myWorksheet.Cells["B2"].Value = "Yes";
                    myWorksheet.Cells["B3"].Value = "No";
                    myWorksheet.Cells["B4"].Value = "NA";

                    // add chart of type Pie.
                    var myChart = myWorksheet.Drawings.AddChart("chart", eChartType.Pie);
                    
                    // Define series for the chart
                    var series = myChart.Series.Add("C2: C4", "B2: B4");
                    myChart.Border.Fill.Color = System.Drawing.Color.Green;
                    myChart.Title.Text = "My Chart";
                    myChart.SetSize(400, 400);
                    
                    // Add to 6th row and to the 6th column
                    myChart.SetPosition(6, 0, 6, 0);
 
                     result = package.GetAsByteArray();

            }

                   return File(result, "application/ms-excel", $"Employee.xlsx");


    }




}