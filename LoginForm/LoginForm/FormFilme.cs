using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginForm
{
    public partial class FormFilme : Form
    {
        public FormFilme()
        {
            InitializeComponent();
        }

        private void FormFilme_Shown(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=""Aplicatie Feedback si Clasificare a Filmelor"";Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Regizor", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Deschide conexiunea la baza de date
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=""Aplicatie Feedback si Clasificare a Filmelor"";Integrated Security=True"))
            {
                conn.Open();
                String Nume, Prenume;
                Nume = textBox1.Text;
                Prenume = textBox2.Text;

                // Creează o comandă SQL pentru inserarea unui nou rând
                string insertQuery = "INSERT INTO Regizor (Nume,Prenume) VALUES (@Nume, @Prenume)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    // Setează parametrii pentru valorile de inserat
                    insertCmd.Parameters.AddWithValue("@Nume", Nume); // Poți înlocui cu datele reale
                    insertCmd.Parameters.AddWithValue("@Prenume", Prenume);


                    // Execută comanda de inserare
                    insertCmd.ExecuteNonQuery();
                }

                // Actualizează afișarea datelor în DataGridView
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Regizor", conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void FormFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifică dacă există cel puțin o linie selectată în DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obține identificatorul unic al liniei selectate (de exemplu, idFilm)
                int idRegizor = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RegizorID"].Value);

                // Deschide conexiunea la baza de date
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
                {
                    conn.Open();

                    // Creează comanda SQL pentru ștergerea liniei cu identificatorul specificat
                    string deleteQuery = "DELETE FROM Regizor WHERE RegizorID = @RegizorID";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@RegizorID", idRegizor);

                        // Execută comanda de ștergere
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Actualizează afișarea datelor în DataGridView
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Regizor", conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați o linie pentru a șterge.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String nume, prenume;
                nume = textBox1.Text;
                prenume = textBox2.Text;
                // Obține identificatorul unic al liniei selectate (de exemplu, idFilm)
                int idRegizor = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RegizorID"].Value);


                // Deschide conexiunea la baza de date
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
                {
                    conn.Open();

                    // Creează comanda SQL pentru ștergerea liniei cu identificatorul specificat
                    string updateQuery = "UPDATE Regizor SET Nume = @Nume, Prenume = @Prenume WHERE RegizorID = @RegizorID";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Prenume", prenume);
                        updateCmd.Parameters.AddWithValue("@Nume", nume);
                        updateCmd.Parameters.AddWithValue("@RegizorID", idRegizor);


                        // Execută comanda de ștergere
                        updateCmd.ExecuteNonQuery();
                    }

                    // Actualizează afișarea datelor în DataGridView
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Regizor", conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați o linie pentru a o updata.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Menuform form4 = new Menuform();
            form4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                int regizorId = Convert.ToInt32(selectedRow.Cells["RegizorID"].Value);

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
                {
                    conn.Open();

                    string selectQuery = @"SELECT Filme.NumeFilm, Filme.AnLansare
                               FROM Filme
                               INNER JOIN Regizor ON Filme.RegizorID = Regizor.RegizorID
                               WHERE Regizor.RegizorID = @RegizorID";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RegizorID", regizorId);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Selecteaza un rand.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=""Aplicatie Feedback si Clasificare a Filmelor"";Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Regizor", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT 
                                    Regizor.Nume, 
                                    Regizor.Prenume, 
                                    COUNT(Filme.FilmID) AS NumarFilme
                                FROM 
                                    Regizor
                                LEFT JOIN 
                                    Filme ON Regizor.RegizorID = Filme.RegizorID
                                GROUP BY 
                                    Regizor.Nume, Regizor.Prenume";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
    }
}
