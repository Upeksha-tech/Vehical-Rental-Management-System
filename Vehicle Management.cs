using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vehical_Rental_Management_System
{
    public partial class Form3 : Form
    {

        string connectionString = DatabaseConnection.ConnectionString;

        public Form3()
        {
            InitializeComponent();

            this.Load += Form3_Load;
            this.button1.Click += button1_Click;
            this.button6.Click += button6_Click;
            this.button3.Click += button3_Click;
            this.button4.Click += button4_Click;
            this.button5.Click += button5_Click;
            this.button7.Click += button7_Click;
            backToolStripMenuItem.Click += (s, e) => Close();
            refreshToolStripMenuItem.Click += (s, e) => LoadData();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            groupBox1.Enabled = false;
            
            LoadDropdowns();
            LoadData();
        }


        private void LoadDropdowns()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "Car", "Van", "SUV", "Truck", "Bus" });
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Available", "Rented", "Maintenance" });
        }


        private void LoadData()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM vehicle", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            ClearFields();
            textBox2.Focus();
        }

        private void ClearFields()
        {
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox2.SelectedIndex = -1;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Registration Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox5.Text, out decimal dailyRate))
            {
                MessageBox.Show("Please enter a valid numeric value for Daily Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox6.Text, out int year))
            {
                MessageBox.Show("Please enter a valid numeric value for Manufacture Year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO vehicle (`Brand`, `Model`, `Type`, `RegNo`, `DailyRate`, `ManufactureYear`, `Status`) " +
                                   "VALUES (@Brand, @Model, @Type, @RegNumber, @DailyRate, @Year, @Status)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Brand", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Model", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Type", comboBox1.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@RegNumber", textBox4.Text);
                        cmd.Parameters.AddWithValue("@DailyRate", dailyRate);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Status", comboBox2.SelectedItem?.ToString() ?? "");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vehicle details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearFields();
                        groupBox1.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving vehicle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                DialogResult dr = MessageBox.Show($"Are you sure you want to delete vehicle with ID {id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();
                            string query = "DELETE FROM vehicle WHERE ID = @ID";
                            using (MySqlCommand cmd = new MySqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@ID", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Vehicle deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting vehicle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a vehicle row from the table to delete.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM vehicle WHERE `RegNo` LIKE @Search OR `Brand` LIKE @Search OR `Model` LIKE @Search";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@Search", "%" + textBox1.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            LoadData();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            ClearFields();
            groupBox1.Enabled = false;
        }
    }
}
