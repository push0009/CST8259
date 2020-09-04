using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Web.Configuration;

public partial class Lab6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        //Create the transformation. For better performance cache the compiled XSLT in the application state. 
        XslCompiledTransform transform = null;
        if (Application["restaurantReviewXslt"] == null)
        {   
            transform = new XslCompiledTransform();
            string xsltPath = WebConfigurationManager.AppSettings["restaurantReviewXsltPath"];
            transform.Load(xsltPath);

            Application["restaurantReviewXslt"] = transform;
        }
        else
        {
            transform = Application["restaurantReviewXslt"] as XslCompiledTransform;
        }

        //create the XSLT parameters 
        int minRating = int.Parse(txtMinRating.Text);
        XsltArgumentList xslArguments = new XsltArgumentList();
        xslArguments.AddParam("minRating", "", minRating.ToString());

        //create transformation output string.
        StringBuilder htmlStringBuilder = new StringBuilder();
        XmlWriter xw = XmlWriter.Create(htmlStringBuilder);

        //transform the xml
        string xmlPath = WebConfigurationManager.AppSettings["restaurantReviewXmlPath"];
        transform.Transform(xmlPath, xslArguments, xw);

        //add transformation result to the page.
        string htmlString = htmlStringBuilder.ToString();
        divRestaurantReviews.InnerHtml = htmlString;
    }
}