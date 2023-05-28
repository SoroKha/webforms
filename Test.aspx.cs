using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Display all images initially
                DisplayImages();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            FileUpload fileUpload = (FileUpload)FindControl("fileUpload");
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = "~/Images/" + fileName;
                fileUpload.SaveAs(Server.MapPath(filePath));

                // Add the uploaded image to the GridView
                ImageInfo image = new ImageInfo(fileName, filePath);
                ImageManager.AddImage(image);

                // Refresh the GridView
                DisplayImages();
            }
        }

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlFilter = (DropDownList)FindControl("ddlFilter");
            int filterValue = int.Parse(ddlFilter.SelectedValue);

            // Apply filter and display filtered images
            DisplayImages(filterValue);
        }

        private void DisplayImages(int filter = 0)
        {
            GridView gridView = (GridView)FindControl("gridView");
            if (filter == 0)
            {
                if (gridView != null) gridView.DataSource = ImageManager.Images;
                
            }
            else
            {
                gridView.DataSource = ImageManager.GetFilteredImages(filter);
            }

            gridView.DataBind();
        }
    }

    public class ImageInfo
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public ImageInfo(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;
        }
    }

    public static class ImageManager
    {
        public static List<ImageInfo> Images { get; set; }

        static ImageManager()
        {
            Images = new List<ImageInfo>();
        }

        public static void AddImage(ImageInfo image)
        {
            Images.Add(image);
        }

        public static List<ImageInfo> GetFilteredImages(int filter)
        {
            return Images.Where(image =>
            {
                // Apply filter based on filter value (1: Landscape, 2: Portrait)
                if (filter == 1)
                {
                    return IsLandscape(image.ImagePath);
                }
                else if (filter == 2)
                {
                    return IsPortrait(image.ImagePath);
                }
                else
                {
                    return true;
                }
            }).ToList();
        }

        private static bool IsLandscape(string imagePath)
        {
            // Determine if the image is landscape based on its dimensions
            // You can implement your own logic here

            return true; // Placeholder logic, always returns true
        }

        private static bool IsPortrait(string imagePath)
        {
            // Determine if the image is portrait based on its dimensions
            // You can implement your own logic here

            return false; // Placeholder logic, always returns false
        }
    }
}
