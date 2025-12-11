using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLNS_BLL;

namespace QLNS.Forms.Statistic
{
    public partial class FormTopBooksStatistic : Form
    {
        private BaoCao_BLL baoCaoBLL = new BaoCao_BLL();
        private TheLoai_BLL theLoaiBLL = new TheLoai_BLL();
        private DataTable currentData;

        public FormTopBooksStatistic()
        {
            InitializeComponent();
            LoadDefaultData();
            SetupDataGridView();
            SetupChart();
        }

        private void LoadDefaultData()
        {
            // Set default date range (current month)
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            nudTopN.Value = 10; // Top 10 by default
            
            // Load categories
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Tất cả thể loại");
            
            var categories = theLoaiBLL.LayDanhSachTheLoai();
            foreach (var cat in categories)
            {
                cboCategory.Items.Add(cat.TenTheLoai);
            }
            
            cboCategory.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvTopBooks.AutoGenerateColumns = false;
            dgvTopBooks.AllowUserToAddRows = false;
            dgvTopBooks.AllowUserToDeleteRows = false;
            dgvTopBooks.ReadOnly = true;
            dgvTopBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopBooks.MultiSelect = false;
            dgvTopBooks.BackgroundColor = Color.White;
            dgvTopBooks.BorderStyle = BorderStyle.None;
            dgvTopBooks.RowHeadersVisible = false;
            dgvTopBooks.EnableHeadersVisualStyles = false;
            
            // Header styling
            dgvTopBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvTopBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTopBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTopBooks.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvTopBooks.ColumnHeadersHeight = 40;
            
            dgvTopBooks.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvTopBooks.RowTemplate.Height = 40;
        }

        private void SetupChart()
        {
            chartTopBooks.Series.Clear();
            chartTopBooks.ChartAreas.Clear();
            chartTopBooks.Legends.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea.AxisY.LabelStyle.Format = "{0:N0}";
            chartTopBooks.ChartAreas.Add(chartArea);

            Legend legend = new Legend("Legend1");
            legend.Enabled = false;
            chartTopBooks.Legends.Add(legend);

            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Bar;
            series.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            series.Color = Color.FromArgb(52, 152, 219);
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0:N0}";
            chartTopBooks.Series.Add(series);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int topN = (int)nudTopN.Value;
                string selectedCategory = cboCategory.SelectedIndex == 0 ? null : cboCategory.Text;

                // Get category code if filtered
                string maTL = null;
                if (selectedCategory != null && cboCategory.SelectedIndex > 0)
                {
                    var categories = theLoaiBLL.LayDanhSachTheLoai();
                    var found = categories.Find(c => c.TenTheLoai == selectedCategory);
                    if (found != null)
                        maTL = found.MaTheLoai;
                }

                currentData = baoCaoBLL.LayTopSachBanChay(
                    dtpStartDate.Value, 
                    dtpEndDate.Value, 
                    topN,
                    maTL);

                if (currentData == null || currentData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian đã chọn!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTopBooks.DataSource = null;
                    UpdateChart(null);
                    return;
                }

                SetupDataGridViewColumns();
                dgvTopBooks.DataSource = currentData;
                AddMedalIcons();
                UpdateChart(currentData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvTopBooks.Columns.Clear();

            // Ranking column
            DataGridViewTextBoxColumn colRank = new DataGridViewTextBoxColumn
            {
                HeaderText = "#",
                Name = "Ranking",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 152, 219)
                }
            };
            dgvTopBooks.Columns.Add(colRank);

            // Medal/Icon column
            DataGridViewTextBoxColumn colMedal = new DataGridViewTextBoxColumn
            {
                HeaderText = "",
                Name = "Medal",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 14F)
                }
            };
            dgvTopBooks.Columns.Add(colMedal);

            dgvTopBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Sách",
                DataPropertyName = "MaSach",
                Width = 80
            });

            dgvTopBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Sách",
                DataPropertyName = "TenSach",
                Width = 300
            });

            dgvTopBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thể Loại",
                DataPropertyName = "TenTheLoai",
                Width = 120
            });

            dgvTopBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NXB",
                DataPropertyName = "TenNXB",
                Width = 150
            });

            dgvTopBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Lượng Bán",
                DataPropertyName = "SoLuongBan",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(46, 204, 113)
                }
            });

            dgvTopBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Doanh Thu",
                DataPropertyName = "DoanhThu",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            });

            dgvTopBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lợi Nhuận",
                DataPropertyName = "LoiNhuan",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    ForeColor = Color.FromArgb(52, 152, 219)
                }
            });
        }

        private void AddMedalIcons()
        {
            for (int i = 0; i < dgvTopBooks.Rows.Count; i++)
            {
                // Add ranking number
                dgvTopBooks.Rows[i].Cells["Ranking"].Value = (i + 1).ToString();

                // Add medal for top 3
                string medal = "";
                switch (i)
                {
                    case 0:
                        medal = "🥇";
                        dgvTopBooks.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 220);
                        break;
                    case 1:
                        medal = "🥈";
                        dgvTopBooks.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        break;
                    case 2:
                        medal = "🥉";
                        dgvTopBooks.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 220);
                        break;
                    default:
                        medal = "";
                        break;
                }
                dgvTopBooks.Rows[i].Cells["Medal"].Value = medal;
            }
        }

        private void UpdateChart(DataTable data)
        {
            chartTopBooks.Series["Doanh Thu"].Points.Clear();

            if (data == null || data.Rows.Count == 0)
                return;

            // Reverse order for horizontal bar chart (top book at top)
            for (int i = data.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = data.Rows[i];
                string bookName = row["TenSach"].ToString();
                if (bookName.Length > 30)
                    bookName = bookName.Substring(0, 27) + "...";

                decimal revenue = row["DoanhThu"] != DBNull.Value ?
                    Convert.ToDecimal(row["DoanhThu"]) : 0;

                int pointIndex = chartTopBooks.Series["Doanh Thu"].Points.AddXY(bookName, revenue);
                
                // Color code top 3
                if (i == 0)
                    chartTopBooks.Series["Doanh Thu"].Points[pointIndex].Color = Color.FromArgb(241, 196, 15); // Gold
                else if (i == 1)
                    chartTopBooks.Series["Doanh Thu"].Points[pointIndex].Color = Color.FromArgb(189, 195, 199); // Silver
                else if (i == 2)
                    chartTopBooks.Series["Doanh Thu"].Points[pointIndex].Color = Color.FromArgb(230, 126, 34); // Bronze
                else
                    chartTopBooks.Series["Doanh Thu"].Points[pointIndex].Color = Color.FromArgb(52, 152, 219); // Blue
            }

            chartTopBooks.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private void FormTopBooksStatistic_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
