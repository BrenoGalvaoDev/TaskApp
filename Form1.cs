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
        List<TaskItem> tasks = new List<TaskItem>();

        public Form1()
        {
            InitializeComponent();

            LoadTasks();

            this.AcceptButton = AddTaskBtn;

            foreach (var task in tasks)
            {
                checkedListBox.Items.Add(task.name, task.status);
            }

            checkedListBox.ItemCheck += checkedListBox1_ItemCheck;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            string newTask = textBoxAdd.Text;

            if (!string.IsNullOrEmpty(newTask))
            {
                checkedListBox.Items.Add(newTask);
                tasks.Add(new TaskItem(newTask, false));
                SaveTask();
                messageBox.Text = "Tarefa adicionada com sucesso";
                textBoxAdd.Clear();

            }
            else
            {
                messageBox.Text = "Digite uma tarefa antes de adicionar";
            }

            WaitAndClean();
        }

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

                messageBox.Text = "Tarefas removidas com sucesso";

                SaveTask();
            }
            catch
            {
                messageBox.Text = "Nenhuma tarefa selecionada";
            }

            WaitAndClean();
        }

        private void SaveTask()
        {
            try
            {
                string json = JsonSerializer.Serialize(tasks);
                File.WriteAllText("tasks.json", json);
            }
            catch
            {
                messageBox.Text = "Tarefa não foi salva";
            }

            WaitAndClean();
        }

        private void LoadTasks()
        {
            try
            {
                if (File.Exists("tasks.json"))
                {
                    string json = File.ReadAllText("tasks.json");
                    tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
                    messageBox.Text = "Tarefa carregadas com sucesso";
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

        async void WaitAndClean()
        {
            await Task.Delay(2000);
            messageBox.Text = "";
        }
    }

    public class TaskItem
    {
        public string name { get; set; }
        public bool status { get; set; }

        public TaskItem (string task, bool Status)
        {
            this.name = task;
            this.status = Status;
        }
        public TaskItem() { }
    }
}
