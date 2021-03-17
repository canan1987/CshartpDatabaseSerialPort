using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace DatabaseApplication
{
    public partial class Form1 : Form
    {
        static SerialPort myPort;
        static string portData = "";

        private const string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/FutApsol/DatabaseApplication/FactConnect1.mdb;";
        readonly OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
       
       // readonly DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();

          /*  dgViewDispData.ColumnCount = 15;
            dgViewDispData.Columns[0].Name = "Part Number";
            dgViewDispData.Columns[1].Name = "Date Time";
            dgViewDispData.Columns[2].Name = "Test Result";
            dgViewDispData.Columns[3].Name = "Testing Mode";
            dgViewDispData.Columns[4].Name = "Pass Count";
            dgViewDispData.Columns[5].Name = "Fail Count";
            dgViewDispData.Columns[6].Name = "Fail Type Points";
            dgViewDispData.Columns[7].Name = "Cutter Count";
            dgViewDispData.Columns[8].Name = "Label Serial Number";
            dgViewDispData.Columns[9].Name = "Printed Barcode";
            dgViewDispData.Columns[10].Name = "Operator Code";
            dgViewDispData.Columns[11].Name = "Shift";
            dgViewDispData.Columns[12].Name = "Lot Count";
            dgViewDispData.Columns[13].Name = "Lot Quantity";
            dgViewDispData.Columns[13].Name = "Custom Field";

            dgViewDispData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgViewDispData.MultiSelect = false; */

            // myPort = new SerialPort("COM4", 9600);
            //lblDisp.AutoSize = true;
            // myPort.Open();

            try {
               // con.Open();

               retrieveData();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            //myPort.Open();

            try {
                myPort = new SerialPort("COM4", 9600);
                myPort.Open();

                myPort.DataReceived += new SerialDataReceivedEventHandler(myPort_DataReceived);
                myPort.ReceivedBytesThreshold = 1;

                

                //string all = myPort.ReadExisting();

    }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

            

            //lblDisp.Text = all;

          //  richTextBox1.Text = all;
        }

        public void portDataOperation( string portReceivedDate)
        {
            string[] portDataArr = portReceivedDate.Split(',');
            int portDateArrLenght = portDataArr.Length;

            classes.PortDataDetails portDetailsObj = new classes.PortDataDetails();

            if (portDateArrLenght >= 17)
            {
                portDetailsObj.partNumber = portDataArr[0];
                portDetailsObj.revisionNumber = portDataArr[1];
                portDetailsObj.dateTime = portDataArr[2] + ' ' + portDataArr[3];
                portDetailsObj.testResult = portDataArr[4];
                portDetailsObj.testingMode = portDataArr[5];
                portDetailsObj.passCount = portDataArr[6];
                portDetailsObj.failCount = portDataArr[7];
                portDetailsObj.failTypePoints = portDataArr[8];
                portDetailsObj.cutterCount = portDataArr[9];
                portDetailsObj.labelSerialNumber = portDataArr[10];
                portDetailsObj.printedBarCode = portDataArr[11];
                portDetailsObj.operatorCode = portDataArr[12];
                portDetailsObj.shift = portDataArr[13];
                portDetailsObj.lotCount = portDataArr[14];
                portDetailsObj.lotQuantity = portDataArr[15];
                portDetailsObj.customField = portDataArr[16];

                //MessageBox.Show(portDetailsObj.ToString());

                insertPortData(portDetailsObj);
            }

            //MessageBox.Show(portDateArrLenght.ToString());
        }

        public void insertPortData(classes.PortDataDetails portDetObj) {

            const string insertQuerystr = "insert into Face_Connect(" +
                "part_number, " +
                "date_time, " +
                "test_result, " +
                "testing_mode, " +
                "pass_count, " +
                "fail_count, " +
                "fail_type_points, " +
                "cutter_count, " +
                "label_serial_number, " +
                "printed_barcode, " +
                "operator_code, " +
                "shift, " +
                "lot_count, " +
                "lot_quantity, " +
                "custom_field)" +
                "values(" +
                "@partNumber, " +
                "@dateTime, " +
                "@testResult, " +
                "@testingMode, " +
                "@passCount, " +
                "@failCount, " +
                "@failTypePoints, " +
                "@cutterCount, " +
                "@labelSerialNumber, " +
                "@printedBarCode, " +
                "@operatorCode, " +
                "@shift, " +
                "@lotCount, " +
                "@lotQuantity, " +
                "@customField)";

            cmd = new OleDbCommand(insertQuerystr, con);

            cmd.Parameters.AddWithValue("@partNumber", portDetObj.partNumber);
            cmd.Parameters.AddWithValue("@dateTime", portDetObj.dateTime);
            cmd.Parameters.AddWithValue("@testResult", portDetObj.testResult);
            cmd.Parameters.AddWithValue("@testingMode", portDetObj.testingMode);
            cmd.Parameters.AddWithValue("@passCount", portDetObj.passCount);
            cmd.Parameters.AddWithValue("@failCount", portDetObj.failCount);
            cmd.Parameters.AddWithValue("@failTypePoints", portDetObj.failTypePoints);
            cmd.Parameters.AddWithValue("@cutterCount", portDetObj.cutterCount);
            cmd.Parameters.AddWithValue("@labelSerialNumber", portDetObj.labelSerialNumber);
            cmd.Parameters.AddWithValue("@printedBarCode", portDetObj.printedBarCode);
            cmd.Parameters.AddWithValue("@operatorCode", portDetObj.operatorCode);
            cmd.Parameters.AddWithValue("@shift", portDetObj.shift);
            cmd.Parameters.AddWithValue("@lotCount", portDetObj.lotCount);
            cmd.Parameters.AddWithValue("@lotQuantity", portDetObj.lotQuantity);
            cmd.Parameters.AddWithValue("@customField", portDetObj.customField);

           

            try {

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                   
                    MessageBox.Show("Data inserted successfully");
                }
                con.Close();

                //retrieveData();

            }
            catch(Exception ex) {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void populateGridView(string partNumber, string dateTime, string testResult, string testingMode, string passCount, string failCount, string failTypePints, string cutterCount, string labelSerialNumber, string printedBarCode, string operatorCode, string shift, string lotCount, string lotQuantity, string customField) {
            dgViewDispData.Rows.Add(partNumber, dateTime, testResult, testingMode, passCount, failCount, failTypePints, cutterCount, labelSerialNumber, printedBarCode, operatorCode, shift, lotCount, lotQuantity, customField);
        }

        private void retrieveData() {

            try {
                cmd = new OleDbCommand("select *from Face_Connect", con);
                adapter = new OleDbDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgViewDispData.DataSource = dt;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

            /*  dgViewDispData.Rows.Clear();

              string retrieveDataQuery = "select *from Face_Connect";
              cmd = new OleDbCommand(retrieveDataQuery, con);

              try {
                  con.Open();
                  adapter = new OleDbDataAdapter(cmd);
                  adapter.Fill(dt);

                  foreach(DataRow row in dt.Rows)
                  {
                      populateGridView(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString());
                  }

                  con.Close();
                  dt.Rows.Clear(); 
              }
              catch(Exception ex) {
                  MessageBox.Show(ex.Message);
              }*/
        }

        public void myPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string newPortData = myPort.ReadExisting();

               

                //portData = portData + "   " + newPortData;

                //richTextBox1.Text = "";
                //richTextBox1.Text = portData;

                portDataOperation(newPortData);

                //Console.WriteLine(myPort.ReadExisting());

               // MessageBox.Show(myPort.ReadExisting());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDispData_Click(object sender, EventArgs e)
        {
            try {
                retrieveData();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            myPort.Write("Chandan");
        }
    }
}
