using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace TaskApp
{
    public partial class Form1 : Form
    {
        List<TaskItem> tasks = new List<TaskItem>(); //used to save tasks

        string currentCategory = "default";

        /// <summary>
        /// Initializes the form, loads saved tasks, and sets up initial events.
        /// </summary>
        public Form1(string category)
        {
            InitializeComponent();

            currentCategory = category;

            LoadTasks(currentCategory); // load tasks saved in json

            this.AcceptButton = AddTaskBtn; // add AddTaskBtn event to the enter button

            foreach (var task in tasks) // load tasks into the CheckBox
            {
                checkedListBox.Items.Add(task.name, task.status);
            }

            checkedListBox.ItemCheck += checkedListBox1_ItemCheck; // Updates task status when checking/unchecking.
        }
        /// <summary>
        /// Exit the application
        /// </summary>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Navigates back to the main form.
        /// </summary>
        private void BackToMain_Click(object sender, EventArgs e)
        {
            Main form2 = new Main();
            form2.Show();
            this.Hide();
        }

        /// <summary>
        /// Adds a new task to the list, saves it to file and refreshes the interface.
        /// </summary>
        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            string newTask = textBoxAdd.Text;

            if (!string.IsNullOrEmpty(newTask))
            {
                checkedListBox.Items.Add(newTask);
                tasks.Add(new TaskItem(newTask, false));
                SaveTask();
                messageBox.Text = "Task added successfully";
                textBoxAdd.Clear();
            }
            else
            {
                messageBox.Text = "Type a task before adding";
            }

            WaitAndClean();
        }
        /// <summary>
        /// Removes all marked (completed) tasks from the list and refreshes the file.
        /// </summary>
        private void deleteTaskBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var checkItens = new List<object>();

                foreach (var item in checkedListBox.CheckedItems)
                {
                    checkItens.Add(item);
                }

                for (int i = checkedListBox.CheckedIndices.Count - 1; i >= 0; i--)
                {
                    int index = checkedListBox.CheckedIndices[i];
                    checkedListBox.Items.RemoveAt(index);
                    if (index >= 0 && index < tasks.Count)
                    {
                        tasks.RemoveAt(index);
                    }
                }

                messageBox.Text = "Task removed successfully";

                SaveTask();
            }
            catch
            {
                messageBox.Text = "No task selected";
            }

            WaitAndClean();
        }

        /// <summary>
        /// Saves the current list of tasks to a JSON file.
        /// </summary>
        private void SaveTask()
        {
            try
            {
                string json = JsonSerializer.Serialize(tasks);
                string fileTask = currentCategory + "tasks.json";
                File.WriteAllText(fileTask, json);
            }
            catch
            {
                messageBox.Text = "Task was not Saved";
            }

            WaitAndClean();
        }

        /// <summary>
        /// Loads saved tasks from JSON file if exists.
        /// </summary>
        private void LoadTasks(string category)
        {
            try
            {
                string filePath = category + "tasks.json";
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
                    messageBox.Text = "Tasks loaded successfully";
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not Found!");
            }
            catch (JsonException)
            {
                Console.WriteLine("Deserialize Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:  " + ex.Message);
            }

            WaitAndClean();
        }

        /// <summary>
        /// Updates the task status (completed or not) when checking/unchecking in the checklist.
        /// </summary>
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.Index >= 0 && e.Index < tasks.Count)
                {
                    tasks[e.Index].status = (e.NewValue == CheckState.Checked);
                    SaveTask();
                }
            });
        }
        /// <summary>
        /// Wait 2 seconds and clear the content of the displayed message.
        /// </summary>
        async void WaitAndClean()
        {
            await Task.Delay(2000);
            messageBox.Text = "";
        }
    }

    /// <summary>
    /// Represents a task with name and status (completed or not).
    /// </summary>
    public class TaskItem
    {
        public string name { get; set; }
        public bool status { get; set; }

        /// <summary>
        /// Constructor with parameters to initialize the task.
        /// </summary>
        public TaskItem(string task, bool Status)
        {
            this.name = task;
            this.status = Status;
        }
        /// <summary>
        /// Empty constructor required for JSON deserialization.
        /// </summary>
        public TaskItem() { }
    }
}