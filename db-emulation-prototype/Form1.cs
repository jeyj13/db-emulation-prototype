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

namespace db_emulation_prototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] savelines = new string[4];
            savelines[1] = txtName.Text;
            savelines[2] = txtInfo1.Text;
            savelines[3] = " ";
            save_data(savelines);

        }

        public void read_data ()
        {
            int counter = 0;
            string line;
            System.IO.StreamReader filein =
            new System.IO.StreamReader("c:/users/jey/documents/visual studio 2015/Projects/db-emulation-prototype/db-emulation-prototype/db.txt");
            while ((line = filein.ReadLine()) != null)
            {
                lstOut.Items.Add(line);
                counter++;
            }
            filein.Close();
        }

        public void save_data(string [] lines)
        {
            string[] lineholder = new string[255];
            string linein;
            int counter = 0;
            bool isNum;
            int n;
            // Read the file and display it line by line.
            System.IO.StreamReader filein =
               new System.IO.StreamReader("c:/users/jey/documents/visual studio 2015/Projects/db-emulation-prototype/db-emulation-prototype/db.txt");
            while ((linein = filein.ReadLine()) != null)
            {
                lineholder[counter] = linein;
                counter++;
            }
            for(int o =0; o < counter; o++)
            {
                if ((isNum = int.TryParse(lineholder[o], out n)) == true)
                {
                    lines[0] = (n + 1).ToString();
                }
            }
            filein.Close();
            using (StreamWriter fileout =
        File.AppendText("c:/users/jey/documents/visual studio 2015/Projects/db-emulation-prototype/db-emulation-prototype/db.txt"))
            {

                foreach (string line in lines)
                {

                    {
                        fileout.WriteLine(line);
                    }
                }
                fileout.Close();
            }
        }
    }

}
