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
        // Tu máme slovník, kde si ukladáme známky študentov podľa predmetov
        private Dictionary<string, Dictionary<string, string>> subjectGrades = new Dictionary<string, Dictionary<string, string>>();
        private string currentSubject; // Tu si pamätáme, ktorý predmet je aktuálne vybraný
        private bool isTextChanging = false; // Zabráni nekonečným cyklom pri zmene textu v bunkách

        public Form1()
        {
            InitializeComponent(); // Štandardná inicializácia komponentov formulára
        }
        // Funkcia, ktorá aktualizuje ID študentov v prvom DataGridView (zoznam študentov)
        private void UpdateStudentIDs()
        {
            for (int i = 0; i < dataGridViewPriezviskoMeno.Rows.Count; i++)
            {
                if (!dataGridViewPriezviskoMeno.Rows[i].IsNewRow) // Ignorujeme posledný prázdny riadok
                {
                    dataGridViewPriezviskoMeno.Rows[i].Cells["ColumnID"].Value = i + 1;
                }
            }
        }
        // Keď začneme editovať bunku v druhom DataGridView, pridáme event handlery na kontrolu známok
        private void dataGridViewZnamky_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
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
        // Kontrola vstupu pri zadávaní známok
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isTextChanging) return; // Prevent recursive changes

            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                isTextChanging = true;

                string currentText = textBox.Text;

                // Ak posledný znak nie je číslo 1-5 alebo čiarka, tak ho zmažeme
                if (currentText.Length > 0 && !"12345,".Contains(currentText.Last()))
                {
                    currentText = currentText.Substring(0, currentText.Length - 1);
                    textBox.Text = currentText;
                    textBox.SelectionStart = currentText.Length;
                }

                // Ak zadáme číslo, pridáme automaticky čiarku na oddelenie
                if (currentText.Length > 0 && "12345".Contains(currentText.Last()))
                {
                    if (!currentText.EndsWith(","))
                    {
                        currentText += ",";
                        textBox.Text = currentText;
                        textBox.SelectionStart = currentText.Length;
                    }
                }


                isTextChanging = false;
            }
        }
        // Po skončení úpravy bunky prepočítame priemery
        private void dataGridViewZnamky_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewZnamky.Columns["Column2Znamka"].Index)
            {
                UpdateAverageForAllRows();
            }
        }
        // Prepočítame priemerné známky pre všetkých študentov v tabuľke
        private void UpdateAverageForAllRows()
        {
            foreach (DataGridViewRow row in dataGridViewZnamky.Rows)
            {
                if (!row.IsNewRow) 
                {
                    string gradesText = row.Cells["Column2Znamka"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(gradesText))
                    {
                        // Analyzuje známky, ignoruje prázdne hodnoty
                        var grades = gradesText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(g => int.TryParse(g, out int grade) ? grade : (int?)null)
                                               .Where(g => g.HasValue)
                                               .Select(g => g.Value)
                                               .ToList();

                        // Vypočíta priemer
                        if (grades.Count > 0)
                        {
                            double average = grades.Average();
                            row.Cells["Column2Priemer"].Value = average.ToString("F2");
                        }
                        else
                        {
                            row.Cells["Column2Priemer"].Value = ""; 
                        }
                    }
                    else
                    {
                        row.Cells["Column2Priemer"].Value = ""; 
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

                    if (currentText.Length > 0 && currentText.Last() == ',')
                    {
                        textBox.Text = currentText.Substring(0, currentText.Length - 2);
                        textBox.SelectionStart = textBox.Text.Length; // Ponechá kurzor na konci
                        e.Handled = true;
                    }
                    else if (currentText.Length > 0)
                    {
                        // Odstráni iba posledný charakter (ak nie tak koncovú čiarku)
                        textBox.Text = currentText.Substring(0, currentText.Length - 1);
                        textBox.SelectionStart = textBox.Text.Length; // Ponechá kurzor na konci
                        e.Handled = true; 
                    }
                }
            }
        }

        // Funkcia na synchronizáciu mien z prvého DataGridView do druhého
        private void SyncNames()
        {
            if (currentSubject == null) return;
            // pred synchronizáciou vymaže všetky riadky v DataGridViewZnamky
            dataGridViewZnamky.Rows.Clear();

            // Pridá mená z DataGridViewPriezviskoMeno do DataGridViewZnamky, zachová akýchkoľvek zadaný stupeň
            foreach (DataGridViewRow row in dataGridViewPriezviskoMeno.Rows)
            {
                if (!row.IsNewRow)
                {
                    string id = row.Cells["ColumnID"].Value?.ToString();
                    string priezvisko = row.Cells["ColumnPriezvisko"].Value?.ToString();
                    string meno = row.Cells["ColumnMeno"].Value?.ToString();
                    string fullName = $"{priezvisko} {meno}";

                    // Nájde existujúcu známku pre tohto študenta (ak existuje) pomocou ID
                    string existingGrade = "";
                    if (subjectGrades.ContainsKey(currentSubject) && subjectGrades[currentSubject].ContainsKey(id))
                    {
                        existingGrade = subjectGrades[currentSubject][id]; // Získa známkú podľa id
                    }

                    // Pridá študenta do DataGriedViewZnamky
                    dataGridViewZnamky.Rows.Add(id, priezvisko, meno, existingGrade);
                }
            }
            UpdateAverageForAllRows();
        }

        private void SaveCurrentSubjectGrades()
        {
            // Uloží známky od DataGridViewZnamky do dictionary pre aktuálny predmet
            var grades = new Dictionary<string, string>();

            foreach (DataGridViewRow row in dataGridViewZnamky.Rows)
            {
                if (!row.IsNewRow)
                {
                    string id = row.Cells["Column2ID"].Value?.ToString();
                    string priezvisko = row.Cells["Column2Priezvisko"].Value?.ToString();
                    string meno = row.Cells["Column2Meno"].Value?.ToString();
                    string grade = row.Cells["Column2Znamka"].Value?.ToString();

                    grades[id] = grade; // Uloží známky podla ID
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

                        if (grades.ContainsKey(id))
                        {
                            row.Cells["Column2Znamka"].Value = grades[id];
                        }
                        else
                        {
                            row.Cells["Column2Znamka"].Value = ""; // Defaultne nastavená prázdna hodnota
                        }
                    }
                }
            }
        }

        private void buttonPridajStudenta_Click(object sender, EventArgs e)
        {
            // Pridá prázdny študent riadok do DataGridViewPriezviskoMeno
            dataGridViewPriezviskoMeno.Rows.Add("", "", "");

            // Pridá ID-cka automaticky
            UpdateStudentIDs();
            SaveCurrentSubjectGrades();
            SyncNames(); // Sychronizuje mena
        }

        private void buttonVymazStudenta_Click(object sender, EventArgs e)
        {
            var aktivnaBunka = dataGridViewPriezviskoMeno.CurrentCell;
            if (aktivnaBunka != null)
            {
                int cisloRiadku = aktivnaBunka.RowIndex;
                dataGridViewPriezviskoMeno.Rows.RemoveAt(cisloRiadku);

                // Automaticky preradenie ID po odstránení
                UpdateStudentIDs();
                SyncNames(); // Synchronizované názvy po odstránení študenta
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
            // Otvorí OpenFileDialog pre vyberatie súbora CSV
            openFileDialogSubor.Filter = "CSV Files|*.csv";
            openFileDialogSubor.Title = "Select a CSV File";

            if (openFileDialogSubor.ShowDialog() != DialogResult.OK)
                return;

            string menoSuboru = openFileDialogSubor.FileName;

            try
            {
                // Otvorí súbor v režime čítania
                StreamReader subor = new StreamReader(menoSuboru, Encoding.GetEncoding("windows-1250"));

                // hlavicka je prýv riadok v súbore
                string hlavicka = subor.ReadLine();

                dataGridViewPriezviskoMeno.Rows.Clear();

                // Číta súbor postupne riadok po riadku
                string riadok;
                while ((riadok = subor.ReadLine()) != null)
                {
                    // Oddeluje pomocou ;
                    string[] hodnoty = riadok.Split(';');

                    // Pridá hodnoty do DataGridViewMenoPriezvisko
                    if (hodnoty.Length >= 2)
                    {
                        dataGridViewPriezviskoMeno.Rows.Add("", hodnoty[0], hodnoty[1]);
                    }
                }

                // Zatvorí súbor
                subor.Close();

                // Aktualizuje ID studenta po importe
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