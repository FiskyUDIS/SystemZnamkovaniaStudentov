using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemZnamkovaniaStudentov
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, string>> subjectGrades = new Dictionary<string, Dictionary<string, string>>();
        private string currentSubject;
        private bool isTextChanging = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateStudentIDs()
        {
            for (int i = 0; i < dataGridViewPriezviskoMeno.Rows.Count; i++)
            {
                if (!dataGridViewPriezviskoMeno.Rows[i].IsNewRow)
                {
                    dataGridViewPriezviskoMeno.Rows[i].Cells["ColumnID"].Value = i + 1;
                }
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Check if the edited column is Column2Znamka (grades column)
            if (dataGridViewZnamky.CurrentCell.ColumnIndex == dataGridViewZnamky.Columns["Column2Znamka"].Index)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    // Remove previous event handlers to avoid duplication
                    textBox.TextChanged -= TextBox_TextChanged;
                    textBox.KeyDown -= TextBox_KeyDown;

                    // Add new event handlers
                    textBox.TextChanged += TextBox_TextChanged;
                    textBox.KeyDown += TextBox_KeyDown;
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isTextChanging) return; // Prevent recursive changes

            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                isTextChanging = true;

                string currentText = textBox.Text;

                // Remove invalid characters
                if (currentText.Length > 0 && !"12345,".Contains(currentText.Last()))
                {
                    currentText = currentText.Substring(0, currentText.Length - 1);
                    textBox.Text = currentText;
                    textBox.SelectionStart = currentText.Length;
                }

                // Automatically add a comma after valid grades
                if (currentText.Length > 0 && "12345".Contains(currentText.Last()))
                {
                    if (!currentText.EndsWith(","))
                    {
                        currentText += ",";
                        textBox.Text = currentText;
                        textBox.SelectionStart = currentText.Length;
                        //dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["Column2Priemer"].Value = "aa";
                    }
                }

                // Update the average in Column2Priemer
                //UpdateAverageForRow();

                isTextChanging = false;
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewZnamky.Columns["Column2Znamka"].Index)
            {
                UpdateAverageForAllRows();
            }
        }

        private void UpdateAverageForAllRows()
        {
            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridViewZnamky.Rows)
            {
                if (!row.IsNewRow) // Skip the new row placeholder
                {
                    string gradesText = row.Cells["Column2Znamka"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(gradesText))
                    {
                        // Parse the grades, ignoring empty values
                        var grades = gradesText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(g => int.TryParse(g, out int grade) ? grade : (int?)null)
                                               .Where(g => g.HasValue)
                                               .Select(g => g.Value)
                                               .ToList();

                        // Calculate the average
                        if (grades.Count > 0)
                        {
                            double average = grades.Average();
                            row.Cells["Column2Priemer"].Value = average.ToString("F2"); // Format to 2 decimal places
                        }
                        else
                        {
                            row.Cells["Column2Priemer"].Value = ""; // Clear if no valid grades
                        }
                    }
                    else
                    {
                        row.Cells["Column2Priemer"].Value = ""; // Clear if no grades
                    }
                }
            }
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.KeyCode == Keys.Back)
                {
                    string currentText = textBox.Text;

                    // Handle backspace to delete a grade and its trailing comma
                    if (currentText.Length > 0 && currentText.Last() == ',')
                    {
                        // Remove the trailing comma and the preceding grade
                        textBox.Text = currentText.Substring(0, currentText.Length - 2);
                        textBox.SelectionStart = textBox.Text.Length; // Keep cursor at the end
                        e.Handled = true; // Prevent default backspace behavior
                    }
                    else if (currentText.Length > 0)
                    {
                        // Remove just the last character (if not a trailing comma)
                        textBox.Text = currentText.Substring(0, currentText.Length - 1);
                        textBox.SelectionStart = textBox.Text.Length; // Keep cursor at the end
                        e.Handled = true; // Prevent default backspace behavior
                    }
                }
            }
        }


        private void SyncNames()
        {
            if (currentSubject == null) return;
            // Clear all rows in DataGridView2 before syncing
            dataGridViewZnamky.Rows.Clear();

            // Add names from DataGridView1 to DataGridView2, preserving any grades entered
            foreach (DataGridViewRow row in dataGridViewPriezviskoMeno.Rows)
            {
                if (!row.IsNewRow) // Skip the new row placeholder
                {
                    string id = row.Cells["ColumnID"].Value?.ToString();
                    string priezvisko = row.Cells["ColumnPriezvisko"].Value?.ToString();
                    string meno = row.Cells["ColumnMeno"].Value?.ToString();
                    string fullName = $"{priezvisko} {meno}";

                    // Find existing grade for this student (if any) using ID
                    string existingGrade = "";
                    if (subjectGrades.ContainsKey(currentSubject) && subjectGrades[currentSubject].ContainsKey(id))
                    {
                        existingGrade = subjectGrades[currentSubject][id]; // Get the existing grade
                    }

                    // Add the student to DataGridView2
                    dataGridViewZnamky.Rows.Add(id, priezvisko, meno, existingGrade);
                }
            }
            UpdateAverageForAllRows();
        }

        private void SaveCurrentSubjectGrades()
        {
            // Save grades from DataGridView2 to the dictionary for the current subject
            var grades = new Dictionary<string, string>();

            foreach (DataGridViewRow row in dataGridViewZnamky.Rows)
            {
                if (!row.IsNewRow)
                {
                    string id = row.Cells["Column2ID"].Value?.ToString();
                    string priezvisko = row.Cells["Column2Priezvisko"].Value?.ToString();
                    string meno = row.Cells["Column2Meno"].Value?.ToString();
                    string grade = row.Cells["Column2Znamka"].Value?.ToString();

                    grades[id] = grade; // Save grade by student ID
                }
            }

            if (currentSubject != null)
            {
                subjectGrades[currentSubject] = grades;
            }
        }

        private void LoadSubjectGrades(string subject)
        {
            if (subjectGrades.ContainsKey(subject))
            {
                var grades = subjectGrades[subject];

                foreach (DataGridViewRow row in dataGridViewZnamky.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string id = row.Cells["Column2ID"].Value?.ToString();

                        // Set the grade if it exists
                        if (grades.ContainsKey(id))
                        {
                            row.Cells["Column2Znamka"].Value = grades[id];
                        }
                        else
                        {
                            row.Cells["Column2Znamka"].Value = ""; // Default empty grade
                        }
                    }
                }
            }
        }

        private void buttonPridajStudenta_Click(object sender, EventArgs e)
        {
            // Add an empty student row to DataGridView1
            dataGridViewPriezviskoMeno.Rows.Add("", "", "");

            // Reassign IDs automatically
            UpdateStudentIDs();
            SaveCurrentSubjectGrades();
            SyncNames(); // Sync names after adding a student
        }

        private void buttonVymazStudenta_Click(object sender, EventArgs e)
        {
            var aktivnaBunka = dataGridViewPriezviskoMeno.CurrentCell;
            if (aktivnaBunka != null)
            {
                int cisloRiadku = aktivnaBunka.RowIndex;
                dataGridViewPriezviskoMeno.Rows.RemoveAt(cisloRiadku);

                // Reassign IDs automatically after removal
                UpdateStudentIDs();
                SyncNames(); // Sync names after removing a student
            }
        }

        private void buttonPridajPredmet_Click(object sender, EventArgs e)
        {
            string predmet = textBoxPridajPredmet.Text;
            if (!comboBoxSubjects.Items.Contains(predmet))
            {
                comboBoxSubjects.Items.Add(predmet);
                comboBoxVymazPredmet.Items.Add(predmet);
                subjectGrades[predmet] = new Dictionary<string, string>();
            }
            else
            {
                MessageBox.Show("Subject already exists.");
            }

            //currentSubject = predmet;

        }

        private void buttonVymazPredmet_Click(object sender, EventArgs e)
        {
            int index = comboBoxVymazPredmet.SelectedIndex;

            if (index != -1)
            {
                string predmet = comboBoxVymazPredmet.Items[index].ToString();
                comboBoxVymazPredmet.Items.RemoveAt(index);
                comboBoxSubjects.Items.Remove(predmet);

                if (subjectGrades.ContainsKey(predmet))
                {
                    subjectGrades.Remove(predmet);
                }

                if (currentSubject == predmet)
                {
                    currentSubject = null;
                    dataGridViewZnamky.Rows.Clear();
                    labelPredmet.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please select a subject to remove.");
            }
        }

        private void comboBoxSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentSubjectGrades();

            string selectedSubject = comboBoxSubjects.SelectedItem.ToString();
            currentSubject = selectedSubject;

            LoadSubjectGrades(currentSubject);
            SyncNames();
            labelPredmet.Text = currentSubject;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            // Open the OpenFileDialog to select a CSV file
            openFileDialogSubor.Filter = "CSV Files|*.csv";
            openFileDialogSubor.Title = "Select a CSV File";

            if (openFileDialogSubor.ShowDialog() != DialogResult.OK)
                return;

            string menoSuboru = openFileDialogSubor.FileName;

            try
            {
                // Open the file for reading
                StreamReader subor = new StreamReader(menoSuboru, Encoding.GetEncoding("windows-1250"));

                // Skip the header line (first row in the file)
                string hlavicka = subor.ReadLine();

                // Clear existing rows in the DataGridView
                dataGridViewPriezviskoMeno.Rows.Clear();

                // Read the file line by line
                string riadok;
                while ((riadok = subor.ReadLine()) != null)
                {
                    // Split the line by semicolon
                    string[] hodnoty = riadok.Split(';');

                    // Add the values to DataGridView1 (assumes two columns: Priezvisko and Meno)
                    if (hodnoty.Length >= 2)
                    {
                        dataGridViewPriezviskoMeno.Rows.Add("", hodnoty[0], hodnoty[1]);
                    }
                }

                // Close the file
                subor.Close();

                // Update the student IDs after importing
                UpdateStudentIDs();

                MessageBox.Show("Names imported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }
    }
}