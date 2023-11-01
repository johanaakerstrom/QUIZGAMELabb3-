using QUIZGAME.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QUIZGAME
{
    /// <summary>
    /// Interaction logic for EditQuizView.xaml
    /// </summary>
    public partial class EditQuizView : Window
    {    
        ObservableCollection<Question> selectedQuestions = new ObservableCollection<Question>();
        public List<Question> questions {  get; set; }
        public EditQuizView()
        {
            InitializeComponent();

        }

        private void ComboBoxQuestion()
        {
            List<Question> allQuestion = new List<Question>();
            
            allQuestion.AddRange(questions);
            
            AllQuestionsComboBox.ItemsSource = allQuestion;
        }

        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow backToMenu = new MainWindow();
            backToMenu.Show();
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxQuestion();
            ComboBoxSelectedQuestion();
            
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            selectedQuestions.Add((Question)AllQuestionsComboBox.SelectedItem);            
        }
        private void RemoveQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            selectedQuestions.Remove((Question)SelectedQuestionsComboBox.SelectedItem);   
        }

        private void ComboBoxSelectedQuestion()
        {
            SelectedQuestionsComboBox.ItemsSource = selectedQuestions;
        }

        private void StartYourQuizButton_Click(object sender, RoutedEventArgs e)
        {
            QuizView createdQuiz = new QuizView();
            createdQuiz.questions = selectedQuestions.ToList();
            createdQuiz.createdQuizName = QuizNameText.Text;
            createdQuiz.Show();
            this.Close();
        }

    }
}
