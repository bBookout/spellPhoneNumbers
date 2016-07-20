using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace spellPhoneNumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        string phoneNumber = null;  //declare an empty string placeholder for the number entered in the textbox
              
        //create a dictionary for all the possible letters on each number
        Dictionary<string, string> PossibleLetters = new Dictionary<string, string> {
            {"1", " " },
            {"2", "abc" },
            {"3", "def" },
            {"4", "ghi" },
            {"5", "jkl" },
            {"6", "mno" },
            {"7", "pqrs" },
            {"8", "tuv" },
            {"9", "wxyz" },
            {"0", " " },
        };

        //create a list of strings, cycle through each number, get each possible letter then return them
        public List<string> FromPhoneNumber(string phoneNumber)
        {
            var result = new List<string> { string.Empty };

            // cycle through each number in the phone number
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                var phoneNumList = new List<string>();
                foreach (var v in result)
                {
                    var letters = PossibleLetters[phoneNumber[i].ToString()];
                    // go through each possible letter of the number
                    for (int j = 0; j < letters.Length; j++)
                    {
                        phoneNumList.Add(v + letters[j]); //add them to the list                       
                    }
                }
                    result = phoneNumList; //result list becomes the list that we've added each letter combo to                
            }
                return result;//return the resulting list
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            phoneNumber = textBox1.Text;//set the phoneNumber string to the textbox text (number the user enters)                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber))//check for an empty string
                {
                    MessageBox.Show("Please enter a phone number without dashes. Numbers 0 and 1 will not have letter values.");
                    return;
                }
                //other validation could be done here ie. regEx search for special characters
                else
                {
                    listBox1.DataSource = (FromPhoneNumber(phoneNumber));//populate Listbox with string collection
                }                                                       //that is returned from function

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please try again. Enter a number without special characters.\n\n" + ex);
            }
        }
       
    }
}
