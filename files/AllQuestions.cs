using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalllll
{
    public partial class AllQuestions : Form
    {
        Test Test = new Test();
        public AllQuestions(Test test)
        {
            InitializeComponent();

            Test = test;
            foreach (var q in test.Questions)
            {
                lstAllQuestions.Items.Add(q.TheQuestion);
            }
        }

        private void lstAllQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Question question = Test.Questions.Find(question => question.TheQuestion.Equals(lstAllQuestions.SelectedItem));
            EditQuestions editQuestions = new EditQuestions(question, Test);
            editQuestions.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Test.TotalScore < 100)
                Test.IsActive = false;
            saveToJson();
            this.Close();
        }
        public void saveToJson()
        {
            string jsonFilePath = "C://Users//אתי//Documents//C#//Finalllll//Tests//" + Test.Name + ".json"; // You can adjust the file path as needed

            // Serialize the test object to JSON
            string json = JsonConvert.SerializeObject(Test, Formatting.Indented);

            // Write the JSON to a file
            File.WriteAllText(jsonFilePath, json);
        }
    }
}
