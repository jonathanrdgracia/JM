
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.BackupDB
{
    public partial class Back : Form
    {
        public Back()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            try
            {
                var ServerName = ".";
                var DataName="Presupuesto";

                 Microsoft.SqlServer.Management.Smo.Server dbserver = new Microsoft.SqlServer.Management.Smo.Server(new ServerConnection(ServerName));

                Backup dbBackup=new Backup (){Action =BackupActionType.Database,Database=DataName};
                dbBackup.Devices.AddDevice(@"C:\Data\Presupuesto.bak", DeviceType.File);
                dbBackup.Initialize = true;
                dbBackup.PercentComplete+=dbBackup_PercentComplete;
                dbBackup.Complete+=dbBackup_Complete;
                dbBackup.SqlBackupAsync(dbserver);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error!=null)
            {
                lbStatus.Invoke((MethodInvoker)delegate
                {
                    lbStatus.Text = e.Error.Message;
                });
            }
        }

        private void dbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
           progressBar1.Invoke((MethodInvoker)delegate
           {
               progressBar1.Value = e.Percent;
               progressBar1.Update();
           });

           label1.Invoke((MethodInvoker)delegate
           {
               label1.Text = e.Percent + "%";
           });
        }
    }
}
