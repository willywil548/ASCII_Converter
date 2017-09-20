using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Group_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
#region Events
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtBlockUserOutPut.Text = "";
            txtUserInput.Text = "Input Data Here";
        }
        #endregion

        private void txtUserInput_KeyUP(object sender, System.Windows.Input.KeyEventArgs e)
        {
            DataInput addInput = new DataInput();
            addInput.num = addInput.ConvertData(txtUserInput.Text);
            txtBlockUserOutPut.Text = addInput.num;
        }
    }
    public class DataInput
    {
        //This property of DataInput isn't neccessary but was requried for the customer...customer asked for one property
        public string num { get; set; }

        public DataInput() { }
        // Method to kick off conversion of either numbers to letters or letters to numbers
        public string ConvertData(string arg)
        {
            bool isNum;
            string txtToWrite;
            isNum = checkNum(arg);//uses regex to check to see if numbers where inputed or text
            if(isNum)
            {
                txtToWrite = writeASCII(arg);
            }
            else
            {
                txtToWrite = writeNumber(arg);
            }
            return txtToWrite;
        }
        public bool checkNum(string arg)
        {
            Regex r = new Regex(@"^[0-9\s]+$");
            return r.Match(arg).Success;
        }
        public string writeASCII(string arg)
        {
            Char delimitor = ' ';
            arg = arg.Trim();
            string[] tempString = arg.Split(delimitor);
            int[] numToConvert=  new int[tempString.Length];
            for(int x = 0;x<tempString.Length;x++)
            {
                if(tempString[x].Length<4)
                {
                    numToConvert[x] = Convert.ToInt32(tempString[x]);
                }
                else
                {
                    MessageBox.Show("Number input must be between 32-126");
                    return "";
                }
                                   
            }
            string finalStringToReturn = "";
            foreach(int num in numToConvert)
            {
                if(num>31 && num<127)
                {
                    finalStringToReturn = finalStringToReturn + Convert.ToChar(num);
                }
                else
                {
                    finalStringToReturn = finalStringToReturn + " could not convert (" + num + ")";
                }
                
            }
            return finalStringToReturn;
        }
        //Convert 
        public string writeNumber(string arg)
        {
            string finalStringToReturn = "";
            foreach(char a in arg)
            {
                finalStringToReturn = finalStringToReturn + (int)a + " ";
            }
            return finalStringToReturn;
        }

        public void TransferData(string txt, TextBox thisBox)
        {
            thisBox.Text = txt;
        }
    }
}
