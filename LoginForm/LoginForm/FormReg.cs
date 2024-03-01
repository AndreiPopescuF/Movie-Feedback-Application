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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginForm
{
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
        }

        private void FormReg_Shown(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=""Aplicatie Feedback si Clasificare a Filmelor"";Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Filme", conn))
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

        private void FormReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Menuform form5 = new Menuform();
            form5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=""Aplicatie Feedback si Clasificare a Filmelor"";Integrated Security=True"))
            {
                conn.Open();
                String Nume, AnLansare, NumeGen, Numefilm, Prenume;
                Numefilm = textBox1.Text;
                NumeGen = textBox2.Text;
                AnLansare = textBox3.Text;
                Nume = textBox4.Text;
                Prenume = textBox5.Text;

                if (AnLansare.Length != 4)
                {
                    MessageBox.Show("Introdu un an corect.");
                    return;
                }

                int regizorId = 0;
                using (SqlCommand checkRegizorCmd = new SqlCommand("SELECT RegizorID FROM Regizor WHERE Nume = @Nume AND Prenume = @Prenume", conn))
                {
                    checkRegizorCmd.Parameters.AddWithValue("@Nume", Nume);
                    checkRegizorCmd.Parameters.AddWithValue("@Prenume", Prenume);
                    var result = checkRegizorCmd.ExecuteScalar();
                    if (result != null)
                    {
                        regizorId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Nu exista acest regizor.");
                        return;
                    }
                }

                int genId = 0;
                using (SqlCommand checkGenCmd = new SqlCommand("SELECT GenID FROM Genuri WHERE NumeGen = @NumeGen", conn))
                {
                    checkGenCmd.Parameters.AddWithValue("@NumeGen", NumeGen);
                    var result = checkGenCmd.ExecuteScalar();
                    if (result != null)
                    {
                        genId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Nu exista acest gen.");
                        return;
                    }
                }

              
                string insertQuery = "INSERT INTO Filme (NumeFilm,GenID,AnLansare,RegizorID) VALUES (@NumeFilm,@GenID,@AnLansare,@RegizorID)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                   
                    insertCmd.Parameters.AddWithValue("@NumeFilm", Numefilm);
                    insertCmd.Parameters.AddWithValue("@GenID", genId);
                    insertCmd.Parameters.AddWithValue("@AnLansare", AnLansare);
                    insertCmd.Parameters.AddWithValue("@RegizorID", regizorId);


                   
                    insertCmd.ExecuteNonQuery();
                }

              
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Filme", conn))
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

        private void button2_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {

                int idFilm = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["FilmID"].Value);

               
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
                {
                    conn.Open();

                   
                    string deleteQuery = "DELETE FROM Filme WHERE FilmID = @FilmID";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@FilmID", idFilm);

                     
                        deleteCmd.ExecuteNonQuery();
                    }

                  
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Filme", conn))
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
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
                {
                    conn.Open();
                    String Nume, AnLansare, NumeGen, Numefilm, Prenume;
                    Numefilm = textBox1.Text;
                    NumeGen = textBox2.Text;
                    AnLansare = textBox3.Text;
                    Nume = textBox4.Text;
                    Prenume = textBox5.Text;

                    int idFilm = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["FilmID"].Value);

                    if (AnLansare.Length != 4)
                    {
                        MessageBox.Show("Introdu un an corect.");
                        return;
                    }

                    int regizorId = 0;
                    using (SqlCommand checkRegizorCmd = new SqlCommand("SELECT RegizorID FROM Regizor WHERE Nume = @Nume AND Prenume = @Prenume", conn))
                    {
                        checkRegizorCmd.Parameters.AddWithValue("@Nume", Nume);
                        checkRegizorCmd.Parameters.AddWithValue("@Prenume", Prenume);
                        var result = checkRegizorCmd.ExecuteScalar();
                        if (result != null)
                        {
                            regizorId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Nu exista acest regizor.");
                            return;
                        }
                    }

                    int genId = 0;
                    using (SqlCommand checkGenCmd = new SqlCommand("SELECT GenID FROM Genuri WHERE NumeGen = @NumeGen", conn))
                    {
                        checkGenCmd.Parameters.AddWithValue("@NumeGen", NumeGen);
                        var result = checkGenCmd.ExecuteScalar();
                        if (result != null)
                        {
                            genId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Nu exista acest gen.");
                            return;
                        }
                    }
                 
                    string updateQuery = "UPDATE Filme SET NumeFilm = @NumeFilm, GenID = @GenID, AnLansare = @AnLansare,RegizorID = @RegizorID WHERE FilmID = @FilmID";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@NumeFilm", Numefilm);
                        updateCmd.Parameters.AddWithValue("@GenID", genId);
                        updateCmd.Parameters.AddWithValue("@AnLansare", AnLansare);
                        updateCmd.Parameters.AddWithValue("@RegizorID", regizorId);
                        updateCmd.Parameters.AddWithValue("@FilmID", idFilm);


                    
                        updateCmd.ExecuteNonQuery();
                    }

                    
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Filme", conn))
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

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

              
                string selectQuery = "SELECT Filme.* FROM Filme JOIN Genuri ON Filme.GenID = Genuri.GenID WHERE Genuri.GenID = @GenID";

                int genIdComedie = 2;

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@GenID", genIdComedie);

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

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=""Aplicatie Feedback si Clasificare a Filmelor"";Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Filme", conn))
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

                // Verificați dacă filmul există în tabelul Filme
                string checkFilmQuery = "SELECT F.RegizorID " +
                                "FROM Filme F " +
                                "JOIN Regizor R ON F.RegizorID = R.RegizorID " +
                                "WHERE F.NumeFilm = @NumeFilm";

                using (SqlCommand checkFilmCmd = new SqlCommand(checkFilmQuery, conn))
                {
                    // Presupunând că textBox6.Text conține numele filmului căutat
                    checkFilmCmd.Parameters.AddWithValue("@NumeFilm", textBox6.Text);

                    object regizorId = checkFilmCmd.ExecuteScalar();

                    if (regizorId != null) // Dacă filmul a fost găsit
                    {
                        // Folosiți regizorId pentru a obține informațiile despre regizor din tabela Regizori
                        string selectRegizorQuery = "SELECT Nume, Prenume " +
                                                    "FROM Regizor " +
                                                    "WHERE RegizorID = @RegizorID";

                        using (SqlCommand selectRegizorCmd = new SqlCommand(selectRegizorQuery, conn))
                        {
                            selectRegizorCmd.Parameters.AddWithValue("@RegizorID", regizorId);

                            using (SqlDataAdapter sda = new SqlDataAdapter(selectRegizorCmd))
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    dataGridView1.DataSource = dt;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Nu s-a găsit niciun film cu numele {textBox6.Text}");
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

              
                string selectQuery = "SELECT * FROM Filme f JOIN Genuri g ON f.GenID = g.GenID WHERE g.NumeGen = @NumeGen AND f.AnLansare >= @AnInceput";

              
                string numeGen = textBox7.Text;
                int anInceput;
                if (!int.TryParse(textBox8.Text, out anInceput))
                {
                    MessageBox.Show("Introduceți un an de început valid.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@NumeGen", numeGen);
                    cmd.Parameters.AddWithValue("@AnInceput", anInceput);

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

        private void FormReg_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

                
                string selectQuery = "SELECT Filme.* FROM Filme JOIN Genuri ON Filme.GenID = Genuri.GenID WHERE Genuri.GenID = @GenID";

                int genIdComedie = 1;

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@GenID", genIdComedie);

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

        private void button9_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

             
                string selectQuery = "SELECT Filme.* FROM Filme JOIN Genuri ON Filme.GenID = Genuri.GenID WHERE Genuri.GenID = @GenID";


                int genIdComedie = 3;

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@GenID", genIdComedie);

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

        private void button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

        
                string selectQuery = "SELECT Filme.* FROM Filme JOIN Genuri ON Filme.GenID = Genuri.GenID WHERE Genuri.GenID = @GenID";


                int genIdComedie = 4;

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@GenID", genIdComedie);

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

        private void button11_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

        
                string numeGen = textBox9.Text;

       
                int genId = 0;
                using (SqlCommand checkGenCmd = new SqlCommand("SELECT GenID FROM Genuri WHERE NumeGen = @NumeGen", conn))
                {
                    checkGenCmd.Parameters.AddWithValue("@NumeGen", numeGen);
                    var result = checkGenCmd.ExecuteScalar();
                    if (result != null)
                    {
                        genId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Genul nu există.");
                        return;
                    }
                }

       
                string selectQuery = "SELECT * FROM Filme WHERE GenID = @GenID";
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@GenID", genId);

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

        private void button12_Click(object sender, EventArgs e)
        {
            String numeFilm = textBox10.Text;

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

           
                int filmId = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT FilmID FROM Filme WHERE NumeFilm = @NumeFilm", conn))
                {
                    cmd.Parameters.AddWithValue("@NumeFilm", numeFilm);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        filmId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Nu exista acest film.");
                        return;
                    }
                }

                string selectQuery = @"SELECT 
                                        Recenzie.Recenzie, 
                                        Recenzie.DataRecenzie, 
                                        (SELECT NumeFilm FROM Filme WHERE Filme.FilmID = Recenzie.FilmID) AS NumeFilm, 
                                        (SELECT AnLansare FROM Filme WHERE Filme.FilmID = Recenzie.FilmID) AS AnLansare, 
                                        (SELECT NumeGen FROM Genuri WHERE Genuri.GenID = (SELECT GenID FROM Filme WHERE Filme.FilmID = Recenzie.FilmID)) AS NumeGen
                                    FROM 
                                        Recenzie
                                    WHERE 
                                        Recenzie.FilmID = @FilmID";
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FilmID", filmId);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;

                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT TOP 5
                        Filme.NumeFilm,
                        Filme.AnLansare,
                        (SELECT COUNT(Recenzie.Recenzie) FROM Recenzie WHERE Recenzie.FilmID = Filme.FilmID) AS NumarRecenzii
                    FROM 
                        Filme
                    ORDER BY 
                        Filme.AnLansare DESC";


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

        private void button14_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5PPOKMT\SQLEXPRESS;Initial Catalog=Aplicatie Feedback si Clasificare a Filmelor;Integrated Security=True"))
            {
                conn.Open();


                string selectQuery = @"SELECT
                        Genuri.NumeGen,
                        (SELECT COUNT(Filme.FilmID) FROM Filme WHERE Filme.GenID = Genuri.GenID) AS NumarFilme
                    FROM 
                        Genuri
                    ORDER BY 
                        NumarFilme DESC";

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
