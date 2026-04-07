namespace CafeKiosk;

public class Form1 : Form
{
    private readonly TextBox txtCustomerName;
    private readonly TextBox txtSyrupFlavor;
    private readonly CheckBox chkPremium;
    private readonly Label lblOrderTicketValue;
    private readonly Label lblPriceValue;
    private const double StandardBasePrice = 20.00;

    public Form1()
    {
        Text = "Campus Cafe Kiosk";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(420, 270);

        var lblCustomerName = new Label { Text = "Customer Name:", Left = 20, Top = 25, Width = 120 };
        txtCustomerName = new TextBox { Left = 150, Top = 20, Width = 230 };

        var lblSyrupFlavor = new Label { Text = "Syrup Flavor:", Left = 20, Top = 65, Width = 120 };
        txtSyrupFlavor = new TextBox { Left = 150, Top = 60, Width = 230 };

        chkPremium = new CheckBox
        {
            Text = "Upgrade to Premium Drink",
            Left = 150,
            Top = 95,
            Width = 220
        };

        var btnPlaceOrder = new Button { Text = "Place Order", Left = 150, Top = 125, Width = 120 };
        btnPlaceOrder.Click += PlaceOrder_Click;

        var lblOrderTicket = new Label { Text = "Order Ticket:", Left = 20, Top = 170, Width = 120 };
        lblOrderTicketValue = new Label { Text = "-", Left = 150, Top = 170, Width = 230 };

        var lblPrice = new Label { Text = "Final Price:", Left = 20, Top = 200, Width = 120 };
        lblPriceValue = new Label { Text = "-", Left = 150, Top = 200, Width = 230 };

        Controls.Add(lblCustomerName);
        Controls.Add(txtCustomerName);
        Controls.Add(lblSyrupFlavor);
        Controls.Add(txtSyrupFlavor);
        Controls.Add(chkPremium);
        Controls.Add(btnPlaceOrder);
        Controls.Add(lblOrderTicket);
        Controls.Add(lblOrderTicketValue);
        Controls.Add(lblPrice);
        Controls.Add(lblPriceValue);
    }

    private void PlaceOrder_Click(object sender, EventArgs e)
    {
        string customerName = txtCustomerName.Text;
        string syrupFlavor = txtSyrupFlavor.Text;

        string orderTicket = (customerName + syrupFlavor)
            .Trim()
            .Replace(" ", "")
            .ToUpper();

        DrinkOrder order;
        if (chkPremium.Checked == true)
        {
            order = new PremiumDrink
            {
                CustomerName = customerName.Trim(),
                BasePrice = StandardBasePrice,
                SyrupFlavor = syrupFlavor.Trim()
            };
        }
        else
        {
            order = new DrinkOrder
            {
                CustomerName = customerName.Trim(),
                BasePrice = StandardBasePrice
            };
        }

        double total = order.CalculateTotal();

        lblOrderTicketValue.Text = orderTicket;
        lblPriceValue.Text = $"R {total:0.00}";

        MessageBox.Show($"Thank you, {order.CustomerName}!", "Order Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
