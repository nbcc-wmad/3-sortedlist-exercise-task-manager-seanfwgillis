using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> taskList = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        #region Methods

        #endregion  

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string date = dtpTaskDate.Value.Date.ToString("d");

            if (txtTask.Text != String.Empty)
            {
                if(taskList.ContainsKey(date))
                {
                    MessageBox.Show("Only one task per date is allowed.", "Invalid Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    taskList.Add(dtpTaskDate.Value.Date.ToString("d"), txtTask.Text);
                    lstTasks.Items.Add(dtpTaskDate.Value.Date.ToString("d"));
                    txtTask.Text = String.Empty;

                }            
            }
            else
            {
                MessageBox.Show("You must enter a task.", "Invalid Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTaskDetails.Text = String.Empty;

            if (lstTasks.SelectedIndex != -1)
            {
                lblTaskDetails.Text = taskList[lstTasks.SelectedItem.ToString()];
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                taskList.Remove(lstTasks.SelectedItem.ToString());
                lstTasks.Items.Remove(lstTasks.SelectedItem);
                lstTasks.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("You must select a task to remove", "Invalid Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            if (taskList.Count != 0)
            {
                foreach(KeyValuePair<string, string> task in taskList)
                {
                    msg += $"{task.Key}, {task.Value} \n";
                }

                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("There are no chores to do!", "Great News!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

}
