using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Duration.Logic;

namespace Duration.UI
{
    public partial class DurationUI : Form
    {
        public DurationUI()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (StartDateTimePicker.Text != null && EndDateTimePicker.Text != null)
            {
                var duration = new Duration.Logic.Duration(Convert.ToDateTime(StartDateTimePicker.Text),Convert.ToDateTime(EndDateTimePicker.Text));

                lblResult.Text = string.Format(" duration Class : {0} \n Date Time Function Class: \r Years : {1}; \r  Months : {2}; \r Days : {3}; \r TotalDays : {4}  ",
                    duration.Years, duration.Years, duration.Months, duration.Days, duration.TotalDays);
            }
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var duration = new Duration.Logic.Duration(Convert.ToDateTime(StartDateTimePicker.Text),Convert.ToDateTime(EndDateTimePicker.Text));

                lblResult.Text = string.Format(" duration Class : {0} \n Date Time Function Class: \r Years : {1}; \r  Months : {2}; \r Days : {3}; \r TotalDays : {4}  ",
                    duration.Years, duration.Years, duration.Months, duration.Days, duration.TotalDays);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var duration = new Duration.Logic.Duration(Convert.ToDateTime(StartDateTimePicker.Text), Convert.ToDateTime(EndDateTimePicker.Text));
                 lblResult.Text = string.Format(" duration Class : {0} \n Date Time Function Class: \r Years : {1}; \r  Months : {2}; \r Days : {3}; \r TotalDays : {4}  ",
                    duration.Years, duration.Years, duration.Months, duration.Days, duration.TotalDays);
            }
            catch (Exception)
            {

                throw;
            }

        }    }
}
