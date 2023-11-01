using QUIZGAME.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QUIZGAME
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Quiz> quizes {  get; set; } = new List<Quiz>();
        public MainWindow()
        {
            InitializeComponent();
            ReadAllQuestionWithJSON();
        }

        private void ToSeeCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoriesView theCategories = new CategoriesView();

            // Merging all questions from all quizzes into a single Quiz object
            Quiz mergedQuiz = new Quiz
            {
                Title = "Combined Quiz",
                Questions = quizes.SelectMany(q => q.Questions).ToList()
            };

            theCategories.selectedQuiz = mergedQuiz;
            theCategories.Show();
            Close();
        }

        private void ReadAllQuestionWithJSON()
        {
            DirectoryInfo QuizFolder = new DirectoryInfo(@".\Quizes");

            foreach (FileInfo file in QuizFolder.EnumerateFiles("*.json"))
            {
                string json = file.OpenText().ReadToEnd();
                quizes.Add(JsonSerializer.Deserialize<Quiz>(json)); 
            }
        }

    }
}
