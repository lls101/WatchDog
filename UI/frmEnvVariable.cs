using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchDog
{
    public partial class frmEnvVariable : Form
    {
        private List<EnvVariable> envVariables;
        private DataGridViewRow selectedRow = null;
        public frmEnvVariable()
        {
            InitializeComponent();
        }
        private void frmEnvVariable_Load(object sender, EventArgs e)
        {
            envVariables = Tag as List<EnvVariable> ?? new List<EnvVariable>();
            if (envVariables.Any())
                Init();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvEnvs.Rows.Add(new DataGridViewRow());
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                Global.Tips("请先选择需要删除的变量");
                return;
            }
            dgvEnvs.Rows.Remove(selectedRow);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dgvEnvs.EndEdit();
            envVariables.Clear();
            foreach (DataGridViewRow row in dgvEnvs.Rows)
            {
                var key = row.Cells[0].Value?.ToString() ?? string.Empty;
                var value = row.Cells[1].Value?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
                    continue;
                if (!envVariables.Any(a => a.Key == key))
                {
                    envVariables.Add(new EnvVariable(key, value));
                }
            }
            Tag = envVariables;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void dgvEnvs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex > 0)
            {
                selectedRow = dgvEnvs.Rows[rowIndex];
            }
            else
            {
                selectedRow = null;
            }
        }
        private void Init()
        {
            dgvEnvs.ClearSelection();
            foreach (var env in envVariables)
            {
                var rowIndex = dgvEnvs.Rows.Add(new DataGridViewRow());
                dgvEnvs.Rows[rowIndex].Cells[0].Value = env.Key;
                dgvEnvs.Rows[rowIndex].Cells[1].Value = env.Value;
            }
        }
    }
}
