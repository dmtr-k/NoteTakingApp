using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace NoteTakingApp
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private const string connectionString = @"Data Source=LAB109PC10\SQLEXPRESS; Initial Catalog=NoteDB; Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadNotes();
        }

        private void InitializeDatabase()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing database: " + ex.Message);
            }
        }

        private void LoadNotes()
        {
            try
            {
                // Clear existing data in the DataGridView
                dataGridViewNotes.Rows.Clear();

                // If columns don't exist, define and add them
                if (dataGridViewNotes.Columns.Count == 0)
                {
                    dataGridViewNotes.Columns.Add("TitleColumn", "Title");
                    dataGridViewNotes.Columns.Add("TimestampColumn", "Timestamp");
                }

                SqlCommand command = new SqlCommand("SELECT title, timestamp FROM Notes", sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridViewNotes.Rows.Add(reader["title"], reader["timestamp"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading notes: " + ex.Message);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotes.SelectedRows.Count > 0)
            {
                string title = dataGridViewNotes.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    SqlCommand command = new SqlCommand("SELECT content FROM Notes WHERE title = @Title", sqlConnection);
                    command.Parameters.AddWithValue("@Title", title);
                    string content = command.ExecuteScalar().ToString();
                    titleTextBox.Text = title;
                    richTextBoxContent.Rtf = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening note: " + ex.Message);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotes.SelectedRows.Count > 0)
            {
                string title = dataGridViewNotes.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Notes WHERE title = @Title", sqlConnection);
                    command.Parameters.AddWithValue("@Title", title);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Note deleted successfully.");
                    dataGridViewNotes.Rows.RemoveAt(dataGridViewNotes.SelectedRows[0].Index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting note: " + ex.Message);
                }
            }

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            richTextBoxContent.Clear();
            titleTextBox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Notes (title, content, timestamp) VALUES (@Title, @Content, @Timestamp)", sqlConnection);
                command.Parameters.AddWithValue("@Title", titleTextBox.Text);
                command.Parameters.AddWithValue("@Content", richTextBoxContent.Rtf);
                command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                command.ExecuteNonQuery();
                MessageBox.Show("Note saved successfully.");
                LoadNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving note: " + ex.Message);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewNotes.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewNotes.SelectedRows[0];

                    // Extract title, timestamp, and content from the selected row
                    string title = selectedRow.Cells["TitleColumn"].Value.ToString();
                    string timestamp = selectedRow.Cells["TimestampColumn"].Value.ToString();
                    string content = string.Empty;

                    // Retrieve the content of the selected note
                    SqlCommand command = new SqlCommand("SELECT Content FROM Notes WHERE title = @Title", sqlConnection);
                    command.Parameters.AddWithValue("@Title", title);
                    content = command.ExecuteScalar().ToString();

                    // Convert RTF content to plain text
                    richTextBoxContent.Rtf = content;
                    string plainTextContent = richTextBoxContent.Text;

                    // Write title, timestamp, and content to the export file
                    using (StreamWriter writer = new StreamWriter("note_export.txt"))
                    {
                        writer.WriteLine("Title: " + title);
                        writer.WriteLine("Timestamp: " + timestamp);
                        writer.WriteLine("Content:");
                        writer.WriteLine(plainTextContent);
                    }

                    MessageBox.Show("Note exported successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a note to export.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting note: " + ex.Message);
            }
        }


        private void searchTitleTextChanged(object sender, EventArgs e)
        {
            try
            {
                // Open SQL connection
                sqlConnection.Open();

                // Start with a base SQL query
                string query = "SELECT title, timestamp FROM Notes WHERE 1 = 1";

                // Create a list to store the conditions for filtering
                List<string> conditions = new List<string>();

                // Add search criteria for title
                if (!string.IsNullOrEmpty(searchTitleTextBox.Text))
                {
                    conditions.Add("title LIKE @title");
                }

                // Add conditions to the query
                if (conditions.Count > 0)
                {
                    query += " AND " + string.Join(" AND ", conditions);
                }

                // Create command with parameters
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                // Set parameters for title
                if (!string.IsNullOrEmpty(searchTitleTextBox.Text))
                {
                    cmd.Parameters.AddWithValue("@title", "%" + searchTitleTextBox.Text + "%");
                }

                // Use SqlDataAdapter to fetch data and populate DataGridView
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridViewNotes.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching notes: " + ex.Message);
            }
            finally
            {
                // Close SQL connection
                sqlConnection.Close();
            }
        }

    }
}