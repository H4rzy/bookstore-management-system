using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QLNS_UI.Common
{
    /// <summary>
    /// Helper class để binding và thao tác với controls
    /// </summary>
    public static class ControlHelper
    {
        // ========== DATAGRIDVIEW ==========

        public static void BindDataGridView<T>(DataGridView dgv, List<T> data)
        {
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = data ?? new List<T>();
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi hiển thị dữ liệu", ex.Message);
            }
        }

        public static void BindDataGridView(DataGridView dgv, DataTable data)
        {
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = data ?? new DataTable();
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi hiển thị dữ liệu", ex.Message);
            }
        }

        public static void ClearDataGridView(DataGridView dgv)
        {
            dgv.DataSource = null;
        }

        public static T GetSelectedRow<T>(DataGridView dgv) where T : class
        {
            try
            {
                if (dgv.CurrentRow == null || dgv.CurrentRow.DataBoundItem == null)
                    return null;
                return dgv.CurrentRow.DataBoundItem as T;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsRowSelected(DataGridView dgv)
        {
            return dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0;
        }

        public static void HighlightInvalidCell(DataGridView dgv, int rowIndex, int colIndex)
        {
            if (rowIndex >= 0 && colIndex >= 0)
            {
                dgv.Rows[rowIndex].Cells[colIndex].Style.BackColor = Color.LightCoral;
            }
        }

        public static void ClearHighlight(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = dgv.DefaultCellStyle.BackColor;
                }
            }
        }

        // ========== COMBOBOX ==========

        public static void BindComboBox<T>(ComboBox cbo, List<T> data, string displayMember, string valueMember)
        {
            try
            {
                cbo.DataSource = null;
                cbo.DataSource = data ?? new List<T>();
                cbo.DisplayMember = displayMember;
                cbo.ValueMember = valueMember;
                cbo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load ComboBox", ex.Message);
            }
        }

        public static void BindComboBox(ComboBox cbo, DataTable data, string displayMember, string valueMember)
        {
            try
            {
                cbo.DataSource = null;
                cbo.DataSource = data ?? new DataTable();
                cbo.DisplayMember = displayMember;
                cbo.ValueMember = valueMember;
                cbo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load ComboBox", ex.Message);
            }
        }

        public static void SetComboBoxValue(ComboBox cbo, object value)
        {
            try
            {
                cbo.SelectedValue = value;
            }
            catch { }
        }

        public static object GetComboBoxValue(ComboBox cbo)
        {
            return cbo.SelectedValue;
        }

        public static void ClearComboBox(ComboBox cbo)
        {
            cbo.DataSource = null;
            cbo.Items.Clear();
            cbo.SelectedIndex = -1;
        }

        // ========== TEXTBOX ==========

        public static void BindTextBox<T>(TextBox txt, T obj, string propertyName)
        {
            try
            {
                if (obj == null) return;
                PropertyInfo prop = typeof(T).GetProperty(propertyName);
                if (prop != null)
                {
                    object value = prop.GetValue(obj);
                    txt.Text = value?.ToString() ?? string.Empty;
                }
            }
            catch { }
        }

        public static void ClearTextBoxes(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                }
                else if (ctrl.HasChildren)
                {
                    ClearTextBoxes(ctrl);
                }
            }
        }

        public static bool ValidateRequiredTextBox(TextBox txt, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageHelper.ShowRequiredFieldError(fieldName);
                txt.Focus();
                return false;
            }
            return true;
        }

        // ========== LISTVIEW ==========

        public static void BindListView<T>(ListView lv, List<T> data, string[] columnNames)
        {
            try
            {
                lv.Items.Clear();
                lv.Columns.Clear();

                if (columnNames != null)
                {
                    foreach (var col in columnNames)
                    {
                        lv.Columns.Add(col);
                    }
                }

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        PropertyInfo[] props = typeof(T).GetProperties();
                        
                        for (int i = 0; i < props.Length && i < columnNames.Length; i++)
                        {
                            object value = props[i].GetValue(item);
                            if (i == 0)
                                lvItem.Text = value?.ToString() ?? "";
                            else
                                lvItem.SubItems.Add(value?.ToString() ?? "");
                        }
                        lv.Items.Add(lvItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi hiển thị ListView", ex.Message);
            }
        }

        public static ListViewItem GetSelectedListViewItem(ListView lv)
        {
            if (lv.SelectedItems.Count > 0)
                return lv.SelectedItems[0];
            return null;
        }

        public static void ClearListView(ListView lv)
        {
            lv.Items.Clear();
        }

        // ========== NUMERIC & DATETIME ==========

        public static bool ValidateNumericUpDown(NumericUpDown num, string fieldName)
        {
            if (num.Value <= 0)
            {
                MessageHelper.ShowError("Lỗi nhập liệu", $"{fieldName} phải lớn hơn 0");
                num.Focus();
                return false;
            }
            return true;
        }

        public static int GetNumericUpDownValue(NumericUpDown num)
        {
            return (int)num.Value;
        }

        public static void SetNumericUpDownValue(NumericUpDown num, int value)
        {
            num.Value = value;
        }

        public static void BindDateTimePicker(DateTimePicker dtp, DateTime? date)
        {
            if (date.HasValue)
                dtp.Value = date.Value;
            else
                dtp.Value = DateTime.Now;
        }

        public static DateTime GetDateTimePickerValue(DateTimePicker dtp)
        {
            return dtp.Value;
        }

        // ========== TREEVIEW ==========

        /// <summary>
        /// Populate TreeView với "Tất cả" root node và danh sách items
        /// </summary>
        /// <typeparam name="T">DTO type</typeparam>
        /// <param name="tree">TreeView control</param>
        /// <param name="data">List of data</param>
        /// <param name="displayProperty">Property name for display text</param>
        /// <param name="valueProperty">Property name for tag value</param>
        /// <param name="rootText">Text for root node (default: "Tất cả")</param>
        public static void PopulateTreeView<T>(TreeView tree, List<T> data, string displayProperty, string valueProperty, string rootText = "Tất cả")
        {
            try
            {
                tree.Nodes.Clear();

                // Tạo root node "Tất cả"
                TreeNode rootNode = new TreeNode(rootText);
                rootNode.Tag = null; // null = tất cả
                tree.Nodes.Add(rootNode);

                // Thêm các items
                if (data != null)
                {
                    PropertyInfo displayProp = typeof(T).GetProperty(displayProperty);
                    PropertyInfo valueProp = typeof(T).GetProperty(valueProperty);

                    if (displayProp != null && valueProp != null)
                    {
                        foreach (var item in data)
                        {
                            string displayText = displayProp.GetValue(item)?.ToString() ?? "";
                            string tagValue = valueProp.GetValue(item)?.ToString() ?? "";

                            TreeNode node = new TreeNode(displayText);
                            node.Tag = tagValue;
                            rootNode.Nodes.Add(node);
                        }
                    }
                }

                // Expand root node
                rootNode.Expand();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load TreeView", ex.Message);
            }
        }

        /// <summary>
        /// Get selected node's Tag value from TreeView
        /// </summary>
        public static string GetTreeViewSelectedValue(TreeView tree)
        {
            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null)
            {
                return tree.SelectedNode.Tag.ToString();
            }
            return null;
        }

        /// <summary>
        /// Clear TreeView
        /// </summary>
        public static void ClearTreeView(TreeView tree)
        {
            tree.Nodes.Clear();
        }
    }
}
