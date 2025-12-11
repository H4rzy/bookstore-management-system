using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLNS_BLL;

namespace QLNS.Forms.Statistic
{
    public partial class FormCustomerStatistic : Form
    {
        private BaoCao_BLL baoCaoBLL = new BaoCao_BLL();
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private DataTable currentData;

        public FormCustomerStatistic()
        {
            InitializeComponent();
            SetupDataGridViews();
            SetupChart();
        }

        private void SetupDataGridViews()
        {
            // Setup for all DataGridViews
            foreach (var dgv in new[] { dgvTopCustomers, dgvVIPStats, dgvPurchaseHistory })
            {
                dgv.AutoGenerateColumns = false;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.RowHeadersVisible = false;
                dgv.EnableHeadersVisualStyles = false;
                
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
                dgv.ColumnHeadersHeight = 40;
                
                dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F);
                dgv.RowTemplate.Height = 35;
            }
        }

        private void SetupChart()
        {
            chartVIP.Series.Clear();
            chartVIP.ChartAreas.Clear();
            chartVIP.Legends.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartVIP.ChartAreas.Add(chartArea);

            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Bottom;
            legend.Font = new Font("Segoe UI", 10F);
            chartVIP.Legends.Add(legend);

            Series series = new Series("VIP Tiers");
            series.ChartType = SeriesChartType.Doughnut;
            series.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartVIP.Series.Add(series);
        }

        private void FormCustomerStatistic_Load(object sender, EventArgs e)
        {
            LoadDefaultData();
            LoadTopCustomers();
        }

        private void LoadDefaultData()
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            nudTopN.Value = 10;

            // Load customers for purchase history
            cboCustomer.Items.Clear();
            cboCustomer.Items.Add("-- Chọn khách hàng --");
            var customers = khachHangBLL.LayDanhSachKhachHang();
            foreach (var cust in customers)
            {
                cboCustomer.Items.Add($"{cust.MaKH} - {cust.TenKH}");
            }
            cboCustomer.SelectedIndex = 0;
        }

        private void btnRefreshTop_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadTopCustomers();
        }

        private void LoadTopCustomers()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int topN = (int)nudTopN.Value;
                
                currentData = baoCaoBLL.LayTopKhachHang(dtpStartDate.Value, dtpEndDate.Value, topN);

                if (currentData == null || currentData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTopCustomers.DataSource = null;
                    return;
                }

                SetupTopCustomersColumns();
                dgvTopCustomers.DataSource = currentData;
                AddRankingToTopCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetupTopCustomersColumns()
        {
            dgvTopCustomers.Columns.Clear();

            dgvTopCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "#",
                Name = "Rank",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 152, 219)
                }
            });

            dgvTopCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã KH",
                DataPropertyName = "MaKH",
                Width = 80
            });

            dgvTopCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Khách Hàng",
                DataPropertyName = "TenKH",
                Width = 200
            });

            dgvTopCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điện Thoại",
                DataPropertyName = "DienThoai",
                Width = 120
            });

            dgvTopCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số HĐ",
                DataPropertyName = "SoHoaDon",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvTopCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng Chi Tiêu",
                DataPropertyName = "TongChiTieu",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(46, 204, 113)
                }
            });

            dgvTopCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lần Mua Gần Nhất",
                DataPropertyName = "LanMuaGanNhat",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });
        }

        private void AddRankingToTopCustomers()
        {
            for (int i = 0; i < dgvTopCustomers.Rows.Count; i++)
            {
                dgvTopCustomers.Rows[i].Cells["Rank"].Value = (i + 1).ToString();
                
                if (i < 3)
                {
                    dgvTopCustomers.Rows[i].DefaultCellStyle.BackColor = 
                        i == 0 ? Color.FromArgb(255, 250, 220) :
                        i == 1 ? Color.FromArgb(245, 245, 245) :
                        Color.FromArgb(255, 240, 220);
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1) // VIP Stats tab
            {
                LoadVIPStatistics();
            }
        }

        private void LoadVIPStatistics()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var data = baoCaoBLL.LayThongKeVIP();

                if (data == null || data.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu VIP!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvVIPStats.DataSource = null;
                    return;
                }

                SetupVIPStatsColumns();
                dgvVIPStats.DataSource = data;
                UpdateVIPChart(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetupVIPStatsColumns()
        {
            dgvVIPStats.Columns.Clear();

            dgvVIPStats.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hạng Thẻ",
                DataPropertyName = "HangThe",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            });

            dgvVIPStats.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Lượng",
                DataPropertyName = "SoLuong",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            });

            dgvVIPStats.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm TB",
                DataPropertyName = "DiemTrungBinh",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "N0"
                }
            });

            dgvVIPStats.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Chi Tiêu TB",
                DataPropertyName = "ChiTieuTrungBinh",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            dgvVIPStats.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng Chi Tiêu",
                DataPropertyName = "TongChiTieu",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(46, 204, 113)
                }
            });
        }

        private void UpdateVIPChart(DataTable data)
        {
            chartVIP.Series["VIP Tiers"].Points.Clear();

            Color[] colors = new Color[]
            {
                Color.FromArgb(241, 196, 15),  // Platinum - Gold
                Color.FromArgb(189, 195, 199), // Silver - Gray
                Color.FromArgb(230, 126, 34)   // Bronze - Orange
            };

            int colorIndex = 0;
            foreach (DataRow row in data.Rows)
            {
                string tier = row["HangThe"].ToString();
                int count = Convert.ToInt32(row["SoLuong"]);

                int pointIndex = chartVIP.Series["VIP Tiers"].Points.AddXY(tier, count);
                chartVIP.Series["VIP Tiers"].Points[pointIndex].Color = colors[colorIndex % colors.Length];
                chartVIP.Series["VIP Tiers"].Points[pointIndex].Label = $"{tier}\n{count} KH";
                
                colorIndex++;
            }

            chartVIP.Series["VIP Tiers"]["PieLabelStyle"] = "Outside";
        }

        private void btnSearchHistory_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadPurchaseHistory();
        }

        private void LoadPurchaseHistory()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                string selectedText = cboCustomer.Text;
                string maKH = selectedText.Split('-')[0].Trim();

                var data = baoCaoBLL.LayLichSuMuaHangKhachHang(maKH, dtpHistoryStart.Value, dtpHistoryEnd.Value);

                if (data == null || data.Rows.Count == 0)
                {
                    MessageBox.Show("Không có lịch sử mua hàng!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPurchaseHistory.DataSource = null;
                    return;
                }

                SetupPurchaseHistoryColumns();
                dgvPurchaseHistory.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetupPurchaseHistoryColumns()
        {
            dgvPurchaseHistory.Columns.Clear();

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số HĐ",
                DataPropertyName = "SoHD",
                Width = 120
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Lập",
                DataPropertyName = "NgayLap",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm"
                }
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nhân Viên",
                DataPropertyName = "NhanVienBan",
                Width = 150
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Mặt Hàng",
                DataPropertyName = "SoMatHang",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng SL",
                DataPropertyName = "TongSoLuong",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng Tiền",
                DataPropertyName = "TongTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            });
        }
    }
}
