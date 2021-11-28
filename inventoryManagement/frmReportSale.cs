using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using inventoryManagement.Core;

namespace inventoryManagement
{
    public partial class frmReportSale : Form
    {
        public frmReportSale()
        {
            InitializeComponent();

            cbSort.SelectedItem = "Ngày";

            loadSaleChart();
        }

        public void loadSaleChart()
        {
            saleChart.Titles.Clear();
            saleChart.Series.Clear();
            Series series = saleChart.Series.Add("Doanh thu");
            series.ChartType = SeriesChartType.Spline;
            
            switch (cbSort.SelectedItem)
            {
                case "Ngày":
                    {
                        saleChart.Titles.Add("Doanh thu 7 ngày gần nhất");
                        DateTime[] last7Days = Enumerable.Range(0, 7)
                            .Select(i => DateTime.Now.Date.AddDays(-i))
                            .ToArray();
                        Array.Reverse(last7Days);
                        foreach (var day in last7Days)
                        {
                            string sql =
                                "SELECT COUNT(o.id) " +
                                "FROM orders o " +
                                "WHERE " +
                                "FORMAT(created_at, 'dd/MM') = '"+ 
                                $"{day:dd/MM}" + "'";
                            var rs = db.ReadScalar(sql);
                            decimal quantity = 0;
                            if (rs != DBNull.Value)
                            {
                                quantity = Decimal.Parse(rs.ToString());
                            }
                            series.Points.AddXY($"{day:dd/MM}", quantity);
                        }
                    }
                    break;
                case "Tháng":
                    saleChart.Titles.Clear();
                    saleChart.Titles.Add("Doanh thu 12 tháng gần nhất");
                    DateTime[] last7Months = Enumerable.Range(0, 12)
                    .Select(i => DateTime.Now.Date.AddMonths(-i))
                    .ToArray();
                    Array.Reverse(last7Months);
                    foreach (var day in last7Months)
                    {
                        string sql =
                                 "SELECT COUNT(o.id) " +
                                 "FROM orders o " +
                                 "WHERE " +
                                 "FORMAT(created_at, 'MM/yyyy') = '" +
                                 $"{day:MM/yyyy}" + "'";
                        var rs = db.ReadScalar(sql);
                        decimal quantity = 0;
                        if (rs != DBNull.Value)
                        {
                            quantity = Decimal.Parse(rs.ToString());
                        }
                        series.Points.AddXY($"{day:MM/yyyy}", quantity);
                    }
                    break;
                case "Năm":
                    saleChart.Titles.Clear();
                    saleChart.Titles.Add("Doanh thu 5 năm gần nhất");
                    DateTime[] last7Years = Enumerable.Range(0, 5)
                        .Select(i => DateTime.Now.Date.AddYears(-i))
                        .ToArray();
                    Array.Reverse(last7Years);
                    foreach (var day in last7Years)
                    {
                        string sql =
                                "SELECT COUNT(o.id) " +
                                "FROM orders o " +
                                "WHERE " +
                                "FORMAT(created_at, 'yyyy') = '" +
                                $"{day:yyyy}" + "'";
                        var rs = db.ReadScalar(sql);
                        decimal quantity = 0;
                        if (rs != DBNull.Value)
                        {
                            quantity = Decimal.Parse(rs.ToString());
                        }
                        series.Points.AddXY($"{day:yyyy}", quantity);
                    }
                    break;
                default:
                    break;
            }    
        }

        private void cbSort_SelectedValueChanged(object sender, EventArgs e)
        {
            loadSaleChart();
        }
    }
}
