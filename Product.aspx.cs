﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace IT3685
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["IT3685"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", con);
            con.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            productsRepeater.DataSource = dataSet;
            productsRepeater.DataBind();
        }

        protected void Add_To_Cart(object sender, EventArgs e)
        {
            var customerId = Session["customerId"];
            if (customerId == null)
            {
                Response.Redirect("Login?msg=AddToCart");
            }

            string productId = ((LinkButton)sender).CommandArgument;
            customerId = customerId.ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["IT3685"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM cart WHERE CustomerId=@customerId AND ProductId=@productId", con);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@productId", productId);

            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            if (count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO cart(`CustomerId`, `ProductId`, `Quantity`) " +
                    "VALUES(@customerId, @productId, 1)", con);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd = new MySqlCommand("SELECT Quantity FROM cart WHERE CustomerId=@customerId AND ProductId=@productId", con);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@productId", productId);
                int quantity = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new MySqlCommand("UPDATE cart SET Quantity=@quantity WHERE CustomerId=@customerId AND ProductId=@productId", con);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@quantity", quantity + 1);
                cmd.ExecuteNonQuery();
            }

            cmd.Dispose();
            cmd = new MySqlCommand("SELECT Name FROM product WHERE Id=@productId", con);
            cmd.Parameters.AddWithValue("@productId", productId);
            string name = cmd.ExecuteScalar().ToString();
            con.Close();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "none",
                $"alert('{name} has been added to your cart');", true);
        }

        protected void Add_To_Wishlist(object sender, EventArgs e)
        {
            var customerId = Session["customerId"];
            if (customerId == null)
            {
                Response.Redirect("Login?msg=AddToWishlist");
            }

            string productId = ((LinkButton)sender).CommandArgument;
            customerId = customerId.ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["IT3685"].ConnectionString);

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Name FROM product WHERE Id=@productId", con);
            cmd.Parameters.AddWithValue("@productId", productId);
            string name = cmd.ExecuteScalar().ToString();

            cmd.Dispose();
            cmd = new MySqlCommand("SELECT COUNT(*) FROM wishlist WHERE CustomerId=@customerId AND ProductId=@productId", con);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@productId", productId);

            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            if (count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO wishlist(`CustomerId`, `ProductId`) " +
                    "VALUES(@customerId, @productId)", con);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.ExecuteNonQuery();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "none",
                    $"alert('Error: {name} is already in your wishlist');", true);
                return;
            }

            con.Close();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "none",
                $"alert('{name} has been added to your wishlist');", true);
        }
    }
}