using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoostC__CRUD.Controller;
using BoostC__CRUD.Models;

namespace BoostC__CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadPersonne();
            AjouterColonnesAction();
        }


        public void loadPersonne()
        {
            dataGridView_Personne.DataSource = PersonneController.getAllPersonne();
            
        }


        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Text == "" && textBoxPrenom.Text == "" && textBoxAge.Text == "" && textBoxAdresse.Text == "")
            {
                MessageBox.Show("Veuiller remplir le formulaire pour ajouter la personne");
                return;
            }
            else
            {
                Personne personne = new Personne();

                personne.nom = textBoxNom.Text;
                personne.prenom = textBoxPrenom.Text;
                personne.age = int.Parse(textBoxAge.Text);
                personne.adresse = textBoxAdresse.Text;


                PersonneController.addPersonne(personne);
                MessageBox.Show("Personne ajouter avec succès");
                loadPersonne();
                clearTextBox();
            }            
        }



       


        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Tag == null)
            {
                MessageBox.Show("Aucune personne sélectionnée pour la modification");
                return;
            }

            int id = (int)textBoxNom.Tag;

            Personne personne = new Personne();
            personne.id= id;
            personne.nom = textBoxNom.Text;
            personne.prenom = textBoxPrenom.Text;
            personne.age = int.Parse(textBoxAge.Text);
            personne.adresse = textBoxAdresse.Text;


            PersonneController.updatePersonne(personne);
            MessageBox.Show("Personne modifier avec succès");
            loadPersonne();
            clearTextBox();

        }
        private void AjouterColonnesAction()
        {
           
            DataGridViewButtonColumn btnModifier = new DataGridViewButtonColumn();
            btnModifier.Name = "Modifier";
            btnModifier.HeaderText = "Modifier";
            btnModifier.Text = "Modifier";
            btnModifier.UseColumnTextForButtonValue = true;
            dataGridView_Personne.Columns.Add(btnModifier);

           
            DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn();
            btnSupprimer.Name = "Supprimer";
            btnSupprimer.HeaderText = "Supprimer";
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseColumnTextForButtonValue = true;
            dataGridView_Personne.Columns.Add(btnSupprimer);
        }

        private void dataGridView_Personne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridView_Personne.Columns[e.ColumnIndex].Name;

            int id = Convert.ToInt32(dataGridView_Personne.Rows[e.RowIndex].Cells["Id"].Value);

            if (columnName == "Supprimer")
            {
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette personne ?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    PersonneController.deletePersonne(id);
                    loadPersonne();
                }
            }
            else if (columnName == "Modifier")
            {

                textBoxNom.Text = dataGridView_Personne.Rows[e.RowIndex].Cells["Nom"].Value.ToString();
                textBoxPrenom.Text = dataGridView_Personne.Rows[e.RowIndex].Cells["Prenom"].Value.ToString();
                textBoxAge.Text = dataGridView_Personne.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                textBoxAdresse.Text = dataGridView_Personne.Rows[e.RowIndex].Cells["Adresse"].Value.ToString();
                textBoxNom.Tag = id;
            }
        }


        private void clearTextBox()
        {
            textBoxAdresse.Text = "";
            textBoxAge.Text = "";
            textBoxNom.Text = "";
            textBoxPrenom.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
