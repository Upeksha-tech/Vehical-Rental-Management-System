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
        // Connection string for local XAMPP MySQL
        string connectionString = "Server=localhost;Database=vehicle_project;Uid=root;Pwd=;";

        public Form3()
        {
            InitializeComponent();
            
            // Wire up events manually to avoid touching the .Designer.cs file
            this.Load += Form3_Load;
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
            // Ensure full row selection for delete to work properly when clicking on a cell
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // Fit the table columns to the size of the DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            groupBox1.Enabled = false;
            
            LoadDropdowns();
            LoadData();
        }


        private void LoadDropdowns()
        {
            // Populate Vehicle Type (comboBox1)
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "Car", "Van", "SUV", "Truck", "Bus" });
            // Populate Status (comboBox2)
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Available", "Rented", "Maintenance" });
        }

        // --- Database Connect / Load Data ---
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

        // Helper method to clear all textboxes and selections
        private void ClearFields()
        {
            textBox2.Clear(); // Brand
            textBox3.Clear(); // Model
            comboBox1.SelectedIndex = -1; // Type
            textBox4.Clear(); // Reg. Number
            textBox5.Clear(); // Daily Rate
            textBox6.Clear(); // Year
            comboBox2.SelectedIndex = -1; // Status
        }

        //Add Vehicle
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
                    // Using your table 'vehicle' with exact column names wrapped in backticks
                    string query = "INSERT INTO vehicle (`Brand`, `Model`, `Type`, `Reg. No`, `Daily Rate(LKR)`, `Manufacture Year`, `Status`) " +
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

                        LoadData(); // Refresh grid
                        ClearFields(); // Clear inputs
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving vehicle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete Button
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Using ID as the primary key for deletion
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

        // Search Vehicle
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    // Searches by Reg. No, Brand, or Model based on textBox1
                    string query = "SELECT * FROM vehicle WHERE `Reg. No` LIKE @Search OR `Brand` LIKE @Search OR `Model` LIKE @Search";
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

        // Reset Search
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); // Clear search box
            LoadData(); // Load all data again
        }

        // Clear Fields
        private void button7_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
