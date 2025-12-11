using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLNS_BLL;

namespace QLNS.Forms.Statistic
{
    public partial class FormInventoryStatistic : Form
    {
        private BaoCao_BLL baoCaoBLL = new BaoCao_BLL();
        private TheLoai_BLL theLoaiBLL = new TheLoai_BLL();
        private DataTable currentData;

        public FormInventoryStatistic()
        {
            InitializeComponent();
            LoadDefaultData();
            SetupDataGridView();
            SetupChart();
        }

        private void LoadDefaultData()
        {
            // Load categories into combo box
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Tất cả thể loại");
            
            var categories = theLoaiBLL.LayDanhSachTheLoai();
            foreach (var cat in categories)
            {
                cboCategory.Items.Add(cat.TenTheLoai);
            }
            
            cboCategory.SelectedIndex = 0;
            nudThreshold.Value = 10; // Low stock threshold
            chkLowStockOnly.Checked = false;
        }

        private void SetupDataGridView()
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.ReadOnly = true;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = false;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.EnableHeadersVisualStyles = false;
            
            // Header styling
            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvInventory.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvInventory.ColumnHeadersHeight = 40;
            
            dgvInventory.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvInventory.RowTemplate.Height = 35;
            
            // Row painting event for color coding
            dgvInventory.RowPrePaint += DgvInventory_RowPrePaint;
        }

        private void DgvInventory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvInventory.Rows.Count)
                return;

            var row = dgvInventory.Rows[e.RowIndex];
            if (row.Cells["SoLuongTon"].Value != null)
            {
                int stock = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                
                if (stock < 5)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Light red
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43); // Dark red
                }
                else if (stock < 10)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230); // Light yellow
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(243, 156, 18); // Orange
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void SetupChart()
        {
            chartInventory.Series.Clear();
            chartInventory.ChartAreas.Clear();
            chartInventory.Legends.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartInventory.ChartAreas.Add(chartArea);

            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Bottom;
            legend.Font = new Font("Segoe UI", 9F);
            chartInventory.Legends.Add(legend);

            Series series = new Series("Tồn Kho");
            series.ChartType = SeriesChartType.Pie;
            series.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chartInventory.Series.Add(series);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string selectedCategory = cboCategory.SelectedIndex == 0 ? null : cboCategory.Text;
                int threshold = (int)nudThreshold.Value;

                if (chkLowStockOnly.Checked)
                {
                    currentData = baoCaoBLL.LaySachSapHet(threshold);
                }
                else
                {
                    currentData = baoCaoBLL.LayTonKhoChiTiet(selectedCategory);
                }

                if (currentData == null || currentData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvInventory.DataSource = null;
                    UpdateSummary(0, 0, 0);
                    UpdateChart(null);
                    return;
                }

                SetupDataGridViewColumns();
                dgvInventory.DataSource = currentData;
                CalculateAndDisplaySummary();
                UpdateChartByCategory();
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
            dgvInventory.Columns.Clear();

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Sách",
                DataPropertyName = "MaSach",
                Width = 100
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Sách",
                DataPropertyName = "TenSach",
                Width = 250
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thể Loại",
                DataPropertyName = "TenTheLoai",
                Width = 120
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NXB",
                DataPropertyName = "TenNXB",
                Width = 150
            });

            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tồn Kho",
                DataPropertyName = "SoLuongTon",
                Name = "SoLuongTon",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            };
            dgvInventory.Columns.Add(colStock);

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá Nhập",
                DataPropertyName = "DonGiaNhap",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá Bán",
                DataPropertyName = "DonGiaBan",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            if (currentData.Columns.Contains("GiaTriTonKho"))
            {
                dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Giá Trị Tồn",
                    DataPropertyName = "GiaTriTonKho",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N0",
                        ForeColor = Color.FromArgb(52, 152, 219)
                    }
                });
            }
        }

        private void CalculateAndDisplaySummary()
        {
            int totalBooks = currentData.Rows.Count;
            int totalStock = 0;
            decimal totalValue = 0;

            foreach (DataRow row in currentData.Rows)
            {
                if (row["SoLuongTon"] != DBNull.Value)
                    totalStock += Convert.ToInt32(row["SoLuongTon"]);
                
                if (currentData.Columns.Contains("GiaTriTonKho") && row["GiaTriTonKho"] != DBNull.Value)
                    totalValue += Convert.ToDecimal(row["GiaTriTonKho"]);
            }

            UpdateSummary(totalBooks, totalStock, totalValue);
        }

        private void UpdateSummary(int totalBooks, int totalStock, decimal totalValue)
        {
            lblTotalBooks.Text = $"Tổng Số Đầu Sách: {totalBooks}";
            lblTotalStock.Text = $"Tổng Số Lượng: {totalStock:N0}";
            lblTotalValue.Text = $"Giá Trị Tồn Kho: {totalValue:N0} ₫";
        }

        private void UpdateChartByCategory()
        {
            var categoryData = baoCaoBLL.LayTonKhoTheoTheLoai();
            UpdateChart(categoryData);
        }

        private void UpdateChart(DataTable data)
        {
            chartInventory.Series["Tồn Kho"].Points.Clear();

            if (data == null || data.Rows.Count == 0)
                return;

            // Use vibrant colors for pie chart
            Color[] colors = new Color[]
            {
                Color.FromArgb(52, 152, 219),  // Blue
                Color.FromArgb(46, 204, 113),  // Green
                Color.FromArgb(155, 89, 182),  // Purple
                Color.FromArgb(241, 196, 15),  // Yellow
                Color.FromArgb(230, 126, 34),  // Orange
                Color.FromArgb(231, 76, 60),   // Red
                Color.FromArgb(149, 165, 166), // Gray
                Color.FromArgb(26, 188, 156)   // Teal
            };

            int colorIndex = 0;
            foreach (DataRow row in data.Rows)
            {
                string category = row["TenTheLoai"].ToString();
                int quantity = Convert.ToInt32(row["TongSoLuong"]);

                int pointIndex = chartInventory.Series["Tồn Kho"].Points.AddXY(category, quantity);
                chartInventory.Series["Tồn Kho"].Points[pointIndex].Color = colors[colorIndex % colors.Length];
                chartInventory.Series["Tồn Kho"].Points[pointIndex].Label = $"{category}\n{quantity:N0}";
                
                colorIndex++;
            }

            chartInventory.Series["Tồn Kho"].IsValueShownAsLabel = false;
            chartInventory.Series["Tồn Kho"]["PieLabelStyle"] = "Outside";
        }

        private void FormInventoryStatistic_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void chkLowStockOnly_CheckedChanged(object sender, EventArgs e)
        {
            nudThreshold.Enabled = chkLowStockOnly.Checked;
        }
    }
}
