using System;
using System.Xml;
using System.Xml.Schema;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XmlSchemalValidator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            tblErrors.Visible = false;
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        //string path = Server.MapPath("~/UploadedImages/");
        if (schemaFile.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(schemaFile.FileName).ToLower();
            if (fileExtension != ".xsd")
            {
                lblMessage.Text += schemaFile.FileName + " is not a valid schema file.<br/>";
            }
        }
        else
        {
            lblMessage.Text += "Schema file missing!<br/>";
        }
        if (xmlFile.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(xmlFile.FileName).ToLower();
            if (fileExtension != ".xml")
            {
                lblMessage.Text += xmlFile.FileName + " is not a valid xml file.<br/>";
            }
        }
        else
        {
            lblMessage.Text += "XML file missing!<br/>";
        }
        if (lblMessage.Text == "")
        {
            try
            {
                XmlReader schemaDoc = XmlReader.Create(schemaFile.FileContent);

                XmlSchemaSet sc = new XmlSchemaSet();
                sc.Add(null, schemaDoc);

                // Set the validation settings. 
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = sc;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

                XmlReader xmlDoc = XmlReader.Create(xmlFile.FileContent, settings);

                List<ValidationResult> validationResults = new List<ValidationResult>();
                Session["validationResults"] = validationResults;
                while (xmlDoc.Read()) ;

                ShowValidationResults(validationResults);

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        if(lblMessage.Text == "")
        {
            lblMessage.Visible = false;   
        }

        xmlFile.Attributes.Clear();
        schemaFile.Attributes.Clear();
    }

    private void ValidationCallBack(Object sender, ValidationEventArgs e)
    {
        XmlReader reader = sender as XmlReader;
        List<ValidationResult> validationResults = Session["validationResults"] as List<ValidationResult>;
        ValidationResult result = new ValidationResult(reader.Name, e.Severity.ToString(), e.Exception.LineNumber, e.Exception.LinePosition, e.Message);
        validationResults.Add(result);
    }

    private void ShowValidationResults(List<ValidationResult> validationResults)
    {
        
        if (validationResults.Count > 0)
        {
            if (validationResults.Count == 1)
            {
                lblMessage.Text += "1 error was found in " + xmlFile.FileName + ":<br/>";
            }
            else
            {
                lblMessage.Text += validationResults.Count + " errors were found in  " + xmlFile.FileName + ":<br/>";
            }

            tblErrors.Visible = true;
            foreach (ValidationResult rs in validationResults)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = rs.Element;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = rs.Type;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = rs.Line.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = rs.Column.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = rs.Message;
                row.Cells.Add(cell);

                tblErrors.Rows.Add(row);
            }
        }
        else
        {
            lblMessage.Text = xmlFile.FileName + " is valid.";
            tblErrors.Visible = false;
        }

    }
}