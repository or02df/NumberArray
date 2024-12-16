using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberArray
{
    public partial class Form1 : Form
    {
        private ArrayOfNumbers arrayOfNumbers;

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_ArrayFromText_Click(object sender, EventArgs e)
        {
            try
            {
                string input = Txt_ArrayInput.Text;

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Please enter space-delimited numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] stringArray = input.Split(' ');

                // Convert the string array to an integer array
                int[] intArray = Array.ConvertAll(stringArray, s =>
                {
                    if (int.TryParse(s, out int result))
                        return result;
                    else
                        throw new FormatException($"Invalid number format: '{s}'");
                });

                arrayOfNumbers = new ArrayOfNumbers(intArray);
                Lbl_Output.Text = $"Created: {arrayOfNumbers.ToString()}";
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Input error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_CreateEmptyArray_Click(object sender, EventArgs e)
        {
            arrayOfNumbers = new ArrayOfNumbers((int)Num_ArrayLength.Value);
            Lbl_Output.Text = $"Created: {arrayOfNumbers.ToString()}";
        }

        private bool IsArrayInitialized()
        {
            if (arrayOfNumbers == null)
            {
                MessageBox.Show("The array has not been initialised. Please initialise the array first.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Btn_SetArrayIndex_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int index = (int)Num_ArrayIndex.Value;
                int value = (int)Num_ArrayIndexValue.Value;
                arrayOfNumbers.SetElement(index, value);
                Lbl_Output.Text = $"Updated {index}. New structure: {arrayOfNumbers.ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_ViewIndex_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int index = (int)Num_ViewIndex.Value;
                int value = arrayOfNumbers.GetElement(index);
                Lbl_Output.Text = $"Element at index {index}: {value}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_CheckEqual_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int index1 = (int)Num_EqualIndex1.Value;
                int index2 = (int)Num_EqualIndex2.Value;
                bool areEqual = arrayOfNumbers.Equal(index1, index2);
                Lbl_Output.Text = $"Elements at {index1} and {index2} are {(areEqual ? "equal" : "not equal")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_GCD_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int index1 = (int)Num_GCDIndex1.Value;
                int index2 = (int)Num_GCDIndex2.Value;
                int gcd = arrayOfNumbers.GCD(index1, index2);
                Lbl_Output.Text = $"GCD of elements at {index1} and {index2}: {gcd}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Scalar_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int scalar = (int)Num_ScalarConstant.Value;
                arrayOfNumbers.ScalarMultiply(scalar);
                Lbl_Output.Text = $"Scalar applied. New array: {arrayOfNumbers.ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_AddConstant_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int constant = (int)Num_AddConstant.Value;
                arrayOfNumbers.AddConstant(constant);
                Lbl_Output.Text = $"Constant applied. New array: {arrayOfNumbers.ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_ShowMax_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int max = arrayOfNumbers.Max();
                Lbl_Output.Text = $"Max value: {max}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_ShowAverage_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                double average = arrayOfNumbers.Average();
                Lbl_Output.Text = $"Average value: {average:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_ShowCount_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int count = arrayOfNumbers.Count();
                Lbl_Output.Text = $"Array Length: {count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_ShowSum_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;

            try
            {
                int sum = arrayOfNumbers.Sum();
                Lbl_Output.Text = $"Sum of array: {sum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_ShowArray_Click(object sender, EventArgs e)
        {
            if (!IsArrayInitialized()) return;
            Lbl_Output.Text = arrayOfNumbers.ToString();
        }
    }
}
