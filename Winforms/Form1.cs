using System.Text.Json;
namespace Winforms
{
    public partial class Form1 : Form
    {
        // Path to save the student data
        private string filePath = Path.Combine(Application.StartupPath, "students.json");

        // List to hold student data
        List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();

            // 🔥 Ensure these events are connected
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
        }

        // Class to represent a student
        class Student
        {
            public string Name { get; set; }
            public string Coffee { get; set; }
            public string Additional { get; set; }
        }

        // ✅ Load data on start
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                }
                catch
                {
                    students = new List<Student>();
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }
        // ✅ Save data when closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // ✅ ADD button
        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student()
            {
                Name = textBox1.Text,
                Coffee = textBox2.Text,
                Additional = textBox3.Text
            };

            students.Add(s);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;

            // Clear input boxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        // ✅ EDIT button
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;

                students[index].Name = textBox1.Text;
                students[index].Coffee = textBox2.Text;
                students[index].Additional = textBox3.Text;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;
            }
        }

        // ✅ DELETE button
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                students.RemoveAt(index);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;
            }
        }

        // ✅ When user clicks a row, fill text boxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}