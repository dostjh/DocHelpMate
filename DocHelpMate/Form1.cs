using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace DocHelpMate
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			if (SourceFileTextBox.Text == "" || SaveFileTextBox.Text == "")
			{
				MessageBox.Show("You need to specify a source file and folder to save to.", "Files not specified");
				return;
			}
			FormatDoc();
		}

		private void FormatDoc()
		{
			object missing = System.Reflection.Missing.Value;
			object readOnly = false;

			// object fileName = @"C:\Users\Jeremiah\Documents\Visual Studio 2017\Projects\DocHelpMate\Chapter II Aircraft Engine Types And Construction.docx";
			object fileName = SourceFileTextBox.Text;
			//object outputFileName = @"C:\Users\Jeremiah\Documents\Visual Studio 2017\Projects\DocHelpMate\Chapter II Aircraft Engine Types And Construction_Formatted.docx";
			string sourceFileName = SourceFileTextBox.Text.Split('\\').Last();
			string sourceFileNameLessExt = sourceFileName.Split('.')[sourceFileName.Split('.').Count() - 2];
			object outputFileName = SaveFileTextBox.Text + "\\" + sourceFileNameLessExt + string.Format("_autoformatted_{0}.docx",DateTime.Now.ToString("yyyyMMdd_HHmmss"));

			Word.Application word = new Word.Application();
			word.Visible = false;
			Word.Document doc = word.Documents.Open(ref fileName);

			doc.Activate();

			// Resave the file so we don't touch the original
			doc.SaveAs2(ref outputFileName);

			// Create the find/replace object
			Word.Find findObject = doc.Content.Find;
			object replaceAll = Word.WdReplace.wdReplaceAll;

			// Eliminate columns
			doc.PageSetup.TextColumns.SetCount(1);
			FindAndReplace("^n", "", ref findObject, missing, replaceAll);

			// Eliminate section breaks
			FindAndReplace("^b", "", ref findObject, missing, replaceAll);
			
			// Set all text to Body Text style
			object baseStyle = "Body Text";
			doc.Content.set_Style(ref baseStyle);
			doc.Content.Font.Name = "Times New Roman";
			doc.Content.ParagraphFormat.FirstLineIndent = 25; // Pixels
			doc.Content.ParagraphFormat.LineUnitBefore = 0.5f; // Line based on 12 pt font

			/*
			 * Originally, we wanted to replace these shapes with stylized text. However,
			 * it is proving difficult to do this accurately. Instead, we are opting for 
			 * removing the images, and the editor will add text as appropriate to indicate
			 * where an image was. In most cases, this will be fine since these images
			 * are usually captioned with "Figure x-x. Description of figure."
			 * 
			 * We attempted the original spec by creating  alist of the ranges, and adding
			 * to that list as we found shapes. However, for generic shapes, which were
			 * not captured by the inlineshape type, we needed to grab the anchor. Using
			 * the generic shape type made things difficult for two reasons:
			 *   1. We would get multiple shapes in the same place.
			 *   2. We would get the shape's anchor, which was not its actual position.
			 * 
			 * To overcome the first issue, we tried to only capture shapes on the first
			 * deletion pass, but that didn't work.
			 * 
			 * The second issue resulted in the unreliability of the placement of the images.
			 * 
			 */

			// Delete all images and tables

			var tables = doc.Tables;
			var shapes = doc.Shapes;
			var images = doc.InlineShapes;

			foreach (Word.Table table in tables)
			{
				table.Delete();
			}

			// For anchored shapes, we need to make multiple passes to actually hit them all.
			while (shapes.Count > 0)
			{
				foreach (Word.Shape shape in shapes)
				{
					shape.Delete();
				}
				shapes = doc.Shapes;
			}

			foreach (Word.InlineShape iShape in images)
			{
				if (iShape.Type == Word.WdInlineShapeType.wdInlineShapePicture)
				{
					iShape.Delete();
				}
			}

			/*
			 * Character Clean Up!
			 * 
			 * Here, we're looking for common OCR problems and fixing them
			 * with something cleaner.
			 * 
			 */

			var textFound = false;

			// Paragraph breaks in a row
			textFound = true;
			while (textFound == true)
			{
				textFound = FindAndReplace("^p^p", "^p", ref findObject, missing, replaceAll);
				// TODO: Just delete every paragraph that has no text after trimming.
				// We need to do this because the FindAndReplace will not replace the last paragraph of a doc.
				if (doc.Paragraphs.Last.Range.Text.Trim() == string.Empty)
				{
					doc.Paragraphs.Last.Range.Delete();
				}
			}

			// Multiple spaces in a row
			textFound = true;
			while (textFound == true)
			{
				textFound = FindAndReplace("  ", " ", ref findObject, missing, replaceAll);
			}

			// Spaces after an optional hyphen
			textFound = true;
			while (textFound == true)
			{
				// This line is deceptive. There is a soft-hyphen character here that
				// appears invisible. However, I'm unable to determine a way to get this
				// character to appear or otherwise represent it.
				textFound = FindAndReplace("­ ", "", ref findObject, missing, replaceAll);
			}

			// Spaces after an optional hyphen
			textFound = true;
			while (textFound == true)
			{
				textFound = FindAndReplace("- ", "", ref findObject, missing, replaceAll);
			}

			// Multiple spaces before a period
			textFound = true;
			while (textFound == true)
			{
				textFound = FindAndReplace(" .", ".", ref findObject, missing, replaceAll);
			}

			// Multiple spaces before a comma
			textFound = true;
			while (textFound == true)
			{
				textFound = FindAndReplace(" ,", ",", ref findObject, missing, replaceAll);
			}

			// Save the doc!
			doc.Save();
			word.Visible = true;
		}

		private bool FindAndReplace(string f, string r, ref Word.Find findObject, object missing, object replaceAll)
		{
			findObject.ClearFormatting();
			findObject.Replacement.ClearFormatting();
			findObject.Text = f;
			findObject.Replacement.Text = r;
			var foundTextToReplace = findObject.Execute(
				ref missing, ref missing, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing, ref missing, ref missing,
				replaceAll, ref missing, ref missing, ref missing, ref missing
				);

			return foundTextToReplace;
		}

		private void SaveFileButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				SaveFileTextBox.Text = dialog.SelectedPath;
			}

		}

		private void SourceFileButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "doc files (*.doc,*.docx)|*.doc;*.docx|All files (*.*)|*.*";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				SourceFileTextBox.Text = dialog.FileName;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
