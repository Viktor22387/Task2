using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private string currentExpression = "";
        private string previousExpression = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentExpression += button.Content.ToString();
            UpdateTextBoxes();
        }

        private void DecimalButtonClick(object sender, RoutedEventArgs e)
        {
            if (!currentExpression.Contains("."))
            {
                currentExpression += ".";
                UpdateTextBoxes();
            }
        }

        private void OperatorButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentExpression += $" {button.Content} ";
            UpdateTextBoxes();
        }

        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                previousExpression = currentExpression;
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(currentExpression, "");
                currentExpression = result.ToString();
                UpdateTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearEntryButtonClick(object sender, RoutedEventArgs e)
        {
            currentExpression = "";
            UpdateTextBoxes();
        }

        private void ClearAllButtonClick(object sender, RoutedEventArgs e)
        {
            currentExpression = "";
            previousExpression = "";
            UpdateTextBoxes();
        }

        private void BackspaceButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentExpression.Length > 0)
            {
                currentExpression = currentExpression.Substring(0, currentExpression.Length - 1);
                UpdateTextBoxes();
            }
        }

        private void UpdateTextBoxes()
        {
            expressionTextBox.Text = previousExpression + " " + currentExpression;
            resultTextBox.Text = currentExpression;
        }
    }
}
