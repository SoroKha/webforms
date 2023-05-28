using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Page Loaded.");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (long.TryParse(txtNumber.Text, out long number))
            {
                // Perform the desired processing based on the number
                long result = number * 2;

                // Display the result
                lblResult.Text = "The result is: " + result.ToString();
            }
            else
            {
                lblResult.Text = "Invalid input. Please enter a valid number.";
            }
        }
    

    }
}