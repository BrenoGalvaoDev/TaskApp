using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Diagnostics;

namespace TaskApp
{
    public partial class Main : Form
    {
        List<CategoryItem> categoryItems = new List<CategoryItem>(); // List to store category items.

        bool suppressSelection = false; // Flag to suppress selection changes.
        public Main()
        {
            InitializeComponent();

            this.listBox1.MouseDown += new MouseEventHandler(this.ListBox1_MouseDown); // Attach right-click event to listbox.

            toolStripTextBox1.KeyDown += renameToolStripTextBox_KeyDown; // Attach keydown event to rename textbox.

            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick; // Attach double-click event to listbox.

            LoadCategory(); // Load categories from JSON file.
            foreach (var item in categoryItems) // Populate listbox with loaded categories.
            {
                listBox1.Items.Add(item);
            }
        }

        private void NewTaskManagerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string newCategory = textBox1.Text; // Get new category name from textbox.
                if (!string.IsNullOrEmpty(newCategory) && !categoryItems.Any(c => c.name == newCategory)) // Check if category name is valid and unique.
                {
                    var newItem = new CategoryItem(newCategory); // Create new CategoryItem.
                    listBox1.Items.Add(newItem); // Add to listbox.
                    categoryItems.Add(newItem); // Add to category list.
                    SaveCategory(); // Save categories to JSON file.

                    textBox1.Text = ""; // Clear textbox.
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log exception message.
            }
        }

        private void SaveCategory()
        {
            try
            {
                string json = JsonSerializer.Serialize(categoryItems); // Serialize category list to JSON.
                File.WriteAllText("category.json", json); // Write JSON to file.
            }
            catch
            {
                // Handle save error (currently empty).
            }
        }

        private void LoadCategory()
        {
            if (File.Exists("category.json")) // Check if category file exists.
            {
                string json = File.ReadAllText("category.json"); // Read JSON from file.
                categoryItems = JsonSerializer.Deserialize<List<CategoryItem>>(json) ?? new List<CategoryItem>(); // Deserialize JSON to category list.
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressSelection) // Check if selection change should be suppressed.
            {
                suppressSelection = false; // Reset suppress flag.
                return;
            }
        }

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Check if right mouse button was clicked.
            {
                int index = listBox1.IndexFromPoint(e.Location); // Get index of item clicked.
                suppressSelection = true; // Set flag to suppress selection change.
                if (index != ListBox.NoMatches) // Check if item was clicked.
                {
                    listBox1.SelectedIndex = index; // Select the clicked item.
                    categoryContextMenu.Show(Cursor.Position); // Show context menu.
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null && e.Button == MouseButtons.Left) // Check if item was selected and left mouse button was double-clicked.
            {
                string category = listBox1.SelectedItem.ToString(); // Get category name.
                Form1 taskCategory = new Form1(category); // Create new Form1 instance for the category.
                taskCategory.Show(); // Show Form1.
                this.Hide(); // Hide current form.
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) // Check if an item is selected.
            {
                string category = listBox1.SelectedItem.ToString(); // Get category name.
                Form1 taskCategory = new Form1(category); // Create new Form1 instance.
                taskCategory.Show(); // Show Form1.
                this.Hide(); // Hide current form.
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) // Check if an item is selected.
            {
                int index = listBox1.SelectedIndex; // Get selected index.
                string selectedCategory = listBox1.SelectedItem.ToString(); // Get selected category name.

                listBox1.Items.RemoveAt(index); // Remove from listbox.

                var match = categoryItems.FirstOrDefault(c => c.name == selectedCategory); // Find matching category item.
                if (match != null) categoryItems.Remove(match); // Remove from category list.

                string filePath = selectedCategory + "tasks.json"; // Construct file path for category tasks.
                if (File.Exists(filePath)) File.Delete(filePath); // Delete category tasks file if it exists.

                SaveCategory(); // Save updated category list.
                LoadCategory(); // Reload category list.
            }
        }

        private void renameToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listBox1.SelectedItem != null) // Check if Enter key was pressed and an item is selected.
            {
                string newName = toolStripTextBox1.Text.Trim(); // Get new category name from textbox.
                suppressSelection = true; // Set flag to suppress selection change.
                if (!string.IsNullOrEmpty(newName) && !categoryItems.Any(c => c.name == newName)) // Check if new name is valid and unique.
                {
                    CategoryItem selectedItem = listBox1.SelectedItem as CategoryItem; // Get selected CategoryItem.

                    if (selectedItem != null)
                    {
                        string oldName = selectedItem.name; // Store old name.
                        selectedItem.name = newName; // Update category name.

                        // Update the list
                        int selectedIndex = listBox1.SelectedIndex;
                        listBox1.Items[selectedIndex] = selectedItem; // re-insert updated item.

                        // Rename the category JSON file, if it exists
                        string oldFilePath = oldName + "tasks.json";
                        string newFilePath = newName + "tasks.json";
                        if (File.Exists(oldFilePath))
                        {
                            File.Move(oldFilePath, newFilePath);
                        }

                        SaveCategory(); // Save updated category list.
                    }
                }

                toolStripTextBox1.Text = ""; // Clear textbox.

                // Close the menu
                categoryContextMenu.Close();
                e.SuppressKeyPress = true; // Suppress the Enter key press.
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application.
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo() // Start a new process to open the LinkedIn link.
            {
                FileName = "www.linkedin.com/in/breno-galvão-401a40272",
                UseShellExecute = true
            });
        }
    }

    public class CategoryItem
    {
        public string name { get; set; } // Category name property.

        public CategoryItem(string Name)
        {
            this.name = Name; // Constructor to initialize category name.
        }

        public CategoryItem() { } // Default constructor.

        public override string ToString()
        {
            return name; // Override ToString to display category name in listbox.
        }
    }
}